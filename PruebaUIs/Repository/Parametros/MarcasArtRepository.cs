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
    public class MarcasArtRepository
    {

        private readonly ConexionBD conexion;

        public MarcasArtRepository()
        {
            conexion = new ConexionBD();
        }

        public void InsertarMarca(MarcasArticulos marca)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarMarArt", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "INSERTAR");
                    cmd.Parameters.AddWithValue("@COD_MAR", marca.COD_MAR);
                    cmd.Parameters.AddWithValue("@DES_MAR", marca.DES_MAR);
                    cmd.Parameters.AddWithValue("@COD_USER", marca.COD_USER);
                    cmd.Parameters.AddWithValue("@FEC_ABM", marca.FEC_ABM);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public void ActualizarMarca(MarcasArticulos marca)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarMarArt", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "EDITAR");
                    cmd.Parameters.AddWithValue("@COD_MAR", marca.COD_MAR);
                    cmd.Parameters.AddWithValue("@DES_MAR", marca.DES_MAR);
                    cmd.Parameters.AddWithValue("@COD_USER", marca.COD_USER);
                    cmd.Parameters.AddWithValue("@FEC_ABM", marca.FEC_ABM);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public void EliminarMarca(string codMar)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarMarArt", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "ELIMINAR");
                    cmd.Parameters.AddWithValue("@COD_MAR", codMar);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public MarcasArticulos BuscarMarcaPorCodigo(string codMar)
        {
            MarcasArticulos marca = null;
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarMarArt", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "BUSCAR");
                    cmd.Parameters.AddWithValue("@COD_MAR", codMar);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            marca = new MarcasArticulos(
                                reader["COD_MAR"].ToString(),
                                reader["DES_MAR"].ToString(),
                                reader["COD_USER"].ToString(),
                                Convert.ToDateTime(reader["FEC_ABM"])
                            );
                        }
                    }
                }
                con.Close();
            }
            return marca;
        }

        public List<MarcasArticulos> BuscarTodasLasMarcas()
        {
            List<MarcasArticulos> marcas = new List<MarcasArticulos>();
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarMarArt", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "BUSCARTODOS");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MarcasArticulos marca = new MarcasArticulos(
                                reader["COD_MAR"].ToString(),
                                reader["DES_MAR"].ToString(),
                                reader["COD_USER"].ToString(),
                                Convert.ToDateTime(reader["FEC_ABM"])
                            );
                            marcas.Add(marca);
                        }
                    }
                }
                con.Close();
            }
            return marcas;
        }
    }
}
