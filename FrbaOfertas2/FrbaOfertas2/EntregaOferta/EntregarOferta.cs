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
        int codigo_user;

        public EntregarOferta(int codigo_usuario)
        {
            InitializeComponent();
            codigo_user = codigo_usuario;
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
            procedure.Parameters.AddWithValue("@entrega_fecha", SqlDbType.DateTime).Value = dateTimePicker_fechaConsumo.Value;
            procedure.Parameters.AddWithValue("@cupon_codigo", SqlDbType.Int).Value = textBox_codigoCupon.Text;

            procedure.Parameters.AddWithValue("@usuario_codigo", SqlDbType.Int).Value = this.codigo_user;
            procedure.Parameters.Add("@ReturnVal", SqlDbType.Int);
            procedure.Parameters["@ReturnVal"].Direction = ParameterDirection.ReturnValue;
            procedure.ExecuteNonQuery();

            int resultado = Int32.Parse(procedure.Parameters["@ReturnVal"].Value.ToString());

            bd.desconectar();

            switch (resultado)
            {
                case 1:
                    MessageBox.Show("Se ha consumido correctamente");
                    break;
                case 2:
                    MessageBox.Show("No se puede consumir 2 veces");
                    break;
                case 3:
                    MessageBox.Show("Esta vencido este cupon");
                    break;
                case 4:
                    MessageBox.Show("No existe el cupon o no le pertenece al proveedor");
                    break;
            }

        }

        private bool todosLosCamposEstanCompletos()
        {
            return  textBox_codigoCupon.Text != "" && dateTimePicker_fechaConsumo.Text != "";
        }

        private void button_limpiar_Click(object sender, EventArgs e)
        {
           
            textBox_codigoCupon.Clear();
            dateTimePicker_fechaConsumo.ResetText();
            textBox_codigoCupon.Enabled = true;
       
            dateTimePicker_fechaConsumo.Enabled = true;
        }
    }
}
