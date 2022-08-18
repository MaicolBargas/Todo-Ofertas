using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo_Ofertas
{
    public class Admin
    {
        private int ci;
        private string nombre;
        private string mail;
        private string password;
        private int code;

        public Admin(int ci, string nombre, string mail, string password, int code)
        {
            this.ci = ci;
            this.nombre = nombre;
            this.mail = mail;
            this.password = password;
            this.code = code;
        }
        public Admin()
        { }

        public int Ci { get => ci; set => ci = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Password { get => password; set => password = value; }
        public int Code { get => code; set => code = value; }
    }
}
