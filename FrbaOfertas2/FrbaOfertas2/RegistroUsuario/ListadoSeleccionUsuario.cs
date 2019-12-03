using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas2.Clases;
using System.Data.SqlClient;
using FrbaOfertas2.RegistroUsuario.AbmCliente;
using FrbaOfertas2.RegistroUsuario.AbmProveedor;

namespace FrbaOfertas2.RegistroUsuario
{
    public partial class ListadoSeleccionUsuario : Form
    {

        BaseDeDato bd = new BaseDeDato();
        String rolNombre;

        public ListadoSeleccionUsuario(String rolNombreIngresado )
        {
            InitializeComponent();
            rolNombre = rolNombreIngresado;
            this.mostrarTodos();
 
        }

        public void mostrarTodos()
        {
            bd.conectar();
            //hay que hacer que esta query de abajo solo te agarre los que no sean clientes.
            String query_select_rol = "  SELECT usuario.usuario_codigo, usuario.usuario_nombre, usuario.usuario_contraseña FROM S_QUERY.Usuario usuario LEFT JOIN S_QUERY.RolXUsuario RolXu ON usuario.usuario_codigo = RolXu.usuario_codigo"
                + " LEFT JOIN S_QUERY.Rol rol ON rol.rol_codigo = RolXu.rol_codigo"
                + "    WHERE usuario.usuario_codigo NOT IN (SELECT usuario1.usuario_codigo FROM S_QUERY.Usuario usuario1 JOIN S_QUERY.RolXUsuario RolXu1 ON usuario1.usuario_codigo = RolXu1.usuario_codigo "
            + "JOIN S_QUERY.Rol rol1 ON rol1.rol_codigo = RolXu1.rol_codigo WHERE rol1.rol_nombre  = '" + rolNombre + "' ) ";
            SqlCommand comando = new SqlCommand(query_select_rol, bd.obtenerConexion());

            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;

            this.cargarDataGridUsuarios(adaptador);

            bd.desconectar();
        }

        private void cargarDataGridUsuarios(SqlDataAdapter adaptador)
        {

            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);

            dataGridView_usuarios.DataSource = tabla;

        }



        private void button_seleccionar_Click(object sender, EventArgs e)
        {

            int row_index = dataGridView_usuarios.CurrentCell.RowIndex;
            String row_password_usuario = dataGridView_usuarios.CurrentRow.Cells["usuario_contraseña"].Value.ToString();
            String row_username_usuario = dataGridView_usuarios.CurrentRow.Cells["usuario_nombre"].Value.ToString();

            Usuario usuarioForm = new Usuario(row_password_usuario , row_username_usuario);

            if( rolNombre.Equals("Cliente")){
                AltaCliente altaFormCliente = new AltaCliente(usuarioForm);
                altaFormCliente.Show();
                altaFormCliente.FormClosed += new FormClosedEventHandler(afterCloseAlta);
                this.Hide();
            }

            if (rolNombre.Equals("Proveedor"))
            {
                AltaProveedor altaFormProveedor = new AltaProveedor(usuarioForm);
                altaFormProveedor.Show();
                altaFormProveedor.FormClosed += new FormClosedEventHandler(afterCloseAlta);
                this.Hide();

            }

        }

        private void afterCloseAlta(Object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void button_volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_buscar_Click(object sender, EventArgs e)
        {

            bd.conectar();

            String query_select_users = "  SELECT usuario.usuario_codigo, usuario_nombre, usuario_contraseña FROM S_QUERY.Usuario usuario LEFT JOIN S_QUERY.RolXUsuario RolXu ON usuario.usuario_codigo = RolXu.usuario_codigo"
                + " LEFT JOIN S_QUERY.Rol rol ON rol.rol_codigo = RolXu.rol_codigo"
                 + "    WHERE usuario.usuario_codigo NOT IN (SELECT usuario1.usuario_codigo FROM S_QUERY.Usuario usuario1 JOIN S_QUERY.RolXUsuario RolXu1 ON usuario1.usuario_codigo = RolXu1.usuario_codigo "
            + "JOIN S_QUERY.Rol rol1 ON rol1.rol_codigo = RolXu1.rol_codigo WHERE rol1.rol_nombre  = '" + rolNombre + "' ) "; ;

            if(this.camposBuscarCompletos()){

                query_select_users += " AND usuario.usuario_nombre LIKE '%" + textBox_nombre.Text.ToString() + "%'";

            }

            SqlCommand comando = new SqlCommand(query_select_users, bd.obtenerConexion());

            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;

            this.cargarDataGridUsuarios(adaptador);

            bd.desconectar();

        }

        private bool camposBuscarCompletos()
        {
            return textBox_nombre.Text != "";

        }

        private void button_actualizar_Click(object sender, EventArgs e)
        {
            this.mostrarTodos();
        }

        private void button_limpiar_Click(object sender, EventArgs e)
        {
            textBox_nombre.Clear();
        }
    }
}
