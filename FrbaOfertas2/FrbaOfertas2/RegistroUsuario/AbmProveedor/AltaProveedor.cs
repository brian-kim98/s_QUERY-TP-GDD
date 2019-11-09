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

namespace FrbaOfertas2.RegistroUsuario.AbmProveedor
{
    public partial class AltaProveedor : Form
    {
        public String registrarUsuario_TextBox_username;
        SqlDataAdapter generico = new SqlDataAdapter();

        public AltaProveedor(String username)
        {
            InitializeComponent();
            registrarUsuario_TextBox_username = username;

            int prueba = this.obtener_usuario(username);

            MessageBox.Show(prueba.ToString());
        }

        private void button_crear_Click(object sender, EventArgs e)
        {
            this.crear_direccion();

            int id_usuario = this.obtener_usuario(registrarUsuario_TextBox_username);
            int id_direccion = this.obtener_direccion(textBox_localidad.Text.ToString(), textBox_calle.Text.ToString(), int.Parse(textBox_numero.Text), Int16.Parse(textBox_numero_piso.Text), Int16.Parse(textBox_departamento.Text));

            SqlConnection connection = ConnectionWithDatabase();
            connection.Open();
            String query_insert_rol_nuevo = "INSERT INTO S_QUERY.Proveedor(prov_razon_social, prov_cuit, prov_mail, prov_ciudad, prov_telefono, prov_nombre_contacto, prov_habilitado, rubro_codigo, direc_codigo, usuario_codigo)" +
                " VALUES('" + textBox_razonSocial.Text.ToString() +
                "', '" + textBox_cuit.Text.ToString() +
                ", '" + textBox_mail.Text.ToString() +
                "', '" + textBox_ciudad.Text.ToString() +
                "', " + int.Parse(textBox_telefono.Text) +
                ", '" + textBox_nombreContacto.Text.ToString() +
                "', '" + dateTimePicker_fecha_nacimiento.Value.ToString() +
                "', 1, " + id_direccion + ", " + id_usuario + ")";
            generico.InsertCommand = new SqlCommand(query_insert_rol_nuevo, connection);
            MessageBox.Show("llega");
            int a = generico.InsertCommand.ExecuteNonQuery();
            if (a == -1)
            {
                generico.InsertCommand.Cancel();
            }
            generico.InsertCommand.Dispose();
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

        private void crear_direccion()
        {
            SqlConnection connection = ConnectionWithDatabase();
            connection.Open();

            String query_insert_direccion_nuevo = "INSERT INTO S_QUERY.Direccion(direc_localidad, direc_calle , direc_nro, direc_piso, direc_depto) VALUES('" + textBox_localidad.Text.ToString() + "', '"
                + textBox_calle.Text.ToString() + "', "
                + int.Parse(textBox_numero.Text) + ", "
                + Int16.Parse(textBox_numero_piso.Text) + ", "
                + Int16.Parse(textBox_departamento.Text) + ")"; //despues cambiar la contra a encriptacion
            //SqlDataAdapter sda_insert = new SqlDataAdapter(query_insert_rol, connection);
            generico.InsertCommand = new SqlCommand(query_insert_direccion_nuevo, connection);

            int a = generico.InsertCommand.ExecuteNonQuery();
            if (a == -1)
            {
                generico.InsertCommand.Cancel();
                MessageBox.Show("Fallo al ingresar el usuario");
            }

            generico.InsertCommand.Dispose();
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

        private int obtener_rubro()
        {
            return 0;
        }

        /// ////////////////////////////////////////////////////////////////////////////////
    }
}
