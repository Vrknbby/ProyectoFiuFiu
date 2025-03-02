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
    public class FmaArticuloRepository
    {
        private readonly ConexionBD conexion;

        public FmaArticuloRepository()
        {
            conexion = new ConexionBD();
        }

        public void InsertarFMAArticulo(FamiliaArticulos fma)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarFMA_ART", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "INSERTAR");
                    cmd.Parameters.AddWithValue("@COD_CAT", fma.COD_CAT);
                    cmd.Parameters.AddWithValue("@DES_CAT", fma.DES_CAT);
                    cmd.Parameters.AddWithValue("@COD_LIN", fma.COD_LIN);
                    cmd.Parameters.AddWithValue("@DES_LIN", fma.DES_LIN);
                    cmd.Parameters.AddWithValue("@COD_USER", fma.COD_USER);
                    cmd.Parameters.AddWithValue("@FEC_ABM", fma.FEC_ABM);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public void ActualizarFMAArticulo(FamiliaArticulos fma)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarFMA_ART", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "EDITAR");
                    cmd.Parameters.AddWithValue("@COD_CAT", fma.COD_CAT);
                    cmd.Parameters.AddWithValue("@DES_CAT", fma.DES_CAT);
                    cmd.Parameters.AddWithValue("@COD_LIN", fma.COD_LIN);
                    cmd.Parameters.AddWithValue("@DES_LIN", fma.DES_LIN);
                    cmd.Parameters.AddWithValue("@COD_USER", fma.COD_USER);
                    cmd.Parameters.AddWithValue("@FEC_ABM", fma.FEC_ABM);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public void EliminarFMAArticulo(string codCat, string codLin)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarFMA_ART", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "ELIMINAR");
                    cmd.Parameters.AddWithValue("@COD_CAT", codCat);
                    cmd.Parameters.AddWithValue("@COD_LIN", codLin);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public FamiliaArticulos BuscarFMAArticuloPorCodigo(string codCat, string codLin)
        {
            FamiliaArticulos fma = null;
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarFMA_ART", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "BUSCAR");
                    cmd.Parameters.AddWithValue("@COD_CAT", codCat);
                    cmd.Parameters.AddWithValue("@COD_LIN", codLin);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            fma = new FamiliaArticulos(
                                reader["COD_CAT"].ToString(),
                                reader["DES_CAT"].ToString(),
                                reader["COD_LIN"].ToString(),
                                reader["DES_LIN"].ToString(),
                                reader["COD_USER"].ToString(),
                                Convert.ToDateTime(reader["FEC_ABM"])
                            );
                        }
                    }
                }
                con.Close();
            }
            return fma;
        }

        public List<FamiliaArticulos> BuscarTodosLosFMAArticulos()
        {
            List<FamiliaArticulos> fmaArticulos = new List<FamiliaArticulos>();
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarFMA_ART", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "BUSCARTODOS");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FamiliaArticulos fma = new FamiliaArticulos(
                                reader["COD_CAT"].ToString(),
                                reader["DES_CAT"].ToString(),
                                reader["COD_LIN"].ToString(),
                                reader["DES_LIN"].ToString(),
                                reader["COD_USER"].ToString(),
                                Convert.ToDateTime(reader["FEC_ABM"])
                            );
                            fmaArticulos.Add(fma);
                        }
                    }
                }
                con.Close();
            }
            return fmaArticulos;
        }
    }
}
