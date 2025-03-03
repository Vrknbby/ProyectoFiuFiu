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
    class UbigeoRepository
    {
        private readonly ConexionBD conexion;

        public UbigeoRepository()
        {
            conexion = new ConexionBD();
        }

        public void InsertarUbicacion(Ubigeo ubiGeo)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarUbiGeo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "INSERTAR");
                    cmd.Parameters.AddWithValue("@COD_PAIS", ubiGeo.COD_PAIS);
                    cmd.Parameters.AddWithValue("@DES_PAIS", ubiGeo.DES_PAIS);
                    cmd.Parameters.AddWithValue("@COD_DPTO", ubiGeo.COD_DPTO);
                    cmd.Parameters.AddWithValue("@DES_DPTO", ubiGeo.DES_DPTO);
                    cmd.Parameters.AddWithValue("@COD_CIU", ubiGeo.COD_CIU);
                    cmd.Parameters.AddWithValue("@DES_CIU", ubiGeo.DES_CIU);
                    cmd.Parameters.AddWithValue("@COD_BARR", ubiGeo.COD_BARR);
                    cmd.Parameters.AddWithValue("@DES_BARR", ubiGeo.DES_BARR);
                    cmd.Parameters.AddWithValue("@CAR_IDIOMA", ubiGeo.CAR_IDIOMA);
                    cmd.Parameters.AddWithValue("@DES_CON", ubiGeo.DES_CON);
                    cmd.Parameters.AddWithValue("@COD_REG", ubiGeo.COD_REG);
                    cmd.Parameters.AddWithValue("@UBI_LATITUD", ubiGeo.UBI_LATITUD);
                    cmd.Parameters.AddWithValue("@UBI_LONGITUD", ubiGeo.UBI_LONGITUD);
                    cmd.Parameters.AddWithValue("@COD_USER", ubiGeo.COD_USER);
                    cmd.Parameters.AddWithValue("@FEC_ABM", ubiGeo.FEC_ABM);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public void ActualizarUbicacion(Ubigeo ubiGeo)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarUbiGeo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "EDITAR");
                    cmd.Parameters.AddWithValue("@COD_PAIS", ubiGeo.COD_PAIS);
                    cmd.Parameters.AddWithValue("@COD_DPTO", ubiGeo.COD_DPTO);
                    cmd.Parameters.AddWithValue("@COD_CIU", ubiGeo.COD_CIU);
                    cmd.Parameters.AddWithValue("@COD_BARR", ubiGeo.COD_BARR);
                    cmd.Parameters.AddWithValue("@DES_PAIS", ubiGeo.DES_PAIS);
                    cmd.Parameters.AddWithValue("@DES_DPTO", ubiGeo.DES_DPTO);
                    cmd.Parameters.AddWithValue("@DES_CIU", ubiGeo.DES_CIU);
                    cmd.Parameters.AddWithValue("@DES_BARR", ubiGeo.DES_BARR);
                    cmd.Parameters.AddWithValue("@CAR_IDIOMA", ubiGeo.CAR_IDIOMA);
                    cmd.Parameters.AddWithValue("@DES_CON", ubiGeo.DES_CON);
                    cmd.Parameters.AddWithValue("@COD_REG", ubiGeo.COD_REG);
                    cmd.Parameters.AddWithValue("@UBI_LATITUD", ubiGeo.UBI_LATITUD);
                    cmd.Parameters.AddWithValue("@UBI_LONGITUD", ubiGeo.UBI_LONGITUD);
                    cmd.Parameters.AddWithValue("@COD_USER", ubiGeo.COD_USER);
                    cmd.Parameters.AddWithValue("@FEC_ABM", ubiGeo.FEC_ABM);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public void EliminarUbicacion(string codPais, short codDpto, short codCiu, short codBarr)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarUbiGeo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "ELIMINAR");
                    cmd.Parameters.AddWithValue("@COD_PAIS", codPais);
                    cmd.Parameters.AddWithValue("@COD_DPTO", codDpto);
                    cmd.Parameters.AddWithValue("@COD_CIU", codCiu);
                    cmd.Parameters.AddWithValue("@COD_BARR", codBarr);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public List<Ubigeo> BuscarTodasLasUbicaciones()
        {
            List<Ubigeo> lista = new List<Ubigeo>();
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarUbiGeo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "BUSCARTODOS");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Ubigeo ubiGeo = new Ubigeo
                            (
                                reader["COD_PAIS"].ToString(),
                                reader["DES_PAIS"].ToString(),
                                Convert.ToInt16(reader["COD_DPTO"]),
                                reader["DES_DPTO"].ToString(),
                                Convert.ToInt16(reader["COD_CIU"]),
                                reader["DES_CIU"].ToString(),
                                Convert.ToInt16(reader["COD_BARR"]),
                                reader["DES_BARR"].ToString(),
                                reader["CAR_IDIOMA"].ToString(),
                                reader["DES_CON"].ToString(),
                                Convert.ToInt16(reader["COD_REG"]),
                                reader["UBI_LATITUD"].ToString(),
                                reader["UBI_LONGITUD"].ToString(),
                                reader["COD_USER"].ToString(),
                                Convert.ToDateTime(reader["FEC_ABM"])
                            );
                            lista.Add(ubiGeo);
                        }
                    }
                }
                con.Close();
            }
            return lista;
        }

        public List<Ubigeo> BuscarTodosLosPaises()
        {
            List<Ubigeo> paises = new List<Ubigeo>();
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = "SELECT DISTINCT COD_PAIS, DES_PAIS FROM DB_UBI_GEO ORDER BY DES_PAIS";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Ubigeo u = new Ubigeo();
                            u.COD_PAIS = reader["COD_PAIS"].ToString();
                            u.DES_PAIS = reader["DES_PAIS"].ToString();
                            paises.Add(u);
                        }
                    }
                }
                con.Close();
            }
            return paises;
        }

        public List<Ubigeo> BuscarDepartamentosPorPais(string codPais)
        {
            List<Ubigeo> departamentos = new List<Ubigeo>();
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = "SELECT DISTINCT COD_DPTO, DES_DPTO FROM DB_UBI_GEO WHERE COD_PAIS = @codPais ORDER BY DES_DPTO";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@codPais", codPais);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Ubigeo u = new Ubigeo();
                            u.COD_DPTO = Convert.ToInt16(reader["COD_DPTO"]);
                            u.DES_DPTO = reader["DES_DPTO"].ToString();
                            departamentos.Add(u);
                        }
                    }
                }
                con.Close();
            }
            return departamentos;
        }

        public List<Ubigeo> BuscarCiudadesPorPaisDpto(string codPais, short codDpto)
        {
            List<Ubigeo> ciudades = new List<Ubigeo>();
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = "SELECT DISTINCT COD_CIU, DES_CIU FROM DB_UBI_GEO WHERE COD_PAIS = @codPais AND COD_DPTO = @codDpto ORDER BY DES_CIU";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@codPais", codPais);
                    cmd.Parameters.AddWithValue("@codDpto", codDpto);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Ubigeo u = new Ubigeo();
                            u.COD_CIU = Convert.ToInt16(reader["COD_CIU"]);
                            u.DES_CIU = reader["DES_CIU"].ToString();
                            ciudades.Add(u);
                        }
                    }
                }
                con.Close();
            }
            return ciudades;
        }

        public List<Ubigeo> BuscarBarriosPorUbicacion(string codPais, short codDpto, short codCiu)
        {
            List<Ubigeo> barrios = new List<Ubigeo>();
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = "SELECT DISTINCT COD_BARR, DES_BARR FROM DB_UBI_GEO WHERE COD_PAIS = @codPais AND COD_DPTO = @codDpto AND COD_CIU = @codCiu ORDER BY DES_BARR";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@codPais", codPais);
                    cmd.Parameters.AddWithValue("@codDpto", codDpto);
                    cmd.Parameters.AddWithValue("@codCiu", codCiu);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Ubigeo u = new Ubigeo();
                            u.COD_BARR = Convert.ToInt16(reader["COD_BARR"]);
                            u.DES_BARR = reader["DES_BARR"].ToString();
                            barrios.Add(u);
                        }
                    }
                }
                con.Close();
            }
            return barrios;
        }
    }
}
