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
using FrbaOfertas2.CrearOferta;
using FrbaOfertas2.AbmRol;
using FrbaOfertas2.CargaCredito;

namespace FrbaOfertas2.MenuPrincipal
{
    public partial class MenuInicio : Form
    {
        private BaseDeDato bd = new BaseDeDato();
        SqlDataAdapter adapter;
        int codigo_user;

        public MenuInicio(int codigo_usuario)
        {
            InitializeComponent();
            codigo_user = codigo_usuario;
            this.habilitar_funcionalidades(codigo_usuario);
            MessageBox.Show("Termino");
        
        }

        private void habilitar_funcionalidades(int codigo_usuario)
        {
            List<String> listaFuncionalidades;

            listaFuncionalidades = this.obtenerListaFuncionalidades(codigo_usuario);

            if (!listaFuncionalidades.Contains("Confeccion y publicacion de Ofertas"))
            {
                this.inhabilitar_button(button_crear_oferta);
            }


            if ( !listaFuncionalidades.Contains("Comprar Oferta"))
            {
                this.inhabilitar_button(button_comprar_oferta);
            }

            if (!listaFuncionalidades.Contains("Cargar Credito"))
            {

                this.inhabilitar_button(button_carga_credito);
            }

            //Falta terminar

        }

        private List<String> obtenerListaFuncionalidades(int codigo_usuario)
        {
            List<String> funcionalidades = new List<String>();

            

            String selectFuncionalidadesQuery = "SELECT f.func_nombre FROM S_QUERY.Funcionalidad f "
                + "JOIN S_QUERY.FuncionalidadXRol fr ON fr.func_codigo = f.func_codigo "
                + "JOIN S_QUERY.Rol r ON r.rol_codigo = fr.rol_codigo "
                + "JOIN S_QUERY.RolXUsuario u ON r.rol_codigo = u.rol_codigo "
                + "WHERE u.usuario_codigo = '" + codigo_usuario.ToString() + "'";

            try
            {
                using (SqlCommand cmd = new SqlCommand(selectFuncionalidadesQuery, bd.obtenerConexion()))
                {
                    //Empleados a = new Empleados();
                    SqlDataReader dr;
                    cmd.Connection = bd.obtenerConexion();
                    cmd.Connection.Open();
                    dr = cmd.ExecuteReader();
                    //dr = Empleado.Adaptador.ObtenerTodosEmpleados();
                    if (dr.HasRows == true)
                        while (dr.Read())
                            //ListaEmpleado.Add(new TraerEmpleado(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString()));
                            funcionalidades.Add(dr[0].ToString());

                    cmd.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


           
            return funcionalidades;
        }

        public void inhabilitar_button(Button botonAModificar)
        {


            botonAModificar.BackColor = SystemColors.ControlDark;

            botonAModificar.FlatStyle = FlatStyle.Popup;
         
            botonAModificar.Enabled = false;

            botonAModificar.Visible = false;

        }


        public void habilitar_button(Button botonAModificar)
        {

            
            botonAModificar.BackColor = SystemColors.Control;
            
            botonAModificar.FlatStyle = FlatStyle.Standard;
            MessageBox.Show("prueba222");
            botonAModificar.Enabled = true;
            MessageBox.Show("pruebaa");
            //botonAModificar.Visible = true;
            MessageBox.Show("prueba111");
        }

        private void button_crear_oferta_Click(object sender, EventArgs e)
        {
            CreacionOferta crearOferta = new CreacionOferta(codigo_user);
            crearOferta.Show();
            MessageBox.Show("hoaala");
        }

        private void button_comprar_oferta_Click(object sender, EventArgs e)
        {

        }

        private void button_roles_Click(object sender, EventArgs e)
        {
            ListadoRoles listaRoles = new ListadoRoles();
            listaRoles.Show();
        }

        private void button_carga_credito_Click(object sender, EventArgs e)
        {
            CargarCredito nuevaCarga = new CargarCredito(codigo_user);
            nuevaCarga.Show();
            this.Close();
        }
    }
}
