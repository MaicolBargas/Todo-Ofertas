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
    public class PersOferta : Conexion
    {
        public static List<Oferta> ListaOferta()
        {
            List<Oferta> lista = new List<Oferta>();
            try
            {
                Oferta oferta;

                var conexionSQL = new SqlConnection(CadenadaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("ListarOferta", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        oferta = new Oferta();
                        oferta.Id = int.Parse(reader["Id"].ToString());
                        oferta.Titulo = reader["Titulo"].ToString();
                        oferta.Descripcion = reader["Descripcion"].ToString();
                        oferta.Precio = int.Parse(reader["Precio"].ToString());
                        oferta.Descuento = int.Parse(reader["Descuento"].ToString());
                        oferta.PrecioFinal = int.Parse(reader["PrecioFinal"].ToString());

                        lista.Add(oferta);
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

        public static bool AltaOferta(Oferta pOferta)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenadaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("AltaOferta", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Titulo", pOferta.Titulo));
                cmd.Parameters.Add(new SqlParameter("@Descripcion", pOferta.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@Precio", pOferta.Precio));
                cmd.Parameters.Add(new SqlParameter("@Descuento", pOferta.Descuento));

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

        public static bool BajaOferta(int pId)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenadaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("BajaOferta", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Id", pId));

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

        public static Oferta BuscarOfertaID(int pID)
        {
            foreach (Oferta unOferta in ListaOferta())
            {
                if (unOferta.Id == pID)
                    return unOferta;
            }
            return null;
        }
    }
}
