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
        BaseDeDato bd = new BaseDeDato();
        Cliente clienteConectado;

        public ModificarCliente(String codigo_cliente_ingresado )
        {
            clienteConectado = this.crearCliente(codigo_cliente_ingresado);
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
            if(this.huboCambios() && this.estaTodoCompleto() && this.comprobarCamposNumericos()){

                try
                {
                    bd.conectar();
                    SqlCommand procedure = Clases.BaseDeDato.crearConsulta("S_QUERY.modificarCliente");
                    procedure.CommandType = CommandType.StoredProcedure;
                    procedure.Parameters.AddWithValue("@cliente_codigo_modif", SqlDbType.Int).Value = (int)Convert.ToInt32(clienteConectado.id);
                    procedure.Parameters.AddWithValue("@clie_nombre_modif", SqlDbType.VarChar).Value = textBox_nombre1.Text;
                    procedure.Parameters.AddWithValue("@clie_apellido_modif", SqlDbType.VarChar).Value = textBox_apellido.Text;                   
                    procedure.Parameters.AddWithValue("@clie_dni_modif", SqlDbType.Int).Value = (int)Convert.ToInt32(textBox_dni.Text);
                    procedure.Parameters.AddWithValue("@clie_mail_modif", SqlDbType.NVarChar).Value = textBox_mail.Text;
                    procedure.Parameters.AddWithValue("@clie_telefono_modif", SqlDbType.Int).Value = (int)Convert.ToInt32(textBox_telefono.Text);
                    procedure.Parameters.AddWithValue("@clie_fecha_nac_modif", SqlDbType.DateTime).Value = dateTimePicker_fecha_nacimiento.Value;
                    procedure.Parameters.AddWithValue("@clie_habilitado", SqlDbType.Bit).Value = Boolean.Parse(checkBox_habilitado.Checked.ToString());
                    procedure.Parameters.AddWithValue("@clie_calle_modif", SqlDbType.VarChar).Value = textBox_calle.Text;
                    procedure.Parameters.AddWithValue("@clie_localidad_modif", SqlDbType.VarChar).Value = textBox_localidad.Text;
                    procedure.Parameters.AddWithValue("@clie_nro_modif", SqlDbType.Int).Value = (int)Convert.ToInt32(textBox_numero.Text);

                    if (this.boxVacia(textBox_numero_piso)|| this.boxVacia(textBox_departamento))
                    {

                        procedure.Parameters.AddWithValue("@clie_piso_modif", SqlDbType.SmallInt).Value = (object)DBNull.Value;
                        procedure.Parameters.AddWithValue("@clie_depto_modif", SqlDbType.SmallInt).Value = (object)DBNull.Value;

                    }
                    else
                    {

                        procedure.Parameters.AddWithValue("@clie_piso_modif", SqlDbType.SmallInt).Value = (int)Convert.ToInt16(textBox_numero_piso.Text);
                        procedure.Parameters.AddWithValue("@clie_depto_modif", SqlDbType.SmallInt).Value = (int)Convert.ToInt16(textBox_departamento.Text);
                    }


                    procedure.ExecuteNonQuery();

                    bd.desconectar();
                    MessageBox.Show("Se Actualizo el Cliente.");
                    this.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    bd.desconectar();
                }

            }


            

        }

        private bool comprobarCamposNumericos() {
            if (!this.esUnCampoNumerico(textBox_numero) || !this.esUnCampoNumerico(textBox_telefono)
                || !this.esUnCampoNumerico(textBox_dni) || this.comprobarNumeroDepto(textBox_numero_piso) || this.comprobarNumeroDepto(textBox_departamento))
            {

                MessageBox.Show("Hay campos numericos mal introducidos.");
                return false;
            }
            else
            {
                return true;
            }
        
        }

        private bool comprobarNumeroDepto(TextBox box)
        {
            return box.Text.ToString() != "" && !this.esUnCampoNumerico(box);
        }


        private bool estaTodoCompleto()
        {
            if (this.boxVacia(textBox_nombre1) || this.boxVacia(textBox_apellido) || this.boxVacia(textBox_mail) || this.boxVacia(textBox_dni)
                    || this.pisoDeptoDistintos() || this.boxVacia(textBox_telefono)
                    || this.boxVacia(textBox_numero) || this.boxVacia(textBox_calle) || this.boxVacia(textBox_localidad))
            {

                MessageBox.Show("Debe Completar todos los campos");
                return false;

            }
            else
            {
                return true;
            }
        }

        private bool pisoDeptoDistintos()
        {
            if(this.boxVacia(textBox_numero_piso) && this.boxVacia(textBox_departamento)){
                return false;
            }
            else if(!this.boxVacia(textBox_numero_piso) && !this.boxVacia(textBox_departamento)){
                return false;
            }
            else{ return true;}


           
        }

        private bool huboCambios()
        {


            return this.cambioTexto(textBox_nombre1) || this.cambioTexto(textBox_apellido) || this.cambioTexto(textBox_mail) || this.cambioTexto(textBox_dni) || this.cambioTexto(textBox_numero_piso) ||
                this.cambioTexto(textBox_telefono) || this.cambioTexto(textBox_numero) || this.cambioTexto(textBox_departamento) || this.cambioTexto(textBox_calle)
                || this.cambioTexto(textBox_localidad) || !checkBox_habilitado.Checked.ToString().Equals(clienteConectado.habilitado.ToString()) || this.cambioFechaCumple();
        }

        private bool boxVacia(TextBox box)
        {
                return box.Text.ToString() == "" ;
        }





        private bool cambioFechaCumple()
        {
            int result = DateTime.Compare(clienteConectado.fecha_nacimiento, dateTimePicker_fecha_nacimiento.Value);

            return result != 0;
        }

        private bool cambioTexto(TextBox cajaTexto)
        {
            return !cajaTexto.Tag.ToString().Equals(cajaTexto.Text.ToString());
        }

        private Cliente crearCliente(String id_cliente)
        {
            bd.conectar();

            SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM S_QUERY.Cliente WHERE clie_codigo = @Id", bd.obtenerConexion());
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
                  dr["direc_codigo"].ToString(),
                  int.Parse(dr["clie_saldo"].ToString()));

            bd.desconectar();

            return nuevoCliente;
        }

        private void ModificarCliente_Load(object sender, EventArgs e)
        {
            this.funcion_cargar_todo();
        }

        private void funcion_cargar_todo()
        {
            //Obtenemos los datos de la direccion
            bd.conectar();

            SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM S_QUERY.Direccion WHERE direc_codigo = @Id", bd.obtenerConexion());
            cmd.Parameters.AddWithValue("@Id", (int)Convert.ToInt32(clienteConectado.direc_codigo));

            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            label_codigo_viejo.Text = clienteConectado.id;

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

            checkBox_habilitado.Checked = clienteConectado.habilitado;

            bd.desconectar();
        }

        private void dateTimePicker_fecha_nacimiento_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button_deshacer_cambios_Click(object sender, EventArgs e)
        {

            this.funcion_cargar_todo();
        }


        private bool esUnCampoNumerico(TextBox casilla_texto)
        {

            double valorDouble = 0.0;

            float valorFloat = (float)valorDouble;

            bool respuesta = float.TryParse(casilla_texto.Text, out valorFloat);

            if(!respuesta){
                casilla_texto.BackColor = SystemColors.ControlDark;
            }

            return respuesta;

        }

    }
}
