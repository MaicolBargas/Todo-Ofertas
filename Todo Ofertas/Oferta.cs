using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo_Ofertas
{
    public class Oferta
    {
        private int id;
        private string titulo;
        private string descripcion;
        private int precio;
        private int descuento;
        private int precioFinal;

        public Oferta(int id, string titulo, string descripcion, int precio, int descuento, int precioFinal)
        {
            this.id = id;
            this.titulo = titulo; 
            this.descripcion = descripcion;
            this.precio = precio;
            this.descuento = descuento;
            this.precioFinal = precioFinal;
        }
        public Oferta() { }

        public Oferta(string titulo, string descripcion, int precio, int descuento, int precioFinal)
        {
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.precio = precio;
            this.descuento = descuento;
            this.precioFinal = precioFinal;
        }

        public Oferta(string titulo, string descripcion, int precio, int descuento)
        {
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.precio = precio;
            this.descuento = descuento;
        }

        public int Id { get => id; set => id = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Precio { get => precio; set => precio = value; }
        public int Descuento { get => descuento; set => descuento = value; }
        public int PrecioFinal { get => precioFinal; set => precioFinal = value; }
    }
}
