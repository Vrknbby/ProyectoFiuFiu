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
    public class PersonaRepository
    {
        private readonly ConexionBD conexion;

        public PersonaRepository()
        {
            conexion = new ConexionBD();
        }

        public void InsertarPersona(Personas persona)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarPersona", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "INSERTAR");
                    cmd.Parameters.AddWithValue("@COD_PER", persona.COD_PER);
                    cmd.Parameters.AddWithValue("@DES_PER", persona.DES_PER ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@FLG_PER_JUR", (object)persona.FLG_PER_JUR ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FLG_SEX_PER", (object)persona.FLG_SEX_PER ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@COD_PAIS", persona.COD_PAIS ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@COD_DPTO", (object)persona.COD_DPTO ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@COD_CIU", (object)persona.COD_CIU ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@COD_BARR", (object)persona.COD_BARR ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DES_DIR", persona.DES_DIR ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@NRO_RUC", persona.NRO_RUC ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@EMAIL_EMP", persona.EMAIL_EMP ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@EMP_TELF1", persona.EMP_TELF1 ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@EMP_TELF2", persona.EMP_TELF2 ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@WWW_URL", persona.WWW_URL ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@COD_USER", persona.COD_USER ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@FEC_ABM", (object)persona.FEC_ABM ?? DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public void ActualizarPersona(Personas persona)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarPersona", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "EDITAR");
                    cmd.Parameters.AddWithValue("@COD_PER", persona.COD_PER);
                    cmd.Parameters.AddWithValue("@DES_PER", persona.DES_PER ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@FLG_PER_JUR", (object)persona.FLG_PER_JUR ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FLG_SEX_PER", (object)persona.FLG_SEX_PER ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@COD_PAIS", persona.COD_PAIS ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@COD_DPTO", (object)persona.COD_DPTO ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@COD_CIU", (object)persona.COD_CIU ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@COD_BARR", (object)persona.COD_BARR ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DES_DIR", persona.DES_DIR ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@NRO_RUC", persona.NRO_RUC ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@EMAIL_EMP", persona.EMAIL_EMP ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@EMP_TELF1", persona.EMP_TELF1 ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@EMP_TELF2", persona.EMP_TELF2 ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@WWW_URL", persona.WWW_URL ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@COD_USER", persona.COD_USER ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@FEC_ABM", (object)persona.FEC_ABM ?? DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public void EliminarPersona(string codPer)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarPersona", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "ELIMINAR");
                    cmd.Parameters.AddWithValue("@COD_PER", codPer);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public Personas BuscarPersonaPorCodigo(string codPer)
        {
            Personas persona = null;
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarPersona", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "BUSCAR");
                    cmd.Parameters.AddWithValue("@COD_PER", codPer);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            persona = new Personas
                            {
                                COD_PER = reader["COD_PER"].ToString(),
                                DES_PER = reader["DES_PER"].ToString(),
                                FLG_PER_JUR = reader["FLG_PER_JUR"] != DBNull.Value ? (bool?)reader["FLG_PER_JUR"] : null,
                                FLG_SEX_PER = reader["FLG_SEX_PER"] != DBNull.Value ? (bool?)reader["FLG_SEX_PER"] : null,
                                COD_PAIS = reader["COD_PAIS"].ToString(),
                                COD_DPTO = reader["COD_DPTO"] != DBNull.Value ? (short?)Convert.ToInt16(reader["COD_DPTO"]) : null,
                                COD_CIU = reader["COD_CIU"] != DBNull.Value ? (short?)Convert.ToInt16(reader["COD_CIU"]) : null,
                                COD_BARR = reader["COD_BARR"] != DBNull.Value ? (short?)Convert.ToInt16(reader["COD_BARR"]) : null,
                                DES_DIR = reader["DES_DIR"].ToString(),
                                NRO_RUC = reader["NRO_RUC"].ToString(),
                                EMAIL_EMP = reader["EMAIL_EMP"].ToString(),
                                EMP_TELF1 = reader["EMP_TELF1"].ToString(),
                                EMP_TELF2 = reader["EMP_TELF2"].ToString(),
                                WWW_URL = reader["WWW_URL"].ToString(),
                                COD_USER = reader["COD_USER"].ToString(),
                                FEC_ABM = reader["FEC_ABM"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["FEC_ABM"]) : null
                            };
                        }
                    }
                }
                con.Close();
            }
            return persona;
        }

        /// <summary>
        /// Busca todas las personas registradas.
        /// </summary>
        /// <returns>Lista de objetos Persona.</returns>
        public List<Personas> BuscarTodasLasPersonas()
        {
            List<Personas> listaPersonas = new List<Personas>();
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarPersona", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "BUSCARTODOS");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Personas persona = new Personas
                            {
                                COD_PER = reader["COD_PER"].ToString(),
                                DES_PER = reader["DES_PER"].ToString(),
                                FLG_PER_JUR = reader["FLG_PER_JUR"] != DBNull.Value ? (bool?)reader["FLG_PER_JUR"] : null,
                                FLG_SEX_PER = reader["FLG_SEX_PER"] != DBNull.Value ? (bool?)reader["FLG_SEX_PER"] : null,
                                COD_PAIS = reader["COD_PAIS"].ToString(),
                                COD_DPTO = reader["COD_DPTO"] != DBNull.Value ? (short?)Convert.ToInt16(reader["COD_DPTO"]) : null,
                                COD_CIU = reader["COD_CIU"] != DBNull.Value ? (short?)Convert.ToInt16(reader["COD_CIU"]) : null,
                                COD_BARR = reader["COD_BARR"] != DBNull.Value ? (short?)Convert.ToInt16(reader["COD_BARR"]) : null,
                                DES_DIR = reader["DES_DIR"].ToString(),
                                NRO_RUC = reader["NRO_RUC"].ToString(),
                                EMAIL_EMP = reader["EMAIL_EMP"].ToString(),
                                EMP_TELF1 = reader["EMP_TELF1"].ToString(),
                                EMP_TELF2 = reader["EMP_TELF2"].ToString(),
                                WWW_URL = reader["WWW_URL"].ToString(),
                                COD_USER = reader["COD_USER"].ToString(),
                                FEC_ABM = reader["FEC_ABM"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["FEC_ABM"]) : null
                            };
                            listaPersonas.Add(persona);
                        }
                    }
                }
                con.Close();
            }
            return listaPersonas;
        }
    }
}
