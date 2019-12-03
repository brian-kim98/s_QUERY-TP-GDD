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

namespace FrbaOfertas2.ComprarOferta
{
    public partial class ListaOfertas : Form
    {

        DateTime fechaCompra;
        BaseDeDato bd = new BaseDeDato();
        CompraOferta formAnterior;

        public ListaOfertas(DateTime fechaCompraOferta, CompraOferta formCompraAnterior)
        {
            formAnterior = formCompraAnterior;
            fechaCompra = fechaCompraOferta;
            InitializeComponent();
            this.cargarDataOfertas();
        }

        private void cargarDataOfertas()
        {
            bd.conectar();

            String query_select_ofertas = "SELECT oferta_codigo,  oferta_descripcion, oferta_precio, oferta_precio_lista FROM S_QUERY.Oferta WHERE oferta_fecha <= '" + fechaCompra.ToString("yyyy/MM/dd") + "' AND oferta_fecha_vencimiento >= '" + fechaCompra.ToString("yyyy/MM/dd") + "'";

            SqlCommand comando = new SqlCommand(query_select_ofertas, bd.obtenerConexion());

            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;

            this.cargarDataGridClientes(adaptador);



            bd.desconectar();
        }

        private void cargarDataGridClientes(SqlDataAdapter adaptador)
        {

            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);

            dataGridView_ofertas.DataSource = tabla;

        }

        private void ListaOfertas_Load(object sender, EventArgs e)
        {

        }

        private void button_seleccionar_Click(object sender, EventArgs e)
        {
            Oferta nuevaOferta = this.crearOferta();
            formAnterior.cargaOfertaSeleccionada(nuevaOferta);
            this.Close();
        }

        private Oferta crearOferta()
        {
                int row_index = dataGridView_ofertas.CurrentCell.RowIndex;
                String row_codigo_Oferta = dataGridView_ofertas.CurrentRow.Cells["oferta_codigo"].Value.ToString();


                bd.conectar();

                SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM S_QUERY.Oferta WHERE oferta_codigo = @Id", bd.obtenerConexion());
                cmd.Parameters.AddWithValue("@Id", (int)Convert.ToInt32(row_codigo_Oferta));

                SqlDataReader dr = cmd.ExecuteReader();

                dr.Read();

                Oferta nuevoOferta = new Oferta(
                      dr["oferta_descripcion"].ToString(),
                      dr["oferta_precio"].ToString(),
                      dr["oferta_precio_lista"].ToString(),
                      dr["oferta_codigo"].ToString(),
                       int.Parse(dr["oferta_maximo_compra"].ToString()),
                       int.Parse(dr["oferta_cantidad_disponible"].ToString()));

                bd.desconectar();

                return nuevoOferta;

            
        }

        private void button_buscar_Click(object sender, EventArgs e)
        {
            bd.conectar();

            String query_select_ofertas = "SELECT oferta_codigo,  oferta_descripcion, oferta_precio, oferta_precio_lista FROM S_QUERY.Oferta WHERE oferta_fecha <= '" + fechaCompra.ToString("yyyy/MM/dd") + "' AND oferta_fecha_vencimiento >= '" + fechaCompra.ToString("yyyy/MM/dd") + "'";


            if (this.chequearCamposNumericos())
            {
                if (!this.boxVacia(textBox_texto_libre))
                {

                    query_select_ofertas += " AND oferta_descripcion LIKE  '%" + textBox_texto_libre.Text.ToString() + "%' ";
                }

                if (!this.boxVacia(textBox_maximo))
                {

                    query_select_ofertas += " AND oferta_precio <  '" + textBox_maximo.Text.ToString() + "' ";
                }

                if (!this.boxVacia(textBox_minimo))
                {

                    query_select_ofertas += " AND oferta_precio >  '" + textBox_minimo.Text.ToString() + "' ";
                }


            }

            SqlCommand comando = new SqlCommand(query_select_ofertas, bd.obtenerConexion());

            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;

            this.cargarDataGridClientes(adaptador);

            bd.desconectar();
        }

        private bool chequearCamposNumericos()
        {


            if (!this.esUnCampoNumerico(textBox_maximo) || !this.esUnCampoNumerico(textBox_minimo))
            {

                MessageBox.Show("Hay campos numericos erroneos.");
                return false;
            }
            else
            {
                return this.estanEnOrdenMaxMin();
            }


        }

        private bool boxVacia(TextBox box)
        {
            return box.Text.ToString() == "";
        }


        private bool estanEnOrdenMaxMin()
        {

            if (this.boxVacia(textBox_minimo) || this.boxVacia(textBox_maximo))
            {
                return true;
            }

            if (int.Parse(textBox_minimo.Text) > int.Parse(textBox_maximo.Text))
            {
                MessageBox.Show("El campo Maximo es menor que el Minimo.");
                return false;
            }

            return true;
        }

        private bool esUnCampoNumerico(TextBox casilla_texto)
        {

            if (casilla_texto.Text.ToString() == "") { return true; }


            double valorDouble = 0.0;

            float valorFloat = (float)valorDouble;

            bool respuesta = float.TryParse(casilla_texto.Text, out valorFloat);

            if (!respuesta)
            {
                casilla_texto.BackColor = SystemColors.ControlDark;
            }



            return respuesta;

        }

        private void button_limpiar_Click(object sender, EventArgs e)
        {
            textBox_maximo.Clear();
            textBox_minimo.Clear();
            textBox_texto_libre.Clear();
        }

    }
}

