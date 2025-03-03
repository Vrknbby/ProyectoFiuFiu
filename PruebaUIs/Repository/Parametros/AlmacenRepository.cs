using PruebaUIs.DB;
using PruebaUIs.Model.Parametros;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaUIs.Repository.Parametros
{
    public class AlmacenRepository
    {

        private readonly ConexionBD conexion;

        public AlmacenRepository()
        {
            conexion= new ConexionBD();
        }

        public void InsertarAlmacen(Almacen almacen)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarAlmacen", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "INSERTAR");
                    cmd.Parameters.AddWithValue("@COD_ALM", almacen.COD_ALM);
                    cmd.Parameters.AddWithValue("@DES_ALM", almacen.DES_ALM);
                    cmd.Parameters.AddWithValue("@FEC_CREA", almacen.FEC_CREA);
                    cmd.Parameters.AddWithValue("@COD_LOC", almacen.COD_LOC);
                    cmd.Parameters.AddWithValue("@DES_NOM_ENC", almacen.DES_NOM_ENC);
                    cmd.Parameters.AddWithValue("@VAL_ZALM_ALT", almacen.VAL_ZALM_ALT ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@VAL_ZALM_SUP", almacen.VAL_ZALM_SUP ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@FLG_AMB_CTRL", almacen.FLG_AMB_CTRL);
                    cmd.Parameters.AddWithValue("@FLG_ALM_CANJE", almacen.FLG_ALM_CANJE);
                    cmd.Parameters.AddWithValue("@COD_USER", almacen.COD_USER);
                    cmd.Parameters.AddWithValue("@FEC_ABM", almacen.FEC_ABM);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EditarAlmacen(Almacen almacen)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarAlmacen", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "EDITAR");
                    cmd.Parameters.AddWithValue("@COD_ALM", almacen.COD_ALM);
                    cmd.Parameters.AddWithValue("@DES_ALM", almacen.DES_ALM ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@FEC_CREA", almacen.FEC_CREA);
                    cmd.Parameters.AddWithValue("@COD_LOC", almacen.COD_LOC ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DES_NOM_ENC", almacen.DES_NOM_ENC ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@VAL_ZALM_ALT", almacen.VAL_ZALM_ALT ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@VAL_ZALM_SUP", almacen.VAL_ZALM_SUP ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@FLG_AMB_CTRL", almacen.FLG_AMB_CTRL);
                    cmd.Parameters.AddWithValue("@FLG_ALM_CANJE", almacen.FLG_ALM_CANJE);
                    cmd.Parameters.AddWithValue("@COD_USER", almacen.COD_USER);
                    cmd.Parameters.AddWithValue("@FEC_ABM", almacen.FEC_ABM);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarAlmacen(string codAlm)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarAlmacen", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "ELIMINAR");
                    cmd.Parameters.AddWithValue("@COD_ALM", codAlm);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Almacen BuscarAlmacenPorCodigo(string codAlm)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarAlmacen", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "BUSCAR");
                    cmd.Parameters.AddWithValue("@COD_ALM", codAlm);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Almacen(
                                reader["COD_ALM"].ToString(),
                                reader["DES_ALM"].ToString(),
                                Convert.ToDateTime(reader["FEC_CREA"]),
                                reader["COD_LOC"].ToString(),
                                reader["DES_NOM_ENC"].ToString(),
                                reader["VAL_ZALM_ALT"] as decimal?,
                                reader["VAL_ZALM_SUP"] as decimal?,
                                Convert.ToBoolean(reader["FLG_AMB_CTRL"]),
                                Convert.ToBoolean(reader["FLG_ALM_CANJE"]),
                                reader["COD_USER"].ToString(),
                                Convert.ToDateTime(reader["FEC_ABM"])
                            );
                        }
                    }
                }
            }
            return null;
        }

        public List<Almacen> BuscarTodosLosAlmacenes()
        {
            List<Almacen> almacenes = new List<Almacen>();
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarAlmacen", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "BUSCARTODOS");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            almacenes.Add(new Almacen(
                                reader["COD_ALM"].ToString(),
                                reader["DES_ALM"].ToString(),
                                Convert.ToDateTime(reader["FEC_CREA"]),
                                reader["COD_LOC"].ToString(),
                                reader["DES_NOM_ENC"].ToString(),
                                reader["VAL_ZALM_ALT"] as decimal?,
                                reader["VAL_ZALM_SUP"] as decimal?,
                                Convert.ToBoolean(reader["FLG_AMB_CTRL"]),
                                Convert.ToBoolean(reader["FLG_ALM_CANJE"]),
                                reader["COD_USER"].ToString(),
                                Convert.ToDateTime(reader["FEC_ABM"])
                            ));
                        }
                    }
                }
            }
            return almacenes;
        }
    }
}
