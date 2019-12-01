using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas2.Facturar
{
    public partial class ListadoFacturacionGenerada : Form
    {
        private DataTable tabla = new DataTable();
        private FacturacionAProveedor origen;

        public ListadoFacturacionGenerada(DataTable tablaAMostrar, FacturacionAProveedor form)
        {
            InitializeComponent();
            tabla = tablaAMostrar;
            origen = form;

        }

        private void ListadoFacturacionGenerada_Load(object sender, EventArgs e)
        {
            dataGridView_listado.DataSource = tabla;
        }

        private void dataGridView_listado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_generar_Click(object sender, EventArgs e)
        {
            this.Close();
            origen.confirmacionGeneracion();

        }
    }
}
