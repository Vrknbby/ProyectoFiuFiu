using PruebaUIs.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaUIs.Model.Parametros;
using System.Data;
using System.Data.SqlClient;

namespace PruebaUIs.Repository.Parametros
{

    class LoteArticulosRepository
    {
        private readonly ConexionBD conexion;

        public LoteArticulosRepository()
        {
            conexion = new ConexionBD();
        }

        public void InsertarLoteArticulos(LoteArticulos loteArticulos)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarLoteArt", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "INSERTAR");
                    cmd.Parameters.AddWithValue("@NRO_LOTE", loteArticulos.NRO_LOTE);
                    cmd.Parameters.AddWithValue("@COD_ART", loteArticulos.COD_ART);
                    cmd.Parameters.AddWithValue("@COD_PRV", loteArticulos.COD_PRV);
                    cmd.Parameters.AddWithValue("@FLG_CON_CONS", loteArticulos.FLG_CON_CONS);
                    cmd.Parameters.AddWithValue("@FLG_CON_CANJE", loteArticulos.FLG_CON_CANJE);
                    cmd.Parameters.AddWithValue("@COD_CARTA", loteArticulos.COD_CARTA);
                    cmd.Parameters.AddWithValue("@FEC_INI_LOTE", loteArticulos.FEC_INI_LOTE);
                    cmd.Parameters.AddWithValue("@FEC_FIN_LOTE", loteArticulos.FEC_FIN_LOTE);
                    cmd.Parameters.AddWithValue("@VAL_MAX_CANJE", loteArticulos.VAL_MAX_CANJE);
                    cmd.Parameters.AddWithValue("@COD_USER", loteArticulos.COD_USER);
                    cmd.Parameters.AddWithValue("@FEC_ABM", loteArticulos.FEC_ABM);

                    cmd.ExecuteNonQuery();

                }
                con.Close();
            }

        }

        public void ActualizarLoteArticulos(LoteArticulos loteArticulos)
        {
            try
            {
                using (SqlConnection con = conexion.ObtenerConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("spGestionarLoteArt", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CACCION", "EDITAR");
                        cmd.Parameters.AddWithValue("@NRO_LOTE", loteArticulos.NRO_LOTE);
                        cmd.Parameters.AddWithValue("@COD_ART", loteArticulos.COD_ART);
                        cmd.Parameters.AddWithValue("@COD_PRV", loteArticulos.COD_PRV);
                        cmd.Parameters.AddWithValue("@FLG_CON_CONS", loteArticulos.FLG_CON_CONS);
                        cmd.Parameters.AddWithValue("@FLG_CON_CANJE", loteArticulos.FLG_CON_CANJE);
                        cmd.Parameters.AddWithValue("@COD_CARTA", (object)loteArticulos.COD_CARTA ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@FEC_INI_LOTE", loteArticulos.FEC_INI_LOTE);
                        cmd.Parameters.AddWithValue("@FEC_FIN_LOTE", loteArticulos.FEC_FIN_LOTE);
                        cmd.Parameters.AddWithValue("@VAL_MAX_CANJE", loteArticulos.VAL_MAX_CANJE);
                        cmd.Parameters.AddWithValue("@COD_USER", loteArticulos.COD_USER);
                        cmd.Parameters.AddWithValue("@FEC_ABM", loteArticulos.FEC_ABM);

                        con.Open(); // Abre la conexión antes de ejecutar el comando
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        con.Close();

                        Console.WriteLine($"Filas afectadas: {filasAfectadas}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el lote de artículos: " + ex.Message);
            }
        }

        public List<LoteArticulos> BuscarTodosLosLoteArticulos()
        {
            List<LoteArticulos> loteArticulos = new List<LoteArticulos>();

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarLoteArt", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "BUSCARTODOS");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LoteArticulos loteArticulo = new LoteArticulos(
                                reader["NRO_LOTE"].ToString(),
                                reader["COD_ART"].ToString(),
                                reader["COD_PRV"].ToString(),
                                Convert.ToBoolean(reader["FLG_CON_CONS"]),
                                Convert.ToBoolean(reader["FLG_CON_CANJE"]),
                                reader["COD_CARTA"].ToString(),
                                Convert.ToDateTime(reader["FEC_INI_LOTE"].ToString()),
                                Convert.ToDateTime(reader["FEC_FIN_LOTE"].ToString()),
                                Convert.ToDecimal(reader["VAL_MAX_CANJE"].ToString()),
                                reader["COD_USER"].ToString(),
                                Convert.ToDateTime(reader["FEC_ABM"])
                            );
                            loteArticulos.Add(loteArticulo);
                        }
                    }
                }
                con.Close();
            }
            return loteArticulos;
        }
        public LoteArticulos BuscarLoteArticuloPorCodigo(string nroLote, string codArt, string codPrv)
        {
            LoteArticulos loteArticulo = null;

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarLoteArt", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "BUSCAR");
                    cmd.Parameters.AddWithValue("@NRO_LOTE", nroLote);
                    cmd.Parameters.AddWithValue("@COD_ART", codArt);
                    cmd.Parameters.AddWithValue("@COD_PRV", codPrv);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            loteArticulo = new LoteArticulos(
                                reader["NRO_LOTE"].ToString(),
                                reader["COD_ART"].ToString(),
                                reader["COD_PRV"].ToString(),
                                Convert.ToBoolean(reader["FLG_CON_CONS"]),
                                Convert.ToBoolean(reader["FLG_CON_CANJE"]),
                                reader["COD_CARTA"].ToString(),
                                Convert.ToDateTime(reader["FEC_INI_LOTE"].ToString()),
                                Convert.ToDateTime(reader["FEC_FIN_LOTE"].ToString()),
                                Convert.ToDecimal(reader["VAL_MAX_CANJE"].ToString()),
                                reader["COD_USER"].ToString(),
                                Convert.ToDateTime(reader["FEC_ABM"])
                            );
                        }
                    }
                }
                con.Close();
            }
            return loteArticulo;
        }

        public void EliminarLoteArticulo(string nroLote, string codArt, string codPrv)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarLoteArt", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "ELIMINAR");
                    cmd.Parameters.AddWithValue("@NRO_LOTE", nroLote);
                    cmd.Parameters.AddWithValue("@COD_ART", codArt);
                    cmd.Parameters.AddWithValue("@COD_PRV", codPrv);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

    }



}
