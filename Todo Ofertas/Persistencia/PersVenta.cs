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
    public class PersVenta : Conexion
    {
        public static List<Venta> ListaVenta()
        {
            List<Venta> lista = new List<Venta>();
            try
            {
                Venta venta;

                var conexionSQL = new SqlConnection(CadenadaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("ListarVenta", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        venta = new Venta();
                        venta.Id = int.Parse(reader["Id"].ToString());
                        venta.CiComprador = int.Parse(reader["CiComprador"].ToString());
                        venta.IdOferta = int.Parse(reader["IdOferta"].ToString());
                        lista.Add(venta);
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

        public static bool AltaVenta(Venta pVenta)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenadaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("AltaVenta", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@CiComprador", pVenta.CiComprador));
                cmd.Parameters.Add(new SqlParameter("@IdOferta", pVenta.IdOferta));

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
    }
}
