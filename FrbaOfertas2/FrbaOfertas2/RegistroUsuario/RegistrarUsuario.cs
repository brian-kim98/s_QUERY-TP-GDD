using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using FrbaOfertas2.RegistroUsuario.AbmCliente;
using FrbaOfertas2.RegistroUsuario.AbmProveedor;
using FrbaOfertas2.Clases;


namespace FrbaOfertas2
{
    public partial class RegistrarUsuario : Form
    {

        SqlDataAdapter generico = new SqlDataAdapter();
        private DataTable tabla_rol = new DataTable();

        public RegistrarUsuario()
        {
            InitializeComponent();
            carga_comboBox_rol_asignado();
            
        }

        private void RegistroUsuario_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox_username_TextChanged(object sender, EventArgs e)
        {

        }

  
        /// ///////////////////////////////////////////////////////////////////////////////////
        

        private void carga_comboBox_rol_asignado()
        {
            SqlConnection connection = ConnectionWithDatabase();

            String query_obtenerRoles = "SELECT rol_codigo, rol_nombre FROM S_QUERY.Rol";
            SqlDataAdapter sda = new SqlDataAdapter(query_obtenerRoles, connection);

            try
            {
                connection.Open();
                sda.Fill(tabla_rol);

            }

            catch (SqlException se)
            {
                MessageBox.Show("An error occured while connecting to database" + se.ToString());
            }




            comboBox_rol_asignado.DataSource = tabla_rol;
            comboBox_rol_asignado.DisplayMember = "rol_nombre";
            comboBox_rol_asignado.ValueMember = "rol_nombre";

            connection.Close();
        }

         /// //////////////////////////////////////////////////////////////////////////////////////////////////////



        /// //////////////////////////////////////////////////////////////////////////////////////////////////////

        private SqlConnection ConnectionWithDatabase()
        {
            string connectionString;
            SqlConnection connection;

            connectionString = @"Data Source=.\SQLSERVER2012;Initial Catalog = GD2C2019;User ID=sa;Password=gestiondedatos";

            connection = new SqlConnection(connectionString);

            return connection;

        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////

        private void button_crear_Click(object sender, EventArgs e)
        {

            if( !this.ingresoTodosLosCampos()){

                MessageBox.Show("Complete todos los campos");
                return;
            }

            BaseDeDato bd = new BaseDeDato();

            

            String password_encriptado = this.encriptacion_password(textBox_password.Text.ToString());

            Usuario usuario_nuevo = new Usuario(password_encriptado, textBox_username.Text);
            if (comboBox_rol_asignado.SelectedValue.ToString() == "Cliente")
            {
                AltaCliente alta = new AltaCliente(usuario_nuevo);
                alta.Show();
                this.Close();
            }


            if (comboBox_rol_asignado.SelectedValue.ToString() == "Proveedor")
            {
                AltaProveedor alta = new AltaProveedor(usuario_nuevo);
                alta.Show();
                this.Close();
            }


            
        } 

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////

        private String encriptacion_password(String str) { 
        
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
            
        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////


        private bool ingresoTodosLosCampos()
        {

            return textBox_username.Text != "" &&
                textBox_username.Text != "" &&
                comboBox_rol_asignado.SelectedIndex > -1;

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }


        /// //////////////////////////////////////////////////////////////////////////////////////////////////////
            


    }
}
