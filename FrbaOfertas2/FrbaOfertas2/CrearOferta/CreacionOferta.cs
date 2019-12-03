using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using FrbaOfertas2.Clases;

namespace FrbaOfertas2.CrearOferta
{
    public partial class CreacionOferta : Form
    {

        private BaseDeDato bd = new BaseDeDato();
        SqlDataAdapter adapter;
        int codigo_proveedor;
        int codigo_user;

        public CreacionOferta(int user_codigo)
        {
            InitializeComponent();
            codigo_user = user_codigo;
        }

        public CreacionOferta()
        {
            InitializeComponent();
            codigo_user = 0;
            textBox_codigoProveedor.Visible = true;
            label_codigoProveedor.Visible = true;
        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBox_descripcion_TextChanged(object sender, EventArgs e)
        {

        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////

        private void CrearOferta_Load(object sender, EventArgs e)
        {

        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////

        private void button_crear_Click(object sender, EventArgs e)
        {
            

            if(this.todosLosCamposEstanCompletos()){

                //textBox_nombre.Enabled = false;
                BaseDeDato bd = new BaseDeDato();

                if (this.codigo_user != 0)
                {
                    try
                    {
                        bd.conectar();
                        SqlCommand procedure = Clases.BaseDeDato.crearConsulta("S_QUERY.insertarOfertaNueva");
                        procedure.CommandType = CommandType.StoredProcedure;
                        procedure.Parameters.AddWithValue("@oferta_descripcion", SqlDbType.VarChar).Value = textBox_descripcion.Text;
                        procedure.Parameters.AddWithValue("@oferta_fecha", SqlDbType.DateTime).Value = dateTimePicker_fecha_publicacion.Value;
                        procedure.Parameters.AddWithValue("@oferta_fecha_vencimiento", SqlDbType.DateTime).Value = dateTimePicker_fecha_vencimiento.Value;
                        procedure.Parameters.AddWithValue("@oferta_precio", SqlDbType.Float).Value = (float)Convert.ToDouble(textBox_precio_oferta.Text);
                        procedure.Parameters.AddWithValue("@oferta_precio_lista", SqlDbType.Float).Value = (float)Convert.ToDouble(textBox_precio_lista.Text);
                        procedure.Parameters.AddWithValue("@oferta_cantidad_disponible", SqlDbType.Int).Value = (int)Convert.ToInt32(textBox_cantidad.Text);
                        procedure.Parameters.AddWithValue("@oferta_maximo_compra", SqlDbType.Int).Value = (int)Convert.ToInt32(textBox_maximo_compra.Text);
                        procedure.Parameters.AddWithValue("@user_codigo", SqlDbType.Int).Value = codigo_user;

                        procedure.ExecuteNonQuery();

                        bd.desconectar();
                        MessageBox.Show("Oferta ingresada con exito!");
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        bd.desconectar();
                    }
                }

                else
                {
                    bd.conectar();
                    SqlCommand procedure = Clases.BaseDeDato.crearConsulta("S_QUERY.insertarOfertaNueva");
                    procedure.CommandType = CommandType.StoredProcedure;
                    procedure.Parameters.AddWithValue("@oferta_descripcion", SqlDbType.VarChar).Value = textBox_descripcion.Text;
                    procedure.Parameters.AddWithValue("@oferta_fecha", SqlDbType.DateTime).Value = dateTimePicker_fecha_publicacion.Value;
                    procedure.Parameters.AddWithValue("@oferta_fecha_vencimiento", SqlDbType.DateTime).Value = dateTimePicker_fecha_vencimiento.Value;
                    procedure.Parameters.AddWithValue("@oferta_precio", SqlDbType.Float).Value = (float)Convert.ToDouble(textBox_precio_oferta.Text);
                    procedure.Parameters.AddWithValue("@oferta_precio_lista", SqlDbType.Float).Value = (float)Convert.ToDouble(textBox_precio_lista.Text);
                    procedure.Parameters.AddWithValue("@oferta_cantidad_disponible", SqlDbType.Int).Value = (int)Convert.ToInt32(textBox_cantidad.Text);
                    procedure.Parameters.AddWithValue("@oferta_maximo_compra", SqlDbType.Int).Value = (int)Convert.ToInt32(textBox_maximo_compra.Text);
                    procedure.Parameters.AddWithValue("@user_codigo", SqlDbType.Int).Value = (int)Convert.ToInt32(textBox_codigoProveedor.Text);

                    procedure.ExecuteNonQuery();

                    bd.desconectar();
                    MessageBox.Show("Oferta ingresada con exito!");
                }

                

            }

            
        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////

        private void comboBox_proveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////

        private bool todosLosCamposEstanCompletos()
        {
            bool retorno = true;

            if( !this.esUnNumeroEntero(textBox_cantidad.Text.ToString()) || !this.esUnNumeroFloat(textBox_precio_oferta.Text) ||
                !this.esUnNumeroFloat(textBox_precio_lista.Text)  )
            {

                MessageBox.Show("Solo se permiten campos numericos en los precios y la cantidad");
                textBox_cantidad.BackColor = Color.Red;
                textBox_precio_lista.BackColor = Color.Red;
                textBox_precio_oferta.BackColor = Color.Red;

                retorno = false;
            }

            if (dateTimePicker_fecha_vencimiento.Value < dateTimePicker_fecha_publicacion.Value)
            {
                MessageBox.Show("La fecha de vencimiento debe ser mayor a la de publicacion");
                retorno = false;
            }


            if (textBox_descripcion.Text == ""
                 && textBox_precio_oferta.Text == ""
                 && textBox_precio_lista.Text == ""
                 && textBox_cantidad.Text == "")
            {
                MessageBox.Show("Debe completar todos los campos");
                retorno = false;
            }

            return retorno;
        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////

        private bool esUnNumeroEntero(String numeroString)
        {
            int valorNumerico = 0;
            bool respuesta =  int.TryParse(numeroString ,out valorNumerico);
         
            return respuesta;
        }

        private bool esUnNumeroFloat(String numeroString)
        {
            double valorDouble = 0.0;

            float valorFloat = (float)valorDouble;

            bool respuesta=  float.TryParse(numeroString, out valorFloat);

            return respuesta;
        }

        private void dateTimePicker_fecha_vencimiento_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button_limpiar_Click(object sender, EventArgs e)
        {
            textBox_descripcion.Clear();
            textBox_precio_lista.Clear();
            textBox_precio_oferta.Clear();
            textBox_cantidad.Clear();
            textBox_maximo_compra.Clear();
            dateTimePicker_fecha_publicacion.ResetText();
            dateTimePicker_fecha_vencimiento.ResetText();
        }


        /// //////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
