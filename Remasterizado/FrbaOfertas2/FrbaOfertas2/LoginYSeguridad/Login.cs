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
        String alerta_intentos = "Cantidad de intentos fallidos: ";

        public Login()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(this.estaHabilitadoUsuario(textBox_usuario.Text.ToString()) && contador < 3)
            {
                String passwordEncontrada = this.buscarPassword(textBox_usuario.Text.ToString());

                if (encriptacion_password(textBox_contrasenia.Text.ToString()) == passwordEncontrada)
                {
//                    Menu menuParaUsuario = new Menu();
//                    menuParaUsuario.View();

                    MessageBox.Show("Podes entrar !");
                }

                else
                {
                    label_intentos.Visible = true;
                    label_intentos.Text = alerta_intentos + (contador + 1);
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

        private String buscarPassword(String username)
        {
            SqlConnection connection = ConnectionWithDatabase();
            connection.Open();

            String query_buscar_usuario_y_contrasenia = "SELECT usuario_contraseña FROM S_QUERY.Usuario WHERE usuario_nombre = '" +
                textBox_usuario.Text.ToString() + "'";
            SqlDataAdapter sda_select = new SqlDataAdapter(query_buscar_usuario_y_contrasenia, connection);
            DataTable data_usuario = new DataTable();

            sda_select.Fill(data_usuario);

            return data_usuario.Rows[0].ItemArray[0].ToString();
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
            SqlConnection connection = ConnectionWithDatabase();
            connection.Open();

            String query_buscar_usuario = "SELECT usuario_habilitado FROM S_QUERY.Usuario WHERE usuario_nombre = '" +
                textBox_usuario.Text.ToString() + "'";
            SqlDataAdapter sda_select = new SqlDataAdapter(query_buscar_usuario, connection);
            DataTable data_usuario = new DataTable();

            sda_select.Fill(data_usuario);

            connection.Close();

            return (bool)data_usuario.Rows[0].ItemArray[0];
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

    }
}
