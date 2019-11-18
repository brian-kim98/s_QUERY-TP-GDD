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
        public FacturacionAProveedor()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!this.estanTodosLosCamposCompletos())
            {

            }

            BaseDeDato bd = new BaseDeDato();
            bd.conectar();
            String cuponesEntreIntervalos =
                "SELECT cupon_codigo FROM S_QUERY.Cupon WHERE cupon_fecha BETWEEN '" +
                dateTimePicker_fechaInicio.Text + "' AND '" + dateTimePicker_fechaFin.Text + "'"
                ;
            SqlDataAdapter adapter = new SqlDataAdapter(" ", bd.obtenerConexion());
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            
        }

        private bool estanTodosLosCamposCompletos()
        {

        }

        private void cargar_comboBox_proveedores()
        {
            BaseDeDato bd = new BaseDeDato();
            bd.conectar();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT prov_razon_social FROM S_QUERY.Proveedor", bd.obtenerConexion());
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            comboBox_proveedores.DataSource = dt;
            comboBox_proveedores.ValueMember = "prov_razon_social";
            comboBox_proveedores.DisplayMember = "prov_razon_social";
            bd.desconectar();
        }

        private void comboBox_proveedores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
