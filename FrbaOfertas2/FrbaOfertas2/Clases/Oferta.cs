using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas2.Clases
{
    public class Oferta
    {
        public String detalle { get; set; }
        public String precio { get; set; }
        public String precio_lista { get; set; }
        public String oferta_codigo { get; set; }
        public int maximaCompra { get; set; }
        public int cantidadDisponible { get; set; }

        public Oferta(String detalle_ingresado, String precio_ingresado, String precio_lista_ingresado, String codigo_ingresado, int maximo, int cantidad_ingresada)
        {
            this.detalle = detalle_ingresado;
            this.precio = precio_ingresado;
            this.precio_lista = precio_lista;
            this.oferta_codigo = codigo_ingresado;
            this.maximaCompra = maximo;
            this.cantidadDisponible = cantidad_ingresada;



        }

    }
}
