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
        int codigo_cliente;

        public CargarCredito(int codigo_usuario)
        {
            InitializeComponent();
            codigo_cliente = this.buscarCodigoCliente(codigo_usuario);
            this.cargar_valores();

        }

        private void cargar_valores() {
            label_fecha_hoy.Text = DateTime.Today.ToString("dd-MM-yyyy");
            label_codigo_cliente.Text = codigo_cliente.ToString();
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

        private void button_cargar_Click(object sender, EventArgs e)
        {
            if (!this.esUnCampoNumerico(textBox_monto))
            {
                MessageBox.Show("Ingrese un monto numerico.");
                textBox_monto.BackColor = Color.IndianRed;
            }
            else
            {

                //ACA FALTARIA AGARRAR EL PROCEDURE Y HACERLO; PERO NO TENGO NADA PARA PROBARLO POR NO TENER CLIENTES; VOY A TERMINAR ESA PARTE PRIMERO


            }





        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////


        private int buscarCodigoCliente(int codigoUsuario)
        {
            int codigo_encontrado;

            using (SqlConnection connection = ConnectionWithDatabase())
            {
                connection.Open();

                String query_buscar_codigo_cliente = "SELECT clie_codigo FROM S_QUERY.Cliente WHERE usuario_codigo = '" +
                    codigoUsuario.ToString() + "'";
                SqlDataAdapter sda_select = new SqlDataAdapter(query_buscar_codigo_cliente, connection);
                DataTable data_cliente = new DataTable();

                sda_select.Fill(data_cliente);

                codigo_encontrado = int.Parse(data_cliente.Rows[0].ItemArray[0].ToString());


            }

            return codigo_encontrado;
        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////

        private bool esUnCampoNumerico(TextBox casilla_texto)
        {

            double valorDouble = 0.0;

            float valorFloat = (float)valorDouble;

            bool respuesta = float.TryParse(casilla_texto.Text, out valorFloat);

            return respuesta;

        }


    }
}
