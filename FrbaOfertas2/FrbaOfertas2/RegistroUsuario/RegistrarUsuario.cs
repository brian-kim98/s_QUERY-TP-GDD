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
            BaseDeDato bd = new BaseDeDato();

            try
            {
                bd.conectar();
                String query_obtenerRoles = "SELECT rol_codigo, rol_nombre FROM S_QUERY.Rol WHERE rol_nombre != 'Administrativo'";
                SqlDataAdapter sda = new SqlDataAdapter(query_obtenerRoles, bd.obtenerConexion());

                sda.Fill(tabla_rol);

            }
     
            catch (SqlException se)
            {
                MessageBox.Show("An error occured while connecting to database" + se.ToString());
            }




            comboBox_rol_asignado.DataSource = tabla_rol;
            comboBox_rol_asignado.DisplayMember = "rol_nombre";
            comboBox_rol_asignado.ValueMember = "rol_nombre";

            bd.desconectar();
        }

         /// //////////////////////////////////////////////////////////////////////////////////////////////////////



        /// //////////////////////////////////////////////////////////////////////////////////////////////////////

        private void button_crear_Click(object sender, EventArgs e)
        {

            if( !this.ingresoTodosLosCampos()){

                MessageBox.Show("Complete todos los campos");
                return;
            }

            BaseDeDato bd = new BaseDeDato();

            try
            {
                bd.conectar();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand("SELECT S_QUERY.verificarUsuario(@usuario)", bd.obtenerConexion());
                SqlParameter usuario = new SqlParameter("@usuario", SqlDbType.VarChar);
                usuario.Value = textBox_username.Text;

                command.Parameters.Add(usuario);

                int verificador = (int)command.ExecuteScalar();



                switch (verificador)
                {
                    case 0:
                        this.segundoPaso(bd);
                        break;
                    case 1:
                        MessageBox.Show("Ya existe ese nombre de usuario, elija otro");
                        bd.desconectar();
                        break;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                bd.desconectar();
            }            
        }

        private void segundoPaso(BaseDeDato bd)
        {
            String password_encriptado = this.encriptacion_password(textBox_password.Text.ToString());

            Usuario usuario_nuevo = new Usuario(password_encriptado, textBox_username.Text);
            if (comboBox_rol_asignado.SelectedValue.ToString() == "Cliente")
            {
                AltaCliente alta = new AltaCliente(usuario_nuevo);
                alta.Show();
                this.Close();
                bd.desconectar();
            }


            if (comboBox_rol_asignado.SelectedValue.ToString() == "Proveedor")
            {
                AltaProveedor alta = new AltaProveedor(usuario_nuevo);
                alta.Show();
                this.Close();
                bd.desconectar();
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
                textBox_password.Text != "" &&
                comboBox_rol_asignado.SelectedIndex > -1;

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button_limpiar_Click(object sender, EventArgs e)
        {
            textBox_username.Clear();
            textBox_password.Clear();
            comboBox_rol_asignado.SelectedItem = null;
        }

        private void textBox_password_TextChanged(object sender, EventArgs e)
        {

        }


        /// //////////////////////////////////////////////////////////////////////////////////////////////////////
            


    }
}
