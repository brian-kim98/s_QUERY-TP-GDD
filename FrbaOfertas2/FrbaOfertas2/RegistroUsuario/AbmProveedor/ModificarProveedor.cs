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

namespace FrbaOfertas2.RegistroUsuario.AbmProveedor
{
    public partial class ModificarProveedor : Form
    {
        BaseDeDato bd = new BaseDeDato();
        Proveedor proveedorConectado ;

        public ModificarProveedor(String codigoProvee)
        {
            proveedorConectado = this.crearProveedor(codigoProvee);
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        private Proveedor crearProveedor(String codigo_proveedor){

            bd.conectar();

            SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM S_QUERY.Proveedor WHERE prov_codigo = @Id", bd.obtenerConexion());
            cmd.Parameters.AddWithValue("@Id", (int)Convert.ToInt32(codigo_proveedor));

            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();



            Proveedor nuevoProveedor = new Proveedor(
                  (int)Convert.ToInt16(codigo_proveedor),
                  dr["prov_razon_social"].ToString(), ///////////// VER A APRTIR DE ACAD
                  dr["prov_cuit"].ToString(),
                  dr["prov_mail"].ToString(),
                  dr["prov_ciudad"].ToString(),
                  dr["prov_telefono"].ToString(),
                  dr["prov_nombre_contacto"].ToString(),
                  bool.Parse(dr["prov_habilitado"].ToString()),
                  dr["rubro_codigo"].ToString(),
                  dr["direc_codigo"].ToString(),
                  dr["usuario_codigo"].ToString());

            bd.desconectar();

            return nuevoProveedor;

        }

        private void ModificarProveedor_Load(object sender, EventArgs e)
        {
            this.funcion_cargar_todo();
        }

        private void funcion_cargar_todo()
        {

            this.cargarSelectorRubro();

            //Obtenemos los datos de la direccion
            bd.conectar();

            SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM S_QUERY.Direccion WHERE direc_codigo = @Id", bd.obtenerConexion());
            cmd.Parameters.AddWithValue("@Id", (int)Convert.ToInt32(proveedorConectado.direc_codigo));

            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            label_codigo_viejo.Text = proveedorConectado.codigo.ToString();

            textBox_razon_social.Text = proveedorConectado.razon_social;
            textBox_razon_social.Tag = textBox_razon_social.Text;

            textBox_nombre_contacto.Text = proveedorConectado.nombre_contacto;
            textBox_nombre_contacto.Tag = textBox_nombre_contacto.Text;

            textBox_cuit.Text = proveedorConectado.cuit;
            textBox_cuit.Tag = textBox_cuit.Text;

            textBox_mail.Text = proveedorConectado.mail;
            textBox_mail.Tag = textBox_mail.Text;

            textBox_telefono.Text = proveedorConectado.telefono;
            textBox_telefono.Tag = textBox_telefono.Text;


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

            checkBox_habilitado.Checked = proveedorConectado.habilitado;

            comboBox_rubro.SelectedValue = proveedorConectado.rubro;

            bd.desconectar();
        }

        private void button_deshacer_cambios_Click(object sender, EventArgs e)
        {
            this.funcion_cargar_todo();
        }

        private void button_modificar_Click(object sender, EventArgs e)
        {
            if(this.huboCambios() && this.comprobarCamposNumericos()){


                try
                {
                    bd.conectar();
                    SqlCommand procedure = Clases.BaseDeDato.crearConsulta("S_QUERY.modificarProveedor");
                    procedure.CommandType = CommandType.StoredProcedure;
                    procedure.Parameters.AddWithValue("@prov_codigo_modif", SqlDbType.Int).Value = (int)Convert.ToInt32(proveedorConectado.codigo);
                    procedure.Parameters.AddWithValue("@prov_razon_social_modif", SqlDbType.NVarChar).Value = textBox_razon_social.Text;
                    procedure.Parameters.AddWithValue("@prov_cuit_modif", SqlDbType.NVarChar).Value = textBox_cuit.Text;
                    procedure.Parameters.AddWithValue("@prov_nombre_contacto_modif", SqlDbType.NVarChar).Value = textBox_nombre_contacto.Text;
                    procedure.Parameters.AddWithValue("@prov_mail_modif", SqlDbType.NVarChar).Value = textBox_mail.Text;
                    procedure.Parameters.AddWithValue("@prov_telefono_modif", SqlDbType.Int).Value = (int)Convert.ToInt32(textBox_telefono.Text);
                    procedure.Parameters.AddWithValue("@prov_calle_modif", SqlDbType.VarChar).Value = textBox_calle.Text;
                    procedure.Parameters.AddWithValue("@prov_habilitado_modif", SqlDbType.Bit).Value = Boolean.Parse(checkBox_habilitado.Checked.ToString());
                    procedure.Parameters.AddWithValue("@prov_localidad_modif", SqlDbType.VarChar).Value = textBox_localidad.Text;
                    procedure.Parameters.AddWithValue("@prov_nro_modif", SqlDbType.Int).Value = (int)Convert.ToInt32(textBox_numero.Text);

                    if (this.boxVacia(textBox_numero_piso) || this.boxVacia(textBox_departamento))
                    {

                        procedure.Parameters.AddWithValue("@prov_piso_modif", SqlDbType.SmallInt).Value = (object)DBNull.Value;
                        procedure.Parameters.AddWithValue("@prov_depto_modif", SqlDbType.SmallInt).Value = (object)DBNull.Value;

                    }
                    else
                    {

                        procedure.Parameters.AddWithValue("@prov_piso_modif", SqlDbType.SmallInt).Value = (int)Convert.ToInt16(textBox_numero_piso.Text);
                        procedure.Parameters.AddWithValue("@prov_depto_modif", SqlDbType.SmallInt).Value = (int)Convert.ToInt16(textBox_departamento.Text);
                    }


                    procedure.ExecuteNonQuery();

                    bd.desconectar();
                    MessageBox.Show("Se Actualizo el Proveedor.");
                    this.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    bd.desconectar();
                }

                
            }
        }

        private void cargarSelectorRubro()
        {
            SqlConnection connection = ConnectionWithDatabase();

            DataTable tabla_rubros = new DataTable();
            String query_obtenerRubros = "SELECT rubro_codigo, rubro_nombre FROM S_QUERY.Rubro";
            SqlDataAdapter sda = new SqlDataAdapter(query_obtenerRubros, connection);

            try
            {
                connection.Open();
                sda.Fill(tabla_rubros);

            }

            catch (SqlException se)
            {
                MessageBox.Show("An error occured while connecting to database" + se.ToString());
            }




            comboBox_rubro.DataSource = tabla_rubros;
            comboBox_rubro.DisplayMember = "rubro_nombre";
            comboBox_rubro.ValueMember = "rubro_codigo";

            connection.Close();

        }

        private SqlConnection ConnectionWithDatabase()
        {
            string connectionString;
            SqlConnection connection;

            connectionString = @"Data Source=.\SQLSERVER2012;Initial Catalog = GD2C2019;User ID=sa;Password=gestiondedatos";

            connection = new SqlConnection(connectionString);

            return connection;

        }



        private bool comprobarCamposNumericos()
        {
            if (!this.esUnCampoNumerico(textBox_numero) || !this.esUnCampoNumerico(textBox_telefono)
                ||  this.comprobarNumeroDepto(textBox_numero_piso) || this.comprobarNumeroDepto(textBox_departamento))
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


        private bool pisoDeptoDistintos()
        {
            if (this.boxVacia(textBox_numero_piso) && this.boxVacia(textBox_departamento))
            {
                return false;
            }
            else if (!this.boxVacia(textBox_numero_piso) && !this.boxVacia(textBox_departamento))
            {
                return false;
            }
            else { return true; }



        }

        private bool estaTodoCompleto()
        {
            if (this.boxVacia(textBox_cuit)  || this.boxVacia(textBox_razon_social) 
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


        private bool boxVacia(TextBox box)
        {
            return box.Text.ToString() == "";
        }



        private bool huboCambios()
        {

            return this.cambioTexto(textBox_razon_social) || this.cambioTexto(textBox_nombre_contacto) || this.cambioTexto(textBox_mail) || this.cambioTexto(textBox_cuit) || this.cambioTexto(textBox_numero_piso) ||
                this.cambioTexto(textBox_telefono) || this.cambioTexto(textBox_numero) || this.cambioTexto(textBox_departamento) || this.cambioTexto(textBox_calle)
                || this.cambioTexto(textBox_localidad) || !checkBox_habilitado.Checked.ToString().Equals(proveedorConectado.habilitado.ToString())  ||this.cambioRubro();
        }

        private bool cambioTexto(TextBox cajaTexto)
        {
            return !cajaTexto.Tag.ToString().Equals(cajaTexto.Text.ToString());
        }

        private bool cambioRubro()
        {


            return !comboBox_rubro.SelectedValue.ToString().Equals(proveedorConectado.rubro);
        }
    }
}
