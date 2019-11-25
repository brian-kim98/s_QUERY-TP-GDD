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

namespace FrbaOfertas2.ListadoEstadistico
{
    public partial class Listados : Form
    {
        public Listados()
        {
            InitializeComponent();
        }

        private void button_mostrar_Click(object sender, EventArgs e)
        {
            BaseDeDato bd = new BaseDeDato();
            bd.conectar();

            MessageBox.Show(comboBox_semestre.SelectedItem.ToString());

            if (comboBox_tipoListado.SelectedItem.ToString() == "Mayor facturacion")
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand("SELECT * FROM S_QUERY.TOP5_PROVEEDORES_MAYOR_FACTURACION(@ANIO, @MES)", bd.obtenerConexion());
                SqlParameter semestre = new SqlParameter("@MES", SqlDbType.Int);
                if (comboBox_semestre.SelectedItem.ToString() == "Primer Semestre")
                {semestre.Value = 1;}
                else
                {semestre.Value = 7;}
                
                SqlParameter anio = new SqlParameter("@ANIO", SqlDbType.Int);
                anio.Value = int.Parse(textBox1_anio.Text);

                MessageBox.Show(textBox1_anio.Text);
       
                command.Parameters.Add(semestre);
                command.Parameters.Add(anio);



                DataTable salida = new DataTable();
                salida = (DataTable)command.ExecuteScalar();

                dataGridView1.DataSource = salida;
            }
        }

        private void Listados_Load(object sender, EventArgs e)
        {
            comboBox_semestre.Items.Add("Primer Semestre");
            comboBox_semestre.Items.Add("Segundo Semestre");
            comboBox_tipoListado.Items.Add("Mayor porcentaje descuento ofrecido en las ofertas");
            comboBox_tipoListado.Items.Add("Mayor facturacion");

        }

        private void comboBox_tipoListado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
