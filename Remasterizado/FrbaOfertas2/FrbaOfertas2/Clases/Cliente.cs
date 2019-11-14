using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas2.Clases
{
    public class Cliente
    {
        #region Atributos

        public String id { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String dni { get; set; }
        public String mail { get; set; }
        public String telefono { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public String saldo { get; set; }
        public String habilitado { get; set; }
        public String direc_codigo { get; set; }
        public String usuario_codigo { get; set; }

        #endregion

        #region Constructores

        public Cliente()
        {

        }


        #endregion

    }
}
