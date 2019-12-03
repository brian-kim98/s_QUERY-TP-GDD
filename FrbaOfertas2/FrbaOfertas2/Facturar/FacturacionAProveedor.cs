using FrbaOfertas2.Clases;
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
using System.Configuration;

namespace FrbaOfertas2.Facturar
{
    public partial class FacturacionAProveedor : Form
    {
        private DataTable dt = new DataTable();

        public FacturacionAProveedor()
        {
            InitializeComponent();
        }

        private void button_generar_Click(object sender, EventArgs e)
        {
            if (!this.estanTodosLosCamposCompletos())
            {

            }

            dateTimePicker_fechaFin.Enabled = false;
            dateTimePicker_fechaInicio.Enabled = false;
            comboBox_proveedores.Enabled = false;

            dateTimePicker_fechaInicio.Format = DateTimePickerFormat.Custom;
            dateTimePicker_fechaFin.Format = DateTimePickerFormat.Custom;

            BaseDeDato bd = new BaseDeDato();

            try
            {
                bd.conectar();
/*
                String cuponesEntreIntervalos =
                    "SELECT cup.cupon_codigo, cl.clie_nombre, cl.clie_apellido FROM S_QUERY.Cupon cup JOIN "
                    + "S_QUERY.Cliente cl ON cl.clie_codigo = cup.clie_codigo "
                    + "JOIN S_QUERY.Oferta ofer ON ofer.oferta_codigo = cup.oferta_codigo "
                    + "WHERE (cup.cupon_fecha BETWEEN '" + dateTimePicker_fechaInicio.Text
                    + "' AND '"
                    + dateTimePicker_fechaFin.Text + "') AND ofer.prov_codigo = "
                    + dt.Rows[comboBox_proveedores.SelectedIndex]["prov_codigo"].ToString();
 */
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand("SELECT * FROM S_QUERY.FACTURACION_PROVEEDOR(@PROVEEDOR, @INICIO, @FIN)", bd.obtenerConexion());
                SqlParameter proveedor = new SqlParameter("@PROVEEDOR", SqlDbType.Int);
                proveedor.Value = int.Parse(dt.Rows[comboBox_proveedores.SelectedIndex]["prov_codigo"].ToString());
                SqlParameter periodoInicio = new SqlParameter("@INICIO", SqlDbType.DateTime);
                periodoInicio.Value = dateTimePicker_fechaInicio.Value;
                SqlParameter periodoFin = new SqlParameter("@FIN", SqlDbType.DateTime);
                periodoFin.Value = dateTimePicker_fechaFin.Value;

                command.Parameters.Add(proveedor);
                command.Parameters.Add(periodoInicio);
                command.Parameters.Add(periodoFin);

                adapter.SelectCommand = command;

                DataTable tablaFinal = new DataTable();
                adapter.Fill(tablaFinal);

                bd.desconectar();

                ListadoFacturacionGenerada listado = new ListadoFacturacionGenerada(tablaFinal, this);
                listado.Show();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                bd.desconectar();
            }

            

            //creo que falta cerrar la base de datos.
            
        }

        private bool estanTodosLosCamposCompletos()
        {
            return true;
        }

        private void cargar_comboBox_proveedores()
        {
            BaseDeDato bd = new BaseDeDato();
            bd.conectar();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT prov_razon_social, prov_codigo FROM S_QUERY.Proveedor", bd.obtenerConexion());
            adapter.Fill(dt);
            comboBox_proveedores.DataSource = dt;
            comboBox_proveedores.ValueMember = "prov_razon_social";
            comboBox_proveedores.DisplayMember = "prov_razon_social";
            bd.desconectar();
        }

        private void comboBox_proveedores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FacturacionAProveedor_Load(object sender, EventArgs e)
        {
            cargar_comboBox_proveedores();
        }

        private void dateTimePicker_fechaFin_ValueChanged(object sender, EventArgs e)
        {

        }

        public void confirmacionGeneracion()
        {
            BaseDeDato bd = new BaseDeDato();

            try
            {
                bd.conectar();
                SqlCommand procedure = Clases.BaseDeDato.crearConsulta("S_QUERY.GENERAR_FACTURACION");
                procedure.CommandType = CommandType.StoredProcedure;
                procedure.Parameters.AddWithValue("@FECHA", SqlDbType.DateTime).Value = ConfigurationManager.AppSettings["fechaConfiguracion"].ToString();
                procedure.Parameters.AddWithValue("@INICIO", SqlDbType.DateTime).Value = dateTimePicker_fechaInicio.Value;
                procedure.Parameters.AddWithValue("@FIN", SqlDbType.DateTime).Value = dateTimePicker_fechaFin.Value;
                procedure.Parameters.AddWithValue("@PROVEEDOR", SqlDbType.Int).Value = int.Parse(dt.Rows[comboBox_proveedores.SelectedIndex]["prov_codigo"].ToString());
                procedure.ExecuteNonQuery();
                bd.desconectar();
                MessageBox.Show("Se ha generado con éxito");
                this.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                bd.desconectar();
            }
            


            
        }

        private void button_limpiar_Click(object sender, EventArgs e)
        {
            dateTimePicker_fechaInicio.ResetText();
            dateTimePicker_fechaFin.ResetText();
            comboBox_proveedores.SelectedItem = null;
        }

        private void button_volver_Click(object sender, EventArgs e)
        {

        }
    }
}
