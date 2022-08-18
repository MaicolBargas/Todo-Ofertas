using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo_Ofertas
{
    public class Venta
    {
        private int id;
        private int ciComprador;
        private int idOferta;
        

        public Venta(int id, int ciComprador, int idOferta)
        {
            this.id = id;
            this.ciComprador = ciComprador;
            this.idOferta = idOferta;
        }
        public Venta()
        { }

        public Venta(int ciComprador, int idOferta)
        {
            this.ciComprador = ciComprador;
            this.idOferta = idOferta;
        }

        public int Id { get => id; set => id = value; }
        public int CiComprador { get => ciComprador; set => ciComprador = value; }
        public int IdOferta { get => idOferta; set => idOferta = value; }
    }
}
