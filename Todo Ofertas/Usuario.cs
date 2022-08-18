using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo_Ofertas
{
    public class Usuario
    {
        private int ci;
        private string nombre;
        private string mail;
        private string password;

        public Usuario(int ci, string nombre, string mail, string password)
        {
            this.ci = ci;
            this.nombre = nombre;
            this.mail = mail;
            this.password = password;
        }
        public Usuario() { }
        public int Ci { get => ci; set => ci = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Password { get => password; set => password = value; }
    }
}
