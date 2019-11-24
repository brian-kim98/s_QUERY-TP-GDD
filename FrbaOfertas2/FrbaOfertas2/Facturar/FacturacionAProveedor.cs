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

            MessageBox.Show(dateTimePicker_fechaInicio.Text);
            MessageBox.Show(dateTimePicker_fechaFin.Text);
            MessageBox.Show(dt.Rows[comboBox_proveedores.SelectedIndex]["prov_codigo"].ToString());

            BaseDeDato bd = new BaseDeDato();
            bd.conectar();
            String cuponesEntreIntervalos =
                "SELECT cup.cupon_codigo, cl.clie_nombre, cl.clie_apellido FROM S_QUERY.Cupon cup JOIN "
                + "S_QUERY.Cliente cl ON cl.clie_codigo = cup.clie_codigo "
                + "JOIN S_QUERY.Oferta ofer ON ofer.oferta_codigo = cup.oferta_codigo "
                + "WHERE (cup.cupon_fecha BETWEEN '" + dateTimePicker_fechaInicio.Text
                + "' AND '"
                + dateTimePicker_fechaFin.Text + "') AND ofer.prov_codigo = "
                + dt.Rows[comboBox_proveedores.SelectedIndex]["prov_codigo"].ToString();
            MessageBox.Show(cuponesEntreIntervalos);
            SqlDataAdapter adapter = new SqlDataAdapter(cuponesEntreIntervalos, bd.obtenerConexion());
            DataTable tablaFinal = new DataTable();
            adapter.Fill(tablaFinal);

            ListadoFacturacionGenerada listado = new ListadoFacturacionGenerada(tablaFinal);
            listado.Show();


            
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
    }
}
