using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaUIs.DB;
using PruebaUIs.Model.Parametros;
using System.Data;
using System.Data.SqlClient;
namespace PruebaUIs.Repository.Parametros
{
    class ArticuloRepository
    {
        private readonly ConexionBD conexion;

        public ArticuloRepository()
        {
            conexion = new ConexionBD();
        }

        public void InsertarArticulo(Articulo articulo)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarArticulo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "INSERTAR");
                    cmd.Parameters.AddWithValue("@COD_ART", articulo.COD_ART);
                    cmd.Parameters.AddWithValue("@COD_UNICO", articulo.COD_UNICO);
                    cmd.Parameters.AddWithValue("@COD_PADRE", articulo.COD_PADRE);
                    cmd.Parameters.AddWithValue("@DES_ART", articulo.DES_ART);
                    cmd.Parameters.AddWithValue("@COD_FABRICANTE", articulo.COD_FABRICANTE);
                    cmd.Parameters.AddWithValue("@CAR_UND_VTAP", articulo.CAR_UND_VTAP);
                    cmd.Parameters.AddWithValue("@CAR_UND_VTAS", articulo.CAR_UND_VTAS);
                    cmd.Parameters.AddWithValue("@VAL_NCOMP_VTAS", articulo.VAL_NCOMP_VTAS);
                    cmd.Parameters.AddWithValue("@CAR_UND_COMPACK", articulo.CAR_UND_COMPACK);
                    cmd.Parameters.AddWithValue("@COD_CAT", articulo.COD_CAT);
                    cmd.Parameters.AddWithValue("@COD_LIN", articulo.COD_LIN);
                    cmd.Parameters.AddWithValue("@COD_MAR", articulo.COD_MAR);
                    cmd.Parameters.AddWithValue("@COD_PRV", articulo.COD_PRV);
                    cmd.Parameters.AddWithValue("@VAL_TAS_IVA", articulo.VAL_TAS_IVA);
                    cmd.Parameters.AddWithValue("@VAL_PUM_UMO", articulo.VAL_PUM_UMO);
                    cmd.Parameters.AddWithValue("@VAL_CUN_UMO", articulo.VAL_CUN_UMO);
                    cmd.Parameters.AddWithValue("@VAL_SSG_ESP", articulo.VAL_SSG_ESP);
                    cmd.Parameters.AddWithValue("@VAL_STK_EXP", articulo.VAL_STK_EXP);
                    cmd.Parameters.AddWithValue("@VAL_VTA_MIN", articulo.VAL_VTA_MIN);
                    cmd.Parameters.AddWithValue("@FLG_ORIGEN", articulo.FLG_ORIGEN);
                    cmd.Parameters.AddWithValue("@FLG_VTA_LIBRE", articulo.FLG_VTA_LIBRE);
                    cmd.Parameters.AddWithValue("@FLG_ART_CTR", articulo.FLG_ART_CTR);
                    cmd.Parameters.AddWithValue("@FLG_ART_FRA", articulo.FLG_ART_FRA);
                    cmd.Parameters.AddWithValue("@FLG_CAD_FRIO", articulo.FLG_CAD_FRIO);
                    cmd.Parameters.AddWithValue("@FLG_ART_INA", articulo.FLG_ART_INA);
                    cmd.Parameters.AddWithValue("@FLG_INH_VTA", articulo.FLG_INH_VTA);
                    cmd.Parameters.AddWithValue("@FLG_INH_COM", articulo.FLG_INH_COM);
                    cmd.Parameters.AddWithValue("@CAR_ADICIONAL", articulo.CAR_ADICIONAL);
                    cmd.Parameters.AddWithValue("@COD_USER", articulo.COD_USER);
                    cmd.Parameters.AddWithValue("@FEC_ABM", articulo.FEC_ABM);
                    cmd.ExecuteNonQuery();

                }
                con.Close();
            }

        }

        public void ActualizarArticulo(Articulo articulo)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarArticulo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "EDITAR");
                    cmd.Parameters.AddWithValue("@COD_ART", articulo.COD_ART);
                    cmd.Parameters.AddWithValue("@COD_UNICO", articulo.COD_UNICO);
                    cmd.Parameters.AddWithValue("@COD_PADRE", articulo.COD_PADRE);
                    cmd.Parameters.AddWithValue("@DES_ART", articulo.DES_ART);
                    cmd.Parameters.AddWithValue("@COD_FABRICANTE", articulo.COD_FABRICANTE);
                    cmd.Parameters.AddWithValue("@CAR_UND_VTAP", articulo.CAR_UND_VTAP);
                    cmd.Parameters.AddWithValue("@CAR_UND_VTAS", articulo.CAR_UND_VTAS);
                    cmd.Parameters.AddWithValue("@VAL_NCOMP_VTAS", articulo.VAL_NCOMP_VTAS);
                    cmd.Parameters.AddWithValue("@CAR_UND_COMPACK", articulo.CAR_UND_COMPACK);
                    cmd.Parameters.AddWithValue("@COD_CAT", articulo.COD_CAT);
                    cmd.Parameters.AddWithValue("@COD_LIN", articulo.COD_LIN);
                    cmd.Parameters.AddWithValue("@COD_MAR", articulo.COD_MAR);
                    cmd.Parameters.AddWithValue("@COD_PRV", articulo.COD_PRV);
                    cmd.Parameters.AddWithValue("@VAL_TAS_IVA", articulo.VAL_TAS_IVA);
                    cmd.Parameters.AddWithValue("@VAL_PUM_UMO", articulo.VAL_PUM_UMO);
                    cmd.Parameters.AddWithValue("@VAL_CUN_UMO", articulo.VAL_CUN_UMO);
                    cmd.Parameters.AddWithValue("@VAL_SSG_ESP", articulo.VAL_SSG_ESP);
                    cmd.Parameters.AddWithValue("@VAL_STK_EXP", articulo.VAL_STK_EXP);
                    cmd.Parameters.AddWithValue("@VAL_VTA_MIN", articulo.VAL_VTA_MIN);
                    cmd.Parameters.AddWithValue("@FLG_ORIGEN", articulo.FLG_ORIGEN);
                    cmd.Parameters.AddWithValue("@FLG_VTA_LIBRE", articulo.FLG_VTA_LIBRE);
                    cmd.Parameters.AddWithValue("@FLG_ART_CTR", articulo.FLG_ART_CTR);
                    cmd.Parameters.AddWithValue("@FLG_ART_FRA", articulo.FLG_ART_FRA);
                    cmd.Parameters.AddWithValue("@FLG_CAD_FRIO", articulo.FLG_CAD_FRIO);
                    cmd.Parameters.AddWithValue("@FLG_ART_INA", articulo.FLG_ART_INA);
                    cmd.Parameters.AddWithValue("@FLG_INH_VTA", articulo.FLG_INH_VTA);
                    cmd.Parameters.AddWithValue("@FLG_INH_COM", articulo.FLG_INH_COM);
                    cmd.Parameters.AddWithValue("@CAR_ADICIONAL", articulo.CAR_ADICIONAL);
                    cmd.Parameters.AddWithValue("@COD_USER", articulo.COD_USER);
                    cmd.Parameters.AddWithValue("@FEC_ABM", articulo.FEC_ABM);
                    cmd.ExecuteNonQuery();

                }
                con.Close();
            }

        }
        public List<Articulo> BuscarTodosLosArticulos()
        {
            List<Articulo> articulos = new List<Articulo>();

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarArticulo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "BUSCARTODOS");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Articulo articulo = new Articulo(
                                reader["COD_ART"] != DBNull.Value ? reader["COD_ART"].ToString() : "",
                                reader["COD_UNICO"] != DBNull.Value ? reader["COD_UNICO"].ToString() : "",
                                reader["COD_PADRE"] != DBNull.Value ? reader["COD_PADRE"].ToString() : "",
                                reader["DES_ART"] != DBNull.Value ? reader["DES_ART"].ToString() : "",
                                reader["COD_FABRICANTE"] != DBNull.Value ? reader["COD_FABRICANTE"].ToString() : "",
                                reader["CAR_UND_VTAP"] != DBNull.Value ? reader["CAR_UND_VTAP"].ToString() : "",
                                reader["CAR_UND_VTAS"] != DBNull.Value ? reader["CAR_UND_VTAS"].ToString() : "",
                                reader["VAL_NCOMP_VTAS"] != DBNull.Value ? Convert.ToInt16(reader["VAL_NCOMP_VTAS"]) : (short)0,
                                reader["CAR_UND_COMPACK"] != DBNull.Value ? Convert.ToDecimal(reader["CAR_UND_COMPACK"]) : 0m,
                                reader["COD_CAT"] != DBNull.Value ? reader["COD_CAT"].ToString() : "",
                                reader["COD_LIN"] != DBNull.Value ? reader["COD_LIN"].ToString() : "",
                                reader["COD_MAR"] != DBNull.Value ? reader["COD_MAR"].ToString() : "",
                                reader["COD_PRV"] != DBNull.Value ? reader["COD_PRV"].ToString() : "",
                                reader["VAL_TAS_IVA"] != DBNull.Value ? Convert.ToDecimal(reader["VAL_TAS_IVA"]) : 0m,
                                reader["VAL_PUM_UMO"] != DBNull.Value ? Convert.ToDecimal(reader["VAL_PUM_UMO"]) : 0m,
                                reader["VAL_CUN_UMO"] != DBNull.Value ? Convert.ToDecimal(reader["VAL_CUN_UMO"]) : 0m,
                                reader["VAL_SSG_ESP"] != DBNull.Value ? Convert.ToDecimal(reader["VAL_SSG_ESP"]) : 0m,
                                reader["VAL_STK_EXP"] != DBNull.Value ? Convert.ToDecimal(reader["VAL_STK_EXP"]) : 0m,
                                reader["VAL_VTA_MIN"] != DBNull.Value ? Convert.ToDecimal(reader["VAL_VTA_MIN"]) : 0m,
                                reader["FLG_ORIGEN"] != DBNull.Value ? Convert.ToBoolean(reader["FLG_ORIGEN"]) : false,
                                reader["FLG_VTA_LIBRE"] != DBNull.Value ? Convert.ToBoolean(reader["FLG_VTA_LIBRE"]) : false,
                                reader["FLG_ART_CTR"] != DBNull.Value ? Convert.ToBoolean(reader["FLG_ART_CTR"]) : false,
                                reader["FLG_ART_FRA"] != DBNull.Value ? Convert.ToBoolean(reader["FLG_ART_FRA"]) : false,
                                reader["FLG_CAD_FRIO"] != DBNull.Value ? Convert.ToBoolean(reader["FLG_CAD_FRIO"]) : false,
                                reader["FLG_ART_INA"] != DBNull.Value ? Convert.ToBoolean(reader["FLG_ART_INA"]) : false,
                                reader["FLG_INH_VTA"] != DBNull.Value ? Convert.ToBoolean(reader["FLG_INH_VTA"]) : false,
                                reader["FLG_INH_COM"] != DBNull.Value ? Convert.ToBoolean(reader["FLG_INH_COM"]) : false,
                                reader["CAR_ADICIONAL"] != DBNull.Value ? reader["CAR_ADICIONAL"].ToString() : "",
                                reader["COD_USER"] != DBNull.Value ? reader["COD_USER"].ToString() : "",
                                reader["FEC_ABM"] != DBNull.Value ? Convert.ToDateTime(reader["FEC_ABM"]) : DateTime.MinValue
                            );
                            articulos.Add(articulo);
                        }
                    }
                }
                con.Close();
            }
            return articulos;
        }

        public Articulo BuscarArticuloPorCodigo(string codArt)
        {
            Articulo articulo = null;

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarArticulo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "BUSCAR");
                    cmd.Parameters.AddWithValue("@COD_ART", codArt);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            articulo = new Articulo(
                            reader["COD_ART"].ToString(),
                            reader["COD_UNICO"].ToString(),
                            reader["COD_PADRE"].ToString(),
                            reader["DES_ART"].ToString(),
                            reader["COD_FABRICANTE"].ToString(),
                            reader["CAR_UND_VTAP"].ToString(),
                            reader["CAR_UND_VTAS"].ToString(),
                            Convert.ToInt16(reader["VAL_NCOMP_VTAS"]),
                            Convert.ToDecimal(reader["CAR_UND_COMPACK"]),
                            reader["COD_CAT"].ToString(),
                            reader["COD_LIN"].ToString(),
                            reader["COD_MAR"].ToString(),
                            reader["COD_PRV"].ToString(),
                            Convert.ToDecimal(reader["VAL_TAS_IVA"]),
                            Convert.ToDecimal(reader["VAL_PUM_UMO"]),
                            Convert.ToDecimal(reader["VAL_CUN_UMO"]),
                            Convert.ToDecimal(reader["VAL_SSG_ESP"]),
                            Convert.ToDecimal(reader["VAL_STK_EXP"]),
                            Convert.ToDecimal(reader["VAL_VTA_MIN"]),
                            Convert.ToBoolean(reader["FLG_ORIGEN"]),
                            Convert.ToBoolean(reader["FLG_VTA_LIBRE"]),
                            Convert.ToBoolean(reader["FLG_ART_CTR"]),
                            Convert.ToBoolean(reader["FLG_ART_FRA"]),
                            Convert.ToBoolean(reader["FLG_CAD_FRIO"]),
                            Convert.ToBoolean(reader["FLG_ART_INA"]),
                            Convert.ToBoolean(reader["FLG_INH_VTA"]),
                            Convert.ToBoolean(reader["FLG_INH_COM"]),
                            reader["CAR_ADICIONAL"].ToString(),
                            reader["COD_USER"].ToString(),
                            Convert.ToDateTime(reader["FEC_ABM"]));
                        }
                    }
                }
                con.Close();
            }
            return articulo;
        }

    }


}
