using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas2.Clases;
using System.Data.SqlClient;

namespace FrbaOfertas2.EntregaOferta
{
    public partial class EntregarOferta : Form
    {
        public EntregarOferta()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button_volver_Click(object sender, EventArgs e)
        {

        }

        private void button_finalizar_Click(object sender, EventArgs e)
        {
            if (!this.todosLosCamposEstanCompletos())
            {
                MessageBox.Show("Complete todos los campos");
                return;
            }

            BaseDeDato bd = new BaseDeDato();

            bd.conectar();

            SqlCommand procedure = Clases.BaseDeDato.crearConsulta("S_QUERY.ingresarEntregaOferta");
            procedure.CommandType = CommandType.StoredProcedure;
            procedure.Parameters.AddWithValue("@entrega_fecha", SqlDbType.DateTime).Value = dateTimePicker_fechaConsumo.Text;
            procedure.Parameters.AddWithValue("@cupon_codigo", SqlDbType.Int).Value = textBox_codigoCupon.Text;
            procedure.Parameters.AddWithValue("@clie_codigo", SqlDbType.Int).Value = textBox_cliente.Text;
            bd.ejecutarConsultaSinResultado(procedure);

            textBox_codigoCupon.Enabled = false;
            textBox_cliente.Enabled = false;
            dateTimePicker_fechaConsumo.Enabled = false;
        }

        private bool todosLosCamposEstanCompletos()
        {
            return textBox_cliente.Text != "" && textBox_codigoCupon.Text != "" && dateTimePicker_fechaConsumo.Text != "";
        }

        private void button_limpiar_Click(object sender, EventArgs e)
        {
            textBox_cliente.Clear();
            textBox_codigoCupon.Clear();
            dateTimePicker_fechaConsumo.ResetText();
            textBox_codigoCupon.Enabled = true;
            textBox_cliente.Enabled = true;
            dateTimePicker_fechaConsumo.Enabled = true;
        }
    }
}
