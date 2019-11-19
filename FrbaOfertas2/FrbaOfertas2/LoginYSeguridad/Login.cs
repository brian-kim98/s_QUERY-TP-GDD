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
using System.Security.Cryptography;
using FrbaOfertas2.MenuPrincipal;

namespace FrbaOfertas2.LoginYSeguridad
{
    public partial class Login : Form
    {
        int contador = 0;

        public Login()
        {
            InitializeComponent();
            MessageBox.Show("Los Clientes y Proveedores que ya utilizaron previamente el sistema, tienen un usuario y contraseña \n\n  Clientes:\n   Usuario: Nombre del cliente\n   Password: Dni"
                + "\n\n  Proveedor:\n   Usuario: Nombre del Proveedor\n   Password: CUIT");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            bool habilitado = this.estaHabilitadoUsuario(textBox_usuario.Text.ToString());

            while ( habilitado  && contador < 3)
            {
                String passwordEncontrada = this.buscarPassword(textBox_usuario.Text.ToString());

             

                if (encriptacion_password(textBox_contrasenia.Text.ToString()) == passwordEncontrada)
                {
//                    Menu menuParaUsuario = new Menu();
//                    menuParaUsuario.View();

                   // MenuProveedor menuParaMostrar

                    //aca deberiamos crear el menu y pasarle el codigo de usuario por parametro


                    int codigo_usuario = this.buscarCodigoUsuario(textBox_usuario.Text.ToString());

                    MenuInicio mostrarMenu = new MenuInicio(codigo_usuario);
                    
                    mostrarMenu.Show();
                    this.Hide();
                    break;
                }

                else
                {
                    label_intentos.Visible = true;
                    label_intentos.Text = label_intentos.Text.ToString() + " " + contador;
                    MessageBox.Show("Contraseña incorrecta.");
                    contador++;
                }
            }





            if (contador == 3)
            {
                this.inhabilitarUsuario(textBox_usuario.Text.ToString());
            }


          

        }

        private SqlConnection ConnectionWithDatabase()
        {
            string connectionString;
            SqlConnection connection;

            connectionString = @"Data Source=.\SQLSERVER2012;Initial Catalog = GD2C2019;User ID=sa;Password=gestiondedatos";

            connection = new SqlConnection(connectionString);

            return connection;

        }

        private int buscarCodigoUsuario(String username)
        {
            int codigo_encontrado;

            using(SqlConnection connection = ConnectionWithDatabase())
            {
                connection.Open();

                String query_buscar_usuario_y_contrasenia = "SELECT usuario_codigo FROM S_QUERY.Usuario WHERE usuario_nombre = '" +
                    textBox_usuario.Text.ToString() + "'";
                SqlDataAdapter sda_select = new SqlDataAdapter(query_buscar_usuario_y_contrasenia, connection);
                DataTable data_usuario = new DataTable();

                sda_select.Fill(data_usuario);

                codigo_encontrado = int.Parse(data_usuario.Rows[0].ItemArray[0].ToString());


            }

            return codigo_encontrado;
        }

        private String buscarPassword(String username)
        {



            using (SqlConnection connection = ConnectionWithDatabase())
            {

                connection.Open();

                String query_buscar_usuario_y_contrasenia = "SELECT usuario_contraseña FROM S_QUERY.Usuario WHERE usuario_nombre = '" +
                    textBox_usuario.Text.ToString() + "'";
                SqlDataAdapter sda_select = new SqlDataAdapter(query_buscar_usuario_y_contrasenia, connection);
                DataTable data_usuario = new DataTable();

                sda_select.Fill(data_usuario);

                return data_usuario.Rows[0].ItemArray[0].ToString();
            }
        }

        private String encriptacion_password(String str)
        {

            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();

        }

        private void inhabilitarUsuario(String username)
        {

            this.mostrarLabelUsuarioDeshabilitado(username);
        }

        private void label_alerta_Click_1(object sender, EventArgs e)
        {

        }

        private void mostrarLabelUsuarioDeshabilitado(String username)
        {
            label_alerta.Visible = true;
            label_alerta.Text = "El usuario \"" + username + "\" se encuentra inhabilitado"; 
        }

        private bool estaHabilitadoUsuario(String username)
        {

            bool resultado;

            String query_buscar_usuario = "SELECT usuario_habilitado FROM S_QUERY.Usuario WHERE usuario_nombre = '" +
                textBox_usuario.Text.ToString() + "'";

            using (SqlConnection connection = ConnectionWithDatabase())
            {

                try
                {
                    connection.Open();


                    SqlDataAdapter sda_select = new SqlDataAdapter(query_buscar_usuario, connection);
                    DataTable data_usuario = new DataTable();

                    sda_select.Fill(data_usuario);

                    resultado = Convert.ToBoolean(data_usuario.Rows[0].ItemArray[0].ToString());


                    if (!resultado)
                    {
                        MessageBox.Show("Usuario Inhabilitado");
                    }
                    

                }
                catch (SqlException)
                {
                    MessageBox.Show("Ocurrio un error");
                    return false;
                }


            }


            return resultado;

        }

       /* private bool estaHabilitadoUsuario(String username)
        {
            Int32 newProdID = 0;
            string sql =
                "SELECT usuario_habilitado FROM S_QUERY.Usuario WHERE usuario_nombre = '" +
                textBox_usuario.Text.ToString() + "'";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Name", SqlDbType.VarChar);
                cmd.Parameters["@name"].Value = newName;
                try
                {
                    conn.Open();
                    newProdID = (Int32)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return (bool)newProdID;
        }*/




        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button_registrarse_Click(object sender, EventArgs e)
        {
            RegistrarUsuario registro = new RegistrarUsuario();
            registro.Show();
            
        }

    }
}
