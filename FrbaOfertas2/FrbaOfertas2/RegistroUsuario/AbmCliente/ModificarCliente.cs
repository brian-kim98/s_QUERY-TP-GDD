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

namespace FrbaOfertas2.RegistroUsuario.AbmCliente
{
    public partial class ModificarCliente : Form
    {
        BaseDeDato db = new BaseDeDato();
        Cliente clienteConectado;

        public ModificarCliente(String codigo_cliente_ingresado )
        {
            clienteConectado = this.crearCliente(codigo_cliente_ingresado);
            MessageBox.Show(clienteConectado.nombre);
            this.completarCampos(clienteConectado);
            InitializeComponent();
        }

        private void completarCampos(Cliente cliente)
        {
            textBox_nombre1 = new TextBox();
            textBox_nombre1.Text += "aaaa";

        }


        private void label_codigo_viejo_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }



        private void button_modificar_Click(object sender, EventArgs e)
        {
            if(this.huboCambios()){

               //seguir a partir de aca

            }

            

        }

        private bool huboCambios(){

            return this.cambioTexto(textBox_nombre1) || this.cambioTexto(textBox_apellido) || this.cambioTexto(textBox_mail) || this.cambioTexto(textBox_dni) || this.cambioTexto(textBox_numero_piso) ||
                this.cambioTexto(textBox_telefono) || this.cambioTexto(textBox_numero) || this.cambioTexto(textBox_departamento) || this.cambioTexto(textBox_calle)
                || this.cambioTexto(textBox_localidad);
        }

        private bool cambioTexto(TextBox cajaTexto)
        {
            return !cajaTexto.Tag.ToString().Equals(cajaTexto.Text.ToString());
        }

        private Cliente crearCliente(String id_cliente)
        {
            db.conectar();

            SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM S_QUERY.Cliente WHERE clie_codigo = @Id", db.obtenerConexion());
            cmd.Parameters.AddWithValue("@Id", (int)Convert.ToInt32(id_cliente));

            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            DateTime fecha_nac = DateTime.Parse(dr["clie_fecha_nacimiento"].ToString());

            Cliente nuevoCliente = new Cliente(
                  dr["clie_codigo"].ToString(),
                  dr["clie_nombre"].ToString(),
                  dr["clie_apellido"].ToString(),
                  dr["clie_dni"].ToString(),
                  dr["clie_mail"].ToString(),
                  dr["clie_telefono"].ToString(),
                  fecha_nac,
                  bool.Parse(dr["clie_habilitado"].ToString()),
                  dr["direc_codigo"].ToString());

            db.desconectar();

            return nuevoCliente;
        }

        private void ModificarCliente_Load(object sender, EventArgs e)
        {
            this.funcion_cargar_todo();
        }

        private void funcion_cargar_todo()
        {
            //Obtenemos los datos de la direccion
            db.conectar();

            SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM S_QUERY.Direccion WHERE direc_codigo = @Id", db.obtenerConexion());
            cmd.Parameters.AddWithValue("@Id", (int)Convert.ToInt32(clienteConectado.direc_codigo));

            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            textBox_nombre1.Text = clienteConectado.nombre;
            textBox_nombre1.Tag = textBox_nombre1.Text;

            textBox_apellido.Text = clienteConectado.apellido;
            textBox_apellido.Tag = textBox_apellido.Text;

            textBox_dni.Text = clienteConectado.dni;
            textBox_dni.Tag = textBox_dni.Text;

            textBox_mail.Text = clienteConectado.mail;
            textBox_mail.Tag = textBox_mail.Text;

            textBox_telefono.Text = clienteConectado.telefono;
            textBox_telefono.Tag = textBox_telefono.Text;

            dateTimePicker_fecha_nacimiento.Value = clienteConectado.fecha_nacimiento;


            textBox_numero_piso.Text = dr["direc_piso"].ToString();
            textBox_numero_piso.Tag = textBox_numero_piso.Text;

            textBox_numero.Text = dr["direc_nro"].ToString();
            textBox_numero.Tag = textBox_numero.Text;

            textBox_departamento.Text = dr["direc_depto"].ToString();
            textBox_departamento.Tag = textBox_departamento.Text;

            textBox_calle.Text = dr["direc_calle"].ToString();
            textBox_calle.Tag = textBox_calle.Text;

            textBox_localidad.Text = dr["direc_localidad"].ToString();
            textBox_localidad.Tag = textBox_localidad.Text;

            db.desconectar();
        }

        private void dateTimePicker_fecha_nacimiento_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button_deshacer_cambios_Click(object sender, EventArgs e)
        {

            this.funcion_cargar_todo();
        }

    }
}
