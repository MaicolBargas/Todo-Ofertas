using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Todo_Ofertas;

namespace Persistencia
{
    public class PersAdmin : Conexion
    {
        public static List<Admin> ListaAdmin()
        {
            List<Admin> lista = new List<Admin>();
            try
            {
                Admin admin;

                var conexionSQL = new SqlConnection(CadenadaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("ListarAdmin", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        admin = new Admin();
                        admin.Ci = int.Parse(reader["Ci"].ToString());
                        admin.Nombre = reader["Nombre"].ToString();
                        admin.Mail = reader["Mail"].ToString();
                        admin.Password = reader["Password"].ToString();
                        admin.Code = int.Parse(reader["Code"].ToString());

                        lista.Add(admin);
                    }
                }
                conexionSQL.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());

            }
            return lista;
        }
        public static Admin BuscarAdminCI(int pCI)
        {
            foreach (Admin unAdmin in ListaAdmin())
            {
                if (unAdmin.Ci == pCI)
                    return unAdmin;
            }
            return null;
        }

        public static bool SesionIniciada(int ci)
        {
            if (BuscarAdminCI(ci) == null) { return false; }
            else { return true; }

        }
    }
}
