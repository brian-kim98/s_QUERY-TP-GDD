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
using FrbaOfertas2.LoginYSeguridad;
using FrbaOfertas2.Clases;

namespace FrbaOfertas2.RegistroUsuario.AbmCliente
{
    public partial class AltaCliente : Form
    {

        public Usuario usuario_registrar;
        SqlDataAdapter generico = new SqlDataAdapter();


        public AltaCliente(Usuario nuevo_usuario )
        {
            InitializeComponent();
            usuario_registrar = nuevo_usuario;

        }

        public AltaCliente()
        {
            InitializeComponent();
        }

        private void AltaCliente_Load(object sender, EventArgs e)
        {

        }

        private void textBox_nombre_TextChanged(object sender, EventArgs e)
        {

        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBox_mail_TextChanged(object sender, EventArgs e)
        {

        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////

        private bool todosLosCamposCompletos()
        {
            //modificar esto luego
            return true;

        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////

        private bool verificarCamposNumericos()
        {
            //modificar esto luego
            return true;

        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////
        private void button_crear_Click(object sender, EventArgs e)
        {
            if(this.todosLosCamposCompletos() && this.verificarCamposNumericos()){
            
                int id_direccion = this.crear_direccion();

                BaseDeDato bd = new BaseDeDato();

                bd.conectar();

                SqlCommand procedure = Clases.BaseDeDato.crearConsulta("S_QUERY.insertarCliente");
                procedure.CommandType = CommandType.StoredProcedure;
                procedure.Parameters.AddWithValue("@usuario_nombre", SqlDbType.VarChar).Value = usuario_registrar.username;
                procedure.Parameters.AddWithValue("@usuario_contraseña", SqlDbType.VarChar).Value = usuario_registrar.password;
                procedure.Parameters.AddWithValue("@clie_nombre", SqlDbType.VarChar).Value = textBox_nombre.Text;
                procedure.Parameters.AddWithValue("@clie_apellido", SqlDbType.VarChar).Value = textBox_apellido.Text;
                procedure.Parameters.AddWithValue("@clie_dni", SqlDbType.Int).Value = (int)Convert.ToInt32(textBox_dni.Text);
                procedure.Parameters.AddWithValue("@clie_mail", SqlDbType.VarChar).Value = textBox_mail.Text;
                procedure.Parameters.AddWithValue("@clie_telefono", SqlDbType.Int).Value = (int)Convert.ToInt32(textBox_telefono.Text);
                procedure.Parameters.AddWithValue("@clie_fecha_nacimiento", SqlDbType.Date).Value = dateTimePicker_fecha_nacimiento.Value;
                procedure.Parameters.AddWithValue("@clie_saldo", SqlDbType.Float).Value = 200.00;
                procedure.Parameters.AddWithValue("@direc_codigo", SqlDbType.Int).Value = id_direccion;

                procedure.ExecuteNonQuery();

                bd.desconectar();

                Login nuevoLogin = new Login();
                nuevoLogin.Show();
                this.Close();
            }
        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 

        private int crear_direccion()
        {
            BaseDeDato bd = new BaseDeDato();

            bd.conectar();

            SqlCommand procedure = Clases.BaseDeDato.crearConsulta("S_QUERY.crearDireccion");
            procedure.CommandType = CommandType.StoredProcedure;
            procedure.Parameters.AddWithValue("@direc_localidad", SqlDbType.VarChar).Value = textBox_localidad.Text;
            procedure.Parameters.AddWithValue("@direc_calle", SqlDbType.VarChar).Value = textBox_calle.Text;
            procedure.Parameters.AddWithValue("@direc_nro", SqlDbType.Int).Value = (int)Convert.ToInt16(textBox_numero.Text);

            if (textBox_numero_piso.Text != "" && textBox_departamento.Text != "")
            {

                procedure.Parameters.AddWithValue("@direc_piso", SqlDbType.Int).Value = (int)Convert.ToInt16(textBox_numero_piso.Text);
                procedure.Parameters.AddWithValue("@direc_depto", SqlDbType.Int).Value = (int)Convert.ToInt16(textBox_departamento.Text);

            }
            else
            {
                procedure.Parameters.AddWithValue("@direc_piso", SqlDbType.Int).Value = (object)DBNull.Value;
                procedure.Parameters.AddWithValue("@direc_depto", SqlDbType.Int).Value = (object)DBNull.Value;
            }

            procedure.Parameters.Add("@ReturnVal", SqlDbType.Int);
            procedure.Parameters["@ReturnVal"].Direction = ParameterDirection.ReturnValue;
            procedure.ExecuteNonQuery();

            int codigo_direccion = Convert.ToInt32(procedure.Parameters["@ReturnVal"].Value);

            bd.desconectar();

            return codigo_direccion;
        }
        
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////

        private int obtener_usuario(String username)
        {
            SqlConnection connection = ConnectionWithDatabase();
            connection.Open();

            String query_select_usuario_id = "SELECT usuario_codigo FROM S_QUERY.Usuario WHERE usuario_nombre = '" + username + "'";
            SqlDataAdapter sda_select = new SqlDataAdapter(query_select_usuario_id, connection);
            DataTable data_usuario = new DataTable();

            sda_select.Fill(data_usuario);

            connection.Close();



            return (int) data_usuario.Rows[0].ItemArray[0];

        }

        private int obtener_direccion(String localidad, String calle, int numero, Int16 piso, Int16 depto)
        {
            SqlConnection connection = ConnectionWithDatabase();
            connection.Open();

            String query_select_direccion_id = "SELECT direc_codigo FROM S_QUERY.Direccion WHERE " + 
            "direc_localidad = '" + localidad + "' AND " +
            "direc_calle = '" + calle + "' AND " +
            "direc_nro = " + numero + " AND " +
            "direc_piso = " + piso + " AND " +
            "direc_depto = " + depto;
            SqlDataAdapter sda_select = new SqlDataAdapter(query_select_direccion_id, connection);
            DataTable data_direccion = new DataTable();

            sda_select.Fill(data_direccion);

            connection.Close();

            return (int) data_direccion.Rows[0].ItemArray[0];
        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////

        private SqlConnection ConnectionWithDatabase()
        {
            string connectionString;
            SqlConnection connection;

            connectionString = @"Data Source=.\SQLSERVER2012;Initial Catalog = GD2C2019;User ID=sa;Password=gestiondedatos";

            connection = new SqlConnection(connectionString);

            return connection;

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox_codigo_postal_TextChanged(object sender, EventArgs e)
        {

        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
