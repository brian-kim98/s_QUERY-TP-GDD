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
        Proveedor proveedor_conectado;

        public CreacionOferta(Proveedor proveedor_cargado)
        {
            InitializeComponent();
            proveedor_conectado = proveedor_cargado;
        }

        private void textBox_descripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void CrearOferta_Load(object sender, EventArgs e)
        {
            bd.conectar();
            adapter = new SqlDataAdapter("SELECT func_codigo, func_nombre FROM S_QUERY.Funcionalidad", bd.obtenerConexion());

            bd.desconectar();
        }

        private void button_crear_Click(object sender, EventArgs e)
        {
            bd.conectar();



            bd.desconectar();
        }

        private void comboBox_proveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
