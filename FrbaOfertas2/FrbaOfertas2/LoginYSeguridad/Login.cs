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
using FrbaOfertas2.Clases;

namespace FrbaOfertas2.LoginYSeguridad
{
    public partial class Login : Form
    {
        int contador = 3;

        public Login()
        {
            InitializeComponent();
            MessageBox.Show("Los Clientes y Proveedores que ya utilizaron previamente el sistema, tienen un usuario y contraseña \n\n  Clientes:\n   Usuario: DNI\n   Password: DNI"
                + "\n\n  Proveedor:\n   Usuario: CUIT\n   Password: CUIT \n\n  Administrador:\n   Usuario: admin\n   Password: admin");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button_ingresar_Click(object sender, EventArgs e)
        {
            BaseDeDato bd = new BaseDeDato();
            bd.conectar();

            SqlCommand procedure = Clases.BaseDeDato.crearConsulta("S_QUERY.loginYSeguridad");
            procedure.CommandType = CommandType.StoredProcedure;

            procedure.Parameters.AddWithValue("@usuario", SqlDbType.VarChar).Value = textBox_usuario.Text.ToString();
            procedure.Parameters.AddWithValue("@contraseña_ingresada", SqlDbType.VarChar).Value = textBox_contrasenia.Text.ToString();
            procedure.Parameters.Add("@ReturnVal", SqlDbType.Int);
            procedure.Parameters["@ReturnVal"].Direction = ParameterDirection.ReturnValue;
            procedure.ExecuteNonQuery();

            int respuesta = Convert.ToInt16(procedure.Parameters["@ReturnVal"].Value);

            bd.desconectar();

            this.reaccionRespuesta(respuesta);
        }

        private void reaccionRespuesta(int respuesta)
        {
            switch (respuesta)
            {
                case -2:
                    MessageBox.Show("No existe ese usuario o está inhabilitado");
                    break;
                case -1:
                    this.mostrarLabelUsuarioDeshabilitado(textBox_usuario.Text.ToString());
                    break;
                case 0:
//                    contador = contador - 1;
//                    label_intentos.Visible = true;
//                    label_intentos.Text = label_intentos.Tag.ToString() + " " + contador;
                    MessageBox.Show("Contraseña incorrecta");
                    break;
                case 1:
                    MessageBox.Show("Te loggeaste correctamente");
                    MenuInicio menu = new MenuInicio(this.buscarCodigoUsuario(textBox_usuario.Text.ToString()), this);
                    this.Hide();
                    menu.Show();
                    break;
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

        private void textBox_usuario_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox_contrasenia_TextChanged(object sender, EventArgs e)
        {

        }

        private int buscarCodigoUsuario(String username)
        {
            int codigo_encontrado;
            BaseDeDato bd = new BaseDeDato();
            bd.conectar();

            String query_buscar_usuario_y_contrasenia = "SELECT usuario_codigo FROM S_QUERY.Usuario WHERE usuario_nombre = '" +
            textBox_usuario.Text.ToString() + "'";
            SqlDataAdapter sda_select = new SqlDataAdapter(query_buscar_usuario_y_contrasenia, bd.obtenerConexion());
            DataTable data_usuario = new DataTable();

            sda_select.Fill(data_usuario);

            bd.desconectar();

            codigo_encontrado = int.Parse(data_usuario.Rows[0].ItemArray[0].ToString());


            return codigo_encontrado;
        }

        public void limpiate()
        {
            textBox_usuario.Clear();
            textBox_contrasenia.Clear();
        }

    }
}
