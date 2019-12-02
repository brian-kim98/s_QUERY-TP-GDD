using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas2.Clases
{
    class Cliente
    {
        #region Atributos

        public String id { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String dni { get; set; }
        public String mail { get; set; }
        public String telefono { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public int saldo { get; set; }
        public bool habilitado { get; set; }
        public String direc_codigo { get; set; }
        public String usuario_codigo { get; set; }

        #endregion

        #region Constructores

        public Cliente(String id_nuevo, String nombre_nuevo, String apellido_nuevo, String dni_nuevo, String mail_nuevo, String telefono_nuevo, DateTime fecha_nac, bool habilitado_nuevo, String id_direc, int saldo_ingre)
        {
            this.apellido = apellido_nuevo;
            this.dni = dni_nuevo;
            this.nombre = nombre_nuevo;
            this.telefono = telefono_nuevo;
            this.id = id_nuevo;
            this.mail = mail_nuevo;
            this.fecha_nacimiento = fecha_nac;
            this.habilitado = habilitado_nuevo;
            this.direc_codigo = id_direc;
            this.saldo = saldo_ingre;

        }


        #endregion

    }
}
