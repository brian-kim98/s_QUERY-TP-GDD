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

namespace FrbaOfertas2.CargaCredito
{
    public partial class CargarCredito : Form
    {

        private DataTable tabla_pagos = new DataTable();

        public CargarCredito()
        {
            InitializeComponent();
            this.cargar_valores();
        }

        private void cargar_valores() {
            label_fecha_hoy.Text = DateTime.Today.ToString("dd-MM-yyyy");
            this.carga_comboBox_tipo_pago();
        }


        private void carga_comboBox_tipo_pago()
        {
            SqlConnection connection = ConnectionWithDatabase();

            String query_obtenerPagos = "SELECT tipo_pago_codigo, tipo_pago_nombre FROM S_QUERY.Tipo_Pago";
            SqlDataAdapter sda = new SqlDataAdapter(query_obtenerPagos, connection);

            try
            {
                connection.Open();
                sda.Fill(tabla_pagos);

            }

            catch (SqlException se)
            {
                MessageBox.Show("An error occured while connecting to database" + se.ToString());
            }




            comboBox_tipo_pago.DataSource = tabla_pagos;
            comboBox_tipo_pago.DisplayMember = "tipo_pago_nombre";
            comboBox_tipo_pago.ValueMember = "tipo_pago_nombre";

            connection.Close();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_tipo_pago_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label_codigo_cliente_Click(object sender, EventArgs e)
        {

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

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////

    }
}
