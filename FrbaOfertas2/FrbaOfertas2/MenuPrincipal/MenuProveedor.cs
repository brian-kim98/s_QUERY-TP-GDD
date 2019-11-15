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
using FrbaOfertas2.CrearOferta;

namespace FrbaOfertas2.MenuPrincipal
{
    public partial class MenuProveedor : Form
    {

        public Proveedor proveedor_usuario;

        public MenuProveedor(Proveedor proveedor_conectado)
        {
            InitializeComponent();
            proveedor_usuario = proveedor_conectado;
            label_bienvenido.Text = "¡Bienvenido " + proveedor_conectado.razon_social.ToString() + " !";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreacionOferta pantalla_crear_oferta = new CreacionOferta(proveedor_usuario);
            pantalla_crear_oferta.Show();
        }

        private void MenuProveedor_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
