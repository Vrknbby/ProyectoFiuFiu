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
    public class SegmentosComercialesRepository
    {
        private readonly ConexionBD conexion;

        public SegmentosComercialesRepository()
        {
            conexion = new ConexionBD();
        }

        public void InsertarSegmentoComercial(SegmentoComerciales segCom)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarSegCom", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "INSERTAR");
                    cmd.Parameters.AddWithValue("@COD_SEG", segCom.COD_SEG);
                    cmd.Parameters.AddWithValue("@DES_SEG", segCom.DES_SEG);
                    cmd.Parameters.AddWithValue("@COD_SSEG", segCom.COD_SSEG);
                    cmd.Parameters.AddWithValue("@DES_SSEG", segCom.DES_SSEG);
                    cmd.Parameters.AddWithValue("@COD_USER", segCom.COD_USER);
                    cmd.Parameters.AddWithValue("@FEC_ABM", segCom.FEC_ABM);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public void ActualizarSegmentoComercial(SegmentoComerciales segCom)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarSegCom", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "EDITAR");
                    cmd.Parameters.AddWithValue("@COD_SEG", segCom.COD_SEG);
                    cmd.Parameters.AddWithValue("@DES_SEG", segCom.DES_SEG);
                    cmd.Parameters.AddWithValue("@COD_SSEG", segCom.COD_SSEG);
                    cmd.Parameters.AddWithValue("@DES_SSEG", segCom.DES_SSEG);
                    cmd.Parameters.AddWithValue("@COD_USER", segCom.COD_USER);
                    cmd.Parameters.AddWithValue("@FEC_ABM", segCom.FEC_ABM);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public void EliminarSegmentoComercial(string codSeg, string codSseg)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarSegCom", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "ELIMINAR");
                    cmd.Parameters.AddWithValue("@COD_SEG", codSeg);
                    cmd.Parameters.AddWithValue("@COD_SSEG", codSseg);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public SegmentoComerciales BuscarSegmentoComercialPorCodigo(string codSeg, string codSseg)
        {
            SegmentoComerciales segCom = null;

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarSegCom", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "BUSCAR");
                    cmd.Parameters.AddWithValue("@COD_SEG", codSeg);
                    cmd.Parameters.AddWithValue("@COD_SSEG", codSseg);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            segCom = new SegmentoComerciales(
                                reader["COD_SEG"].ToString(),
                                reader["DES_SEG"].ToString(),
                                reader["COD_SSEG"].ToString(),
                                reader["DES_SSEG"].ToString(),
                                reader["COD_USER"].ToString(),
                                Convert.ToDateTime(reader["FEC_ABM"])
                            );
                        }
                    }
                }
                con.Close();
            }
            return segCom;
        }

        public List<SegmentoComerciales> BuscarTodosLosSegmentosComerciales()
        {
            List<SegmentoComerciales> segmentos = new List<SegmentoComerciales>();

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarSegCom", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "BUSCARTODOS");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SegmentoComerciales segCom = new SegmentoComerciales(
                                reader["COD_SEG"].ToString(),
                                reader["DES_SEG"].ToString(),
                                reader["COD_SSEG"].ToString(),
                                reader["DES_SSEG"].ToString(),
                                reader["COD_USER"].ToString(),
                                Convert.ToDateTime(reader["FEC_ABM"])
                            );
                            segmentos.Add(segCom);
                        }
                    }
                }
                con.Close();
            }
            return segmentos;
        }

        public List<SegmentoComerciales> BuscarSubsegmentosPorSegmento(string codSeg)
        {
            List<SegmentoComerciales> subsegmentos = new List<SegmentoComerciales>();
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = @"
                    SELECT COD_SEG, DES_SEG, COD_SSEG, DES_SSEG, COD_USER, FEC_ABM
                    FROM DB_SEG_COM
                    WHERE COD_SEG = @codSeg
                    ORDER BY DES_SSEG
                ";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@codSeg", codSeg);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SegmentoComerciales seg = new SegmentoComerciales
                            (
                                reader["COD_SEG"].ToString(),
                                reader["DES_SEG"].ToString(),
                                reader["COD_SSEG"].ToString(),
                                reader["DES_SSEG"].ToString(),
                                reader["COD_USER"].ToString(),
                                Convert.ToDateTime(reader["FEC_ABM"])
                            );
                            subsegmentos.Add(seg);
                        }
                    }
                }
                con.Close();
            }
            return subsegmentos;
        }
    }
}
