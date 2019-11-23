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

            BaseDeDato bd = new BaseDeDato();
            bd.conectar();
            String cuponesEntreIntervalos =
                "SELECT cupon_codigo, clie_nombre, clie_apellido FROM S_QUERY.Cupon cup JOIN " 
                + "Cliente cl ON cup.clie_codigo = cl.clie_codigo "
                + "WHERE cupon_fecha BETWEEN '" + dateTimePicker_fechaInicio.Text.ToString() 
                + "' AND '" 
                + dateTimePicker_fechaFin.Text.ToString() + "' AND prov_codigo = "
                + dt.Rows[comboBox_proveedores.SelectedIndex].Field<int>(0).ToString();
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
    }
}
