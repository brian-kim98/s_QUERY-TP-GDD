using FrbaOfertas2.RegistroUsuario.AbmCliente;
using FrbaOfertas2.LoginYSeguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas2.AbmRol;
using FrbaOfertas2.CrearOferta;
using FrbaOfertas2.Clases;
using FrbaOfertas2.CargaCredito;
using FrbaOfertas2.Facturar;
using FrbaOfertas2.ListadoEstadistico;
using FrbaOfertas2.RegistroUsuario.AbmProveedor;

namespace FrbaOfertas2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Login());
        }
    }
}
