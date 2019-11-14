using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas2.CargaCredito
{
    public partial class CargarCredito : Form
    {
        SqlDataAdapter generico = new SqlDataAdapter();
        private DataTable tabla_tipoDePago = new DataTable();

        public CargarCredito()
        {
            InitializeComponent();
            cargar_comboBox_tipoDePago();
        }

        private void button_terminar_Click(object sender, EventArgs e)
        {
            SqlConnection connection = ConnectionWithDatabase();
            connection.Open();

            String clie_codigo = this.obtenerClienteCodigo();
            String tipo_pago_codigo = this.obtenerTipoPagoCodigo(comboBox_tipoDePago.SelectedValue.ToString());

            String query_insert_cargaCredito = "INSERT INTO S_QUERY.Carga(carga_fecha, carga_monto, clie_codigo, tarjeta_numero, tipo_pago_codigo) " +
                "VALUES('" + label_fechaAUsar + "', " 
                + textBox_monto.Text.ToString() + ", " 
                + label_codigoCliente.ToString() + ", " 
                + textBox_numeroTarjeta.ToString() + ", "
                + tipo_pago_codigo + ")";

            generico.InsertCommand = new SqlCommand(query_insert_cargaCredito, connection);

            int a = generico.InsertCommand.ExecuteNonQuery();
            if (a == -1)
            {
                generico.InsertCommand.Cancel();
                MessageBox.Show("Fallo al ingresar la carga");
            }

            generico.InsertCommand.Dispose();

            String query_insert_tarjeta = "INSERT INTO S_QUERY.Tarjeta(tarjeta_numero, clie_numero, tarjeta_fecha_vencimiento, tarjeta_codigo_seguridad) VALUES(" +
                textBox_numeroTarjeta.ToString() + ", " 
                + clie_codigo + ", '"
                + dateTimePicker_fechaVencimientoTarjeta.Value.ToString() + "', "
                + textBox_codigoSeguridadTarjeta.ToString() + ")";

            generico.InsertCommand = new SqlCommand(query_insert_tarjeta, connection);

            a = generico.InsertCommand.ExecuteNonQuery();
            if (a == -1)
            {
                generico.InsertCommand.Cancel();
                MessageBox.Show("Fallo al ingresar la carga");
            }

            generico.InsertCommand.Dispose();
        }

        private string obtenerTipoPagoCodigo(Func<string> func)
        {
            throw new NotImplementedException();
        }


        private void cargar_comboBox_tipoDePago()
        {
            SqlConnection connection = ConnectionWithDatabase();

            String query_obtenerTiposDePago = "SELECT tipo_pago_codigo, tipo_pago_nombre FROM S_QUERY.Tipo_Pago";
            SqlDataAdapter sda = new SqlDataAdapter(query_obtenerTiposDePago, connection);

            try
            {
                connection.Open();
                sda.Fill(tabla_tipoDePago);

            }

            catch (SqlException se)
            {
                MessageBox.Show("An error occured while connecting to database" + se.ToString());
            }




            comboBox_tipoDePago.DataSource = tabla_tipoDePago;
            comboBox_tipoDePago.DisplayMember = "tipo_pago_nombre";
            comboBox_tipoDePago.ValueMember = "tipo_pago_nombre";

            connection.Close();
        }

        private String obtenerTipoPagoCodigo(String tipoPago)
        {
            SqlConnection connection = ConnectionWithDatabase();
            connection.Open();

            String query_select_tipoPago_id = "SELECT tipo_pago_codigo FROM S_QUERY.Tipo_Pago WHERE tipo_pago_nombre = '" + tipoPago + "'";
            SqlDataAdapter sda_select = new SqlDataAdapter(query_select_tipoPago_id, connection);
            DataTable data_tipoPago = new DataTable();

            sda_select.Fill(data_tipoPago);

            connection.Close();



            return data_tipoPago.Rows[0].ItemArray[0].ToString();
        }

        private String obtenerClienteCodigo()
        {
            return "1";
        }

        private SqlConnection ConnectionWithDatabase()
        {
            string connectionString;
            SqlConnection connection;

            connectionString = @"Data Source=.\SQLSERVER2012;Initial Catalog = GD2C2019;User ID=sa;Password=gestiondedatos";

            connection = new SqlConnection(connectionString);

            return connection;

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

    }
}
