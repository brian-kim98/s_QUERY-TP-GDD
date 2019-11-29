using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas2.Clases
{
    public class Proveedor
    {
        public int codigo { get; set; }
        public String razon_social { get; set; }
        public String cuit { get; set; }
        public String mail { get; set; }
        public String ciudad { get; set; }
        public String telefono { get; set; }
        public String nombre_contacto { get; set; }
        public String rubro { get; set; }
        public String direc_codigo { get; set; }
        public String usuario_codigo { get; set; }
        public bool habilitado { get; set; }


        public Proveedor(int prov_codigo, String prov_razon_social, String prov_cuit,
            String prov_mail, String prov_ciudad, String prov_telefono , String prov_nombre_contacto, bool habilitacion ,  String prov_rubro, String prov_direc_codigo , String prov_usuario_codigo){

                this.codigo = prov_codigo;
                this.razon_social = prov_razon_social;
                this.cuit = prov_cuit;
                this.mail = prov_mail;
                this.ciudad = prov_mail;
                this.telefono = prov_telefono;
                this.nombre_contacto = prov_nombre_contacto;
                this.rubro = prov_rubro;
                this.direc_codigo = prov_direc_codigo;
                this.usuario_codigo = prov_usuario_codigo;
                this.habilitado = habilitacion;

        }

    }
}
