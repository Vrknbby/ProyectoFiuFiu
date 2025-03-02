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
    public class RegionFisicaRepository
    {

        private readonly ConexionBD conexion;

        public RegionFisicaRepository()
        {
            conexion = new ConexionBD();
        }

        public void InsertarRegistroFiscal(RegionFisica regFis)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarRegFis", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "INSERTAR");
                    cmd.Parameters.AddWithValue("@COD_REG", regFis.COD_REG);
                    cmd.Parameters.AddWithValue("@DES_REG", regFis.DES_REG);
                    cmd.Parameters.AddWithValue("@COD_USER", regFis.COD_USER);
                    cmd.Parameters.AddWithValue("@FEC_ABM", regFis.FEC_ABM);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public void ActualizarRegistroFiscal(RegionFisica regFis)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarRegFis", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "EDITAR");
                    cmd.Parameters.AddWithValue("@COD_REG", regFis.COD_REG);
                    cmd.Parameters.AddWithValue("@DES_REG", regFis.DES_REG);
                    cmd.Parameters.AddWithValue("@COD_USER", regFis.COD_USER);
                    cmd.Parameters.AddWithValue("@FEC_ABM", regFis.FEC_ABM);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public void EliminarRegistroFiscal(short codReg)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarRegFis", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "ELIMINAR");
                    cmd.Parameters.AddWithValue("@COD_REG", codReg);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public RegionFisica BuscarRegistroFiscalPorCodigo(short codReg)
        {
            RegionFisica regFis = null;

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarRegFis", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "BUSCAR");
                    cmd.Parameters.AddWithValue("@COD_REG", codReg);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            regFis = new RegionFisica(
                                Convert.ToInt16(reader["COD_REG"]),
                                reader["DES_REG"].ToString(),
                                reader["COD_USER"].ToString(),
                                Convert.ToDateTime(reader["FEC_ABM"])
                            );
                        }
                    }
                }
                con.Close();
            }
            return regFis;
        }

        public List<RegionFisica> BuscarTodosLosRegistrosFiscales()
        {
            List<RegionFisica> registros = new List<RegionFisica>();

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarRegFis", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "BUSCARTODOS");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RegionFisica regFis = new RegionFisica(
                                Convert.ToInt16(reader["COD_REG"]),
                                reader["DES_REG"].ToString(),
                                reader["COD_USER"].ToString(),
                                Convert.ToDateTime(reader["FEC_ABM"])
                            );
                            registros.Add(regFis);
                        }
                    }
                }
                con.Close();
            }
            return registros;
        }

    }
}
