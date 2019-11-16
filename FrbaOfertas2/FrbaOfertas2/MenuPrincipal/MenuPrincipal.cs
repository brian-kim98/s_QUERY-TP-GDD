using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using FrbaOfertas2.Clases;

namespace FrbaOfertas2.MenuPrincipal
{
    public partial class MenuPrincipal : Form
    {

        private BaseDeDato bd = new BaseDeDato();
        SqlDataAdapter adapter;

        public MenuPrincipal(int codigo_usuario)
        {
            InitializeComponent();
            this.habilitar_funcionalidades(codigo_usuario);
        }

        private void button_crear_oferta_Click(object sender, EventArgs e)
        {

        }

        private void habilitar_funcionalidades(int codigo_usuario)
        {
            List<String> listaFuncionalidades;

            listaFuncionalidades = this.obtenerListaFuncionalidades(codigo_usuario);

            if(listaFuncionalidades.Contains("Comprar Oferta")){
                this.habilitar_button(button_comprar_oferta);
            }

            if(listaFuncionalidades.Contains("Cargar Credito")){
                this.habilitar_button(button_carga_credito);
            }

            //Falta terminar
            
        }

        private List<String> obtenerListaFuncionalidades(int codigo_usuario)
        {
            List<String> funcionalidades = new List<String>();

            bd.conectar();

            String selectFuncionalidadesQuery = "SELECT f.func_nombre FROM [S_QUERY].Funcionalidad f"
	            + "JOIN S_QUERY.FuncionalidadXRol fr ON fr.func_codigo = f.func_codigo"
	            + "JOIN S_QUERY.Rol r ON r.rol_codigo = fr.rol_codigo"
	            + "JOIN S_QUERY.RolXUsuario u ON r.rol_codigo = ' " + codigo_usuario.ToString() +  "'"; 

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


        public void habilitar_button(Button botonAModificar)
        {
            botonAModificar.BackColor = SystemColors.Control;
            botonAModificar.FlatStyle = FlatStyle.Standard;
            botonAModificar.Enabled = true;
           
        }
    }
}
