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
   public class PersUsuario : Conexion
    {
        public static List<Usuario> ListaUsuario()
        {
            List<Usuario> lista = new List<Usuario>();
            try
            {
                Usuario usuario;

                var conexionSQL = new SqlConnection(CadenadaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("ListarUsuario", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuario = new Usuario();
                        usuario.Ci = int.Parse(reader["Ci"].ToString());
                        usuario.Nombre = reader["Nombre"].ToString();
                        usuario.Mail = reader["Mail"].ToString();
                        usuario.Password = reader["Password"].ToString();
                        lista.Add(usuario);
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
        public static bool AltaUsuario(Usuario pUsuario)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenadaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("AltaUsuario", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.Add(new SqlParameter("@Ci", pUsuario.Ci));
                cmd.Parameters.Add(new SqlParameter("@Nombre", pUsuario.Nombre));               
                cmd.Parameters.Add(new SqlParameter("@Mail", pUsuario.Mail));
                cmd.Parameters.Add(new SqlParameter("@Password", pUsuario.Password));

                int resBD = cmd.ExecuteNonQuery();

                if (resBD > 0)
                {
                    resultado = true;
                }
                if (conexionSQL.State == ConnectionState.Open)
                {
                    conexionSQL.Close();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultado;
        }

        public static Usuario BuscarUsuarioCI(int pCI)
        {
            foreach (Usuario unUsuario in ListaUsuario())
            {
                if (unUsuario.Ci == pCI)
                    return unUsuario;
            }
            return null;
        }

        public static bool SesionIniciada(int ci)
        {
            if (BuscarUsuarioCI(ci) == null) { return false; }
            else { return true; }
 
        }

    }
}
