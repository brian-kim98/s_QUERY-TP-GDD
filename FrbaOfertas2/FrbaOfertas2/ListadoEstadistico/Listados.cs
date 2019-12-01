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



            if(this.camposCompletos() && this.camposNumericosCorrectos()){

                BaseDeDato bd = new BaseDeDato();
                bd.conectar();

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
       
                    command.Parameters.Add(semestre);
                    command.Parameters.Add(anio);

                    adapter.SelectCommand = command;

                    DataTable salida = new DataTable();

                    adapter.Fill(salida);
                   
                    dataGridView1.DataSource = salida;
                }
                else if (comboBox_tipoListado.SelectedItem.ToString() == "Mayor porcentaje descuento ofrecido en las ofertas")
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    SqlCommand command = new SqlCommand("SELECT * FROM S_QUERY.TOP5_PROVEEDORES_MAYOR_DESCUENTO_OFRECIDO_EN_OFERTAS(@ANIO, @MES)", bd.obtenerConexion());
                    SqlParameter semestre = new SqlParameter("@MES", SqlDbType.Int);
                    if (comboBox_semestre.SelectedItem.ToString() == "Primer Semestre")
                    { semestre.Value = 1; }
                    else
                    { semestre.Value = 7; }

                    SqlParameter anio = new SqlParameter("@ANIO", SqlDbType.Int);
                    anio.Value = int.Parse(textBox1_anio.Text);

                    command.Parameters.Add(semestre);
                    command.Parameters.Add(anio);

                    adapter.SelectCommand = command;

                    DataTable salida = new DataTable();

                    adapter.Fill(salida);

                    dataGridView1.DataSource = salida;
                }

                bd.desconectar();
            }
            else
            {

                

            }
        }

        private bool camposNumericosCorrectos()
        {

            if (this.esUnCampoNumerico(textBox1_anio))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Campos Numericos Incorrectos");
                return false;

            }
        }

        private bool camposCompletos()
        {
            if (!this.estaVacio(comboBox_tipoListado) && !this.estaVacio(comboBox_semestre) && textBox1_anio.Text.ToString() != "")
            {
                return true;
            }
            else
            {
                MessageBox.Show("Debe Completar todos los campos.");
                return false;
            }
        }

        private bool estaVacio(ComboBox combo)
        {
            return combo.Text.ToString().Equals("");
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

        private void button_volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_semestre_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_limpiar_Click(object sender, EventArgs e)
        {
            textBox1_anio.Clear();
            comboBox_tipoListado.Text = "";
            comboBox_semestre.Text = "";
        }

        private bool esUnCampoNumerico(TextBox casilla_texto)
        {

            double valorDouble = 0.0;

            float valorFloat = (float)valorDouble;

            bool respuesta = float.TryParse(casilla_texto.Text, out valorFloat);

            if (!respuesta)
            {
                casilla_texto.BackColor = SystemColors.ControlDark;
            }

            return respuesta;

        }
    }
}
