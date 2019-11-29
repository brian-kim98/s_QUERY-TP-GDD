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
                  dr["prov_direc_codigo"].ToString(),
                  dr["prov_usuario_codigo"].ToString());

            bd.desconectar();

            return nuevoProveedor;

        }

        private void ModificarProveedor_Load(object sender, EventArgs e)
        {
            this.funcion_cargar_todo();
        }

        private void funcion_cargar_todo()
        {
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

            // ver rubro

            bd.desconectar();
        }

        private void button_deshacer_cambios_Click(object sender, EventArgs e)
        {
            this.funcion_cargar_todo();
        }
    }
}
