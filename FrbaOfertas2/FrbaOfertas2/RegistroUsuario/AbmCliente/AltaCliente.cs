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
using System.Security.Cryptography;

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
            label_user.Text = nuevo_usuario.username;
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
            if (
                this.boxVacio(textBox_apellido) || this.boxVacio(textBox_nombre) || this.boxVacio(textBox_dni) ||
                this.boxVacio(textBox_mail) || this.boxVacio(textBox_telefono) || this.boxVacio(textBox_calle) ||
                this.boxVacio(textBox_numero) || this.boxVacio(textBox_localidad) || this.boxVacio(textBox_codigo_postal) ||
                !this.chequearDepartamento()
                )
            {
                MessageBox.Show("Hay Campos Incompletos.");
                return false;

            }
            else
            {
                
                return true;
            }
            return true;

        }

        private bool chequearDepartamento(){

            if (textBox_numero_piso.Text.ToString() == "" && textBox_departamento.Text.ToString() == "")
            {

                return true;
            }
            else if (textBox_numero_piso.Text.ToString() != "" && textBox_departamento.Text.ToString() != "")
            {

                return true;
            }
            else{
                textBox_numero_piso.BackColor = Color.OrangeRed;
                textBox_departamento.BackColor = Color.OrangeRed;
                return false;
            }
        }

        private bool boxVacio(TextBox box)
        {
            if (box.Text.ToString() == "")
            {
                box.BackColor = Color.OrangeRed;
                return true;
            }
            else
            {
                box.BackColor = Color.White;
            }

            return false;
        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////

        private bool verificarCamposNumericos()
        {
            if (!this.esUnCampoNumerico(textBox_codigo_postal) || !this.esUnCampoNumerico(textBox_numero) || !this.esUnCampoNumerico(textBox_dni) || !this.esUnCampoNumerico(textBox_telefono)   )
            {
                MessageBox.Show("Hay Campos numericos Erroneos");
                return false;
            }

            return true;
        }

        private bool esUnCampoNumerico(TextBox casilla_texto)
        {

            double valorDouble = 0.0;

            float valorFloat = (float)valorDouble;

            bool respuesta = float.TryParse(casilla_texto.Text, out valorFloat);

            if (!respuesta)
            {
                casilla_texto.BackColor = SystemColors.ControlDark;
            }

            return respuesta;

        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////
        private void button_crear_Click(object sender, EventArgs e)
        {
            if(this.todosLosCamposCompletos() && this.verificarCamposNumericos()){
            
                int id_direccion = this.crear_direccion();

                BaseDeDato bd = new BaseDeDato();

                try
                {
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

                    this.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    bd.desconectar();
                }


                
            }
        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 

        private int crear_direccion()
        {
            BaseDeDato bd = new BaseDeDato();

            int codigo_direccion = 0;

            try
            {
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

                codigo_direccion = Convert.ToInt32(procedure.Parameters["@ReturnVal"].Value);

                bd.desconectar();

                return codigo_direccion;

            }catch(Exception ex){
                MessageBox.Show(ex.Message);
            }

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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox_codigo_postal_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_limpiar_Click(object sender, EventArgs e)
        {
            textBox_apellido.Clear();
            textBox_calle.Clear();
            textBox_codigo_postal.Clear();
            textBox_departamento.Clear();
            textBox_dni.Clear();
            textBox_localidad.Clear();
            textBox_mail.Clear();
            textBox_nombre.Clear();
            textBox_numero.Clear();
            textBox_numero_piso.Clear();
            textBox_telefono.Clear();
            dateTimePicker_fecha_nacimiento.ResetText();
        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
