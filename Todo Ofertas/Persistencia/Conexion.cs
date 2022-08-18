using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class Conexion
    {
        protected static string CadenadaDeConexion
        {
            get
            {
                return @"data source=LAPTOP-4IUKP25O\SQLEXPRESS;" + "Initial Catalog=TodoOfertas;Integrated Security=SSPI";
            }
        }
    }
}
