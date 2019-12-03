using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using FrbaOfertas2.Clases;
using System.Data.SqlClient;

namespace FrbaOfertas2.ComprarOferta
{
    public partial class CompraOferta : Form
    {

        public string fechaConfiguracion = ConfigurationManager.AppSettings["fechaConfiguracion"];
        Oferta ofertaSelected;
        Cliente clienteRegistrado;
        BaseDeDato bd = new BaseDeDato();

        public CompraOferta(String codigo_usuario)
        {

            clienteRegistrado = this.crearCliente(codigo_usuario);
            
            InitializeComponent();
            textBox_cliente.Text = clienteRegistrado.nombre;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void CompraOferta_Load(object sender, EventArgs e)
        {

            dateTimePicker1.Value = DateTime.Parse(fechaConfiguracion);
 
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(ofertaSelected == null){
                MessageBox.Show("Debe Seleccionar una Oferta.");
                return;
            }


            if(this.chequearSaldo() && this.chequearDisponibilidad()){

                bd.conectar();

                SqlCommand procedure = Clases.BaseDeDato.crearConsulta("S_QUERY.comprarOferta");
                procedure.CommandType = CommandType.StoredProcedure;
                procedure.Parameters.AddWithValue("@cupon_fecha_compra", SqlDbType.Date).Value = dateTimePicker1.Value;
                procedure.Parameters.AddWithValue("@cupon_cantidad_compra", SqlDbType.Int).Value = numericUpDown_cantidad.Value;
                procedure.Parameters.AddWithValue("@clie_codigo_compra", SqlDbType.Int).Value = int.Parse(clienteRegistrado.id);
                procedure.Parameters.AddWithValue("@oferta_codigo_compra", SqlDbType.Int).Value = int.Parse(ofertaSelected.oferta_codigo);

                procedure.Parameters.Add("@ReturnVal", SqlDbType.Int);
                procedure.Parameters["@ReturnVal"].Direction = ParameterDirection.ReturnValue;
                procedure.ExecuteNonQuery();

                int codigo_cupon = Convert.ToInt32(procedure.Parameters["@ReturnVal"].Value);


                bd.desconectar();

                MessageBox.Show("Compraste el Cupón con codigo: " + codigo_cupon.ToString());

                this.Close();

            }
        }

        private bool chequearDisponibilidad()
        {
            if(numericUpDown_cantidad.Value > ofertaSelected.cantidadDisponible){
                
                MessageBox.Show("No hay esa cantidad de ofertas disponibles.");
                return false;
            }

            return true;
        }

        private bool chequearSaldo()
        {

            if(clienteRegistrado.saldo < int.Parse(label_precioTotal.Text.ToString())){
                MessageBox.Show("No tienes saldo suficiente.");
                return false;
            }

            return true;
        }

        private Cliente crearCliente(String id_Usuario)
        {
            bd.conectar();
            Cliente nuevoCliente = null;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM S_QUERY.Cliente WHERE usuario_codigo = @Id", bd.obtenerConexion());
                cmd.Parameters.AddWithValue("@Id", (int)Convert.ToInt32(id_Usuario));

                SqlDataReader dr = cmd.ExecuteReader();

                dr.Read();

                DateTime fecha_nac = DateTime.Parse(dr["clie_fecha_nacimiento"].ToString());

                 nuevoCliente = new Cliente(
                      dr["clie_codigo"].ToString(),
                      dr["clie_nombre"].ToString(),
                      dr["clie_apellido"].ToString(),
                      dr["clie_dni"].ToString(),
                      dr["clie_mail"].ToString(),
                      dr["clie_telefono"].ToString(),
                      fecha_nac,
                      bool.Parse(dr["clie_habilitado"].ToString()),
                      dr["direc_codigo"].ToString(),
                      int.Parse(dr["clie_saldo"].ToString()));
            }catch (Exception ex){
                MessageBox.Show(ex.Message);
            }


            bd.desconectar();

            return nuevoCliente;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListaOfertas ofertas = new ListaOfertas(dateTimePicker1.Value, this);
            ofertas.Show();
        }

        public void cargaOfertaSeleccionada(Oferta ofertaElegida)
        {
            textBox_oferta.Text = ofertaElegida.detalle;
            textBox_nroOferta.Text = ofertaElegida.oferta_codigo;
            numericUpDown_cantidad.Maximum = ofertaElegida.maximaCompra;
            label_precioTotal.Text = ofertaElegida.precio;

            ofertaSelected = ofertaElegida;
        }

        private void numericUpDown_cantidad_ValueChanged(object sender, EventArgs e)
        {
            int precioActualizado = int.Parse(numericUpDown_cantidad.Value.ToString()) * int.Parse(ofertaSelected.precio);
            label_precioTotal.Text = precioActualizado.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox_compratOfera_Enter(object sender, EventArgs e)
        {

        }

        private void label_precioTotal_Click(object sender, EventArgs e)
        {

        }
    }
}
