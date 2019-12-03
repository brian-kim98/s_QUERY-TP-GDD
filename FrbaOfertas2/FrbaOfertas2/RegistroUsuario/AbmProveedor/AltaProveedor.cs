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
using FrbaOfertas2.LoginYSeguridad;

namespace FrbaOfertas2.RegistroUsuario.AbmProveedor
{
    public partial class AltaProveedor : Form
    {
        public Usuario usuario_conectado;
        SqlDataAdapter generico = new SqlDataAdapter();
        private DataTable tabla_rubros = new DataTable();

        public AltaProveedor(Usuario usuario)
        {
            InitializeComponent();
            usuario_conectado = usuario;
            this.cargarSelectorRubro();
           
        }

        public AltaProveedor()
        {
            InitializeComponent();
        }

        /// ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 
        private bool todosLosCamposCompletos()
        {

            if (!this.boxVacio(textBox_calle) && !this.boxVacio(textBox_ciudad) && !this.boxVacio(textBox_codigoPostal) && !this.boxVacio(textBox_cuit)
                && !this.boxVacio(textBox_localidad) && !this.boxVacio(textBox_mail) && !this.boxVacio(textBox_nombreContacto) && !this.boxVacio(textBox_numero)
                && !this.boxVacio(textBox_razonSocial) && !this.boxVacio(textBox_telefono))
            {
               
                return true;
            }
            else
            {
                MessageBox.Show("Hay campos Vacios.");
                return false;
            }

        }

        /// ////////////////////////////////////////////////////////////////////////////////////////////////////

        private bool verificarCamposNumericos()
        {
            if (!this.esUnCampoNumerico(textBox_telefono) || !this.esUnCampoNumerico(textBox_numero) || !this.esUnCampoNumerico(textBox_codigoPostal) )
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

        /// ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void button_crear_Click(object sender, EventArgs e)
        {

            if (this.todosLosCamposCompletos() && this.verificarCamposNumericos())
            {

                int id_rubro = this.obtener_rubro(comboBox_rubro.Text.ToString());
                int id_direccion = this.crear_direccion();
                BaseDeDato bd = new BaseDeDato();

                try
                {
                    bd.conectar();

                    SqlCommand procedure = Clases.BaseDeDato.crearConsulta("S_QUERY.insertarProveedor");
                    procedure.CommandType = CommandType.StoredProcedure;
                    procedure.Parameters.AddWithValue("@usuario_nombre_prov", SqlDbType.VarChar).Value = usuario_conectado.username;
                    procedure.Parameters.AddWithValue("@usuario_contraseña_prov", SqlDbType.VarChar).Value = usuario_conectado.password;
                    procedure.Parameters.AddWithValue("@razon_social_prov", SqlDbType.VarChar).Value = textBox_razonSocial.Text;
                    procedure.Parameters.AddWithValue("@cuit_prov", SqlDbType.VarChar).Value = textBox_cuit.Text;
                    procedure.Parameters.AddWithValue("@mail_prov", SqlDbType.VarChar).Value = textBox_mail.Text;
                    procedure.Parameters.AddWithValue("@ciudad_prov", SqlDbType.VarChar).Value = textBox_ciudad.Text;
                    procedure.Parameters.AddWithValue("@telefono_prov", SqlDbType.Int).Value = (int)Convert.ToInt32(textBox_telefono.Text);
                    procedure.Parameters.AddWithValue("@nombre_contacto_prov", SqlDbType.VarChar).Value = textBox_nombreContacto.Text;
                    procedure.Parameters.AddWithValue("@rubro_codigo_prov", SqlDbType.Int).Value = id_rubro;
                    procedure.Parameters.AddWithValue("@direc_codigo_prov", SqlDbType.Int).Value = id_direccion;

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

        /// ////////////////////////////////////////////////////////////////////////////////

        private SqlConnection ConnectionWithDatabase()
        {
            string connectionString;
            SqlConnection connection;

            connectionString = @"Data Source=.\SQLSERVER2012;Initial Catalog = GD2C2019;User ID=sa;Password=gestiondedatos";

            connection = new SqlConnection(connectionString);

            return connection;

        }

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

                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                bd.desconectar();
            }


            return codigo_direccion;
            

        }

        private int obtener_usuario(String username)
        {
            SqlConnection connection = ConnectionWithDatabase();
            connection.Open();

            String query_select_usuario_id = "SELECT usuario_codigo FROM S_QUERY.Usuario WHERE usuario_nombre = '" + username + "'";
            SqlDataAdapter sda_select = new SqlDataAdapter(query_select_usuario_id, connection);
            DataTable data_usuario = new DataTable();

            sda_select.Fill(data_usuario);

            connection.Close();



            return (int)data_usuario.Rows[0].ItemArray[0];

        }

        /// ////////////////////////////////////////////////////////////////////////////////
        /// 


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

            return (int)data_direccion.Rows[0].ItemArray[0];
        }

        /// ////////////////////////////////////////////////////////////////////////////////
        /// 


        private int obtener_rubro(String rubro_nombre)
        {
            SqlConnection connection = ConnectionWithDatabase();
            connection.Open();

            String query_select_rubro_id = "SELECT rubro_codigo FROM S_QUERY.Rubro WHERE rubro_nombre = '"
                + rubro_nombre + "'";

            SqlDataAdapter sda_select = new SqlDataAdapter(query_select_rubro_id, connection);
            DataTable data_rubro = new DataTable();

            sda_select.Fill(data_rubro);

            connection.Close();

            return (int)data_rubro.Rows[0].ItemArray[0];

        }

        /// ////////////////////////////////////////////////////////////////////////////////
        /// 


        private void textBox_razonSocial_TextChanged(object sender, EventArgs e)
        {

        }

        /// ////////////////////////////////////////////////////////////////////////////////
        /// 

        private void cargarSelectorRubro()
        {
            SqlConnection connection = ConnectionWithDatabase();

            String query_obtenerRubros = "SELECT rubro_codigo, rubro_nombre FROM S_QUERY.Rubro";
            SqlDataAdapter sda = new SqlDataAdapter(query_obtenerRubros, connection);

            try
            {
                connection.Open();
                sda.Fill(tabla_rubros);

            }

            catch (SqlException se)
            {
                MessageBox.Show("An error occured while connecting to database" + se.ToString());
            }




            comboBox_rubro.DataSource = tabla_rubros;
            comboBox_rubro.DisplayMember = "rubro_nombre";
            comboBox_rubro.ValueMember = "rubro_nombre";

            connection.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button_limpiar_Click(object sender, EventArgs e)
        {
            textBox_calle.Clear();
            textBox_ciudad.Clear();
            textBox_codigoPostal.Clear();
            textBox_cuit.Clear();
            textBox_departamento.Clear();
            textBox_localidad.Clear();
            textBox_mail.Clear();
            textBox_nombreContacto.Clear();
            textBox_numero.Clear();
            textBox_numero_piso.Clear();
            textBox_razonSocial.Clear();
            textBox_telefono.Clear();
            comboBox_rubro.SelectedItem = null;
        }

    }
}
