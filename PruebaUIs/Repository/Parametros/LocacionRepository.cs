using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaUIs.DB;
using PruebaUIs.Model;
using System.Data;
using System.Data.SqlClient;
namespace PruebaUIs.Repository
{
    public class LocacionRepository
    {
        private readonly ConexionBD conexion;

        public LocacionRepository()
        {
            conexion = new ConexionBD();
        }

        public void InsertarLocacion(Locacion locacion)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarLocacion", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "INSERTAR");
                    cmd.Parameters.AddWithValue("@FLG_DEP_CEN", locacion.FLG_DEP_CEN);
                    cmd.Parameters.AddWithValue("@COD_LOC", locacion.COD_LOC);
                    cmd.Parameters.AddWithValue("@DES_LOC", locacion.DES_LOC);
                    cmd.Parameters.AddWithValue("@FEC_CREA", locacion.FEC_CREA);
                    cmd.Parameters.AddWithValue("@DES_NOM_ENC", locacion.DES_NOM_ENC);
                    cmd.Parameters.AddWithValue("@FLG_LOC_VIR", locacion.FLG_LOC_VIR);
                    cmd.Parameters.AddWithValue("@COD_PAIS", locacion.COD_PAIS);
                    cmd.Parameters.AddWithValue("@COD_DPTO", locacion.COD_DPTO);
                    cmd.Parameters.AddWithValue("@COD_CIU", locacion.COD_CIU);
                    cmd.Parameters.AddWithValue("@COD_BARR", locacion.COD_BARR);
                    cmd.Parameters.AddWithValue("@DES_DIR_LOC", locacion.DES_DIR_LOC);
                    cmd.Parameters.AddWithValue("@VAL_ZLOC_ALT", locacion.VAL_ZLOC_ALT);
                    cmd.Parameters.AddWithValue("@VAL_ZLOC_SUP", locacion.VAL_ZLOC_SUP);
                    cmd.Parameters.AddWithValue("@VAL_COB_ESP", locacion.VAL_COB_ESP);
                    cmd.Parameters.AddWithValue("@COD_USER", locacion.COD_USER);
                    cmd.Parameters.AddWithValue("@FEC_ABM", locacion.FEC_ABM);

                    cmd.ExecuteNonQuery();

                }
                con.Close();
            }

        }

        public void ActualizarLocacion(Locacion locacion)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarLocacion", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "EDITAR");
                    cmd.Parameters.AddWithValue("@FLG_DEP_CEN", locacion.FLG_DEP_CEN);
                    cmd.Parameters.AddWithValue("@COD_LOC", locacion.COD_LOC);
                    cmd.Parameters.AddWithValue("@DES_LOC", locacion.DES_LOC);
                    cmd.Parameters.AddWithValue("@FEC_CREA", locacion.FEC_CREA);
                    cmd.Parameters.AddWithValue("@DES_NOM_ENC", locacion.DES_NOM_ENC);
                    cmd.Parameters.AddWithValue("@FLG_LOC_VIR", locacion.FLG_LOC_VIR);
                    cmd.Parameters.AddWithValue("@COD_PAIS", locacion.COD_PAIS);
                    cmd.Parameters.AddWithValue("@COD_DPTO", locacion.COD_DPTO);
                    cmd.Parameters.AddWithValue("@COD_CIU", locacion.COD_CIU);
                    cmd.Parameters.AddWithValue("@COD_BARR", locacion.COD_BARR);
                    cmd.Parameters.AddWithValue("@DES_DIR_LOC", locacion.DES_DIR_LOC);
                    cmd.Parameters.AddWithValue("@VAL_ZLOC_ALT", locacion.VAL_ZLOC_ALT);
                    cmd.Parameters.AddWithValue("@VAL_ZLOC_SUP", locacion.VAL_ZLOC_SUP);
                    cmd.Parameters.AddWithValue("@VAL_COB_ESP", locacion.VAL_COB_ESP);
                    cmd.Parameters.AddWithValue("@COD_USER", locacion.COD_USER);
                    cmd.Parameters.AddWithValue("@FEC_ABM", locacion.FEC_ABM);

                    cmd.ExecuteNonQuery();

                }
                con.Close();
            }

        }

        public List<Locacion> BuscarTodasLasLocaciones()
        {
            List<Locacion> locaciones = new List<Locacion>();

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarLocacion", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "BUSCARTODOS");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Locacion locacion = new Locacion(
                                Convert.ToBoolean(reader["FLG_DEP_CEN"]),
                                reader["COD_LOC"].ToString(),
                                reader["DES_LOC"].ToString(),
                                reader.IsDBNull(reader.GetOrdinal("FEC_CREA")) ? DateTime.MinValue : Convert.ToDateTime(reader["FEC_CREA"]),
                                reader["DES_NOM_ENC"].ToString(),
                                Convert.ToBoolean(reader["FLG_LOC_VIR"]),
                                reader["COD_PAIS"].ToString(),
                                Convert.ToInt32(reader["COD_DPTO"]),
                                Convert.ToInt32(reader["COD_CIU"]),
                                Convert.ToInt32(reader["COD_BARR"]),
                                reader["DES_DIR_LOC"].ToString(),

                                // Verificar NULL antes de convertir a decimal
                                reader.IsDBNull(reader.GetOrdinal("VAL_ZLOC_ALT")) ? 0m : Convert.ToDecimal(reader["VAL_ZLOC_ALT"]),
                                reader.IsDBNull(reader.GetOrdinal("VAL_ZLOC_SUP")) ? 0m : Convert.ToDecimal(reader["VAL_ZLOC_SUP"]),

                                reader.IsDBNull(reader.GetOrdinal("VAL_COB_ESP")) ? 0 : Convert.ToInt32(reader["VAL_COB_ESP"]),
                                reader["COD_USER"].ToString(),
                                reader.IsDBNull(reader.GetOrdinal("FEC_ABM")) ? DateTime.MinValue : Convert.ToDateTime(reader["FEC_ABM"])
                            );

                            locaciones.Add(locacion);
                        }
                    }
                }
                con.Close();
            }
            return locaciones;
        }
        public void EliminarLocacion(string codLoc)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarLocacion", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "ELIMINAR");
                    cmd.Parameters.AddWithValue("@COD_LOC", codLoc);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

    }

}
