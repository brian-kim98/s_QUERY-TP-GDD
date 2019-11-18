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
            
            Proveedor proveedor_prueba = new Proveedor(1, "Leon S.A.", "123154643213",
            "leonreynosa_98@gmail.com","Calzada City", "423965564" , "LION", "VENDE MERCA","Robinson 15509", "1");

            //Application.Run(new AltaRol_Form());
            //Application.Run(new RegistrarUsuario());
            Application.Run(new Login());
            Application.Run(new CargarCredito());
            //Application.Run(new AltaCliente());
            //Application.Run(new ListadoRoles());

            //Application.Run(new CreacionOferta(proveedor_prueba));
        }
    }
}
