using FrbaOfertas2.RegistroUsuario.AbmCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Application.Run(new AltaRol_Form());
            Application.Run(new RegistrarUsuario());
          //  Application.Run(new AltaCliente());

        }
    }
}
