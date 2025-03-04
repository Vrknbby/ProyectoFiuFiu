using PruebaUIs.DB;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fabricantes = PruebaUIs.Model.Parametros.Fabricante;

namespace PruebaUIs.Repository.Parametros
{
    class FabricanteRepository
    {
        private readonly ConexionBD conexion;

        public FabricanteRepository()
        {
            conexion = new ConexionBD();

        }

        public void InsertarFabricante(Fabricantes fabricante)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarFabricante", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "INSERTAR");
                    cmd.Parameters.AddWithValue("@COD_FABRICANTE", fabricante.COD_FABRICANTE);
                    cmd.Parameters.AddWithValue("@COD_PER", fabricante.COD_PER);
                    cmd.Parameters.AddWithValue("@COD_USER", fabricante.COD_USER);
                    cmd.Parameters.AddWithValue("@FEC_ABM", fabricante.FEC_ABM);

                    cmd.ExecuteNonQuery();

                }
                con.Close();
            }

        }

        public void ActualizarFabricante(Fabricantes fabricante)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarFabricante", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "EDITAR");
                    cmd.Parameters.AddWithValue("@COD_FABRICANTE", fabricante.COD_FABRICANTE);
                    cmd.Parameters.AddWithValue("@COD_PER", fabricante.COD_PER);
                    cmd.Parameters.AddWithValue("@COD_USER", fabricante.COD_USER);
                    cmd.Parameters.AddWithValue("@FEC_ABM", fabricante.FEC_ABM);

                    cmd.ExecuteNonQuery();

                }
                con.Close();
            }

        }
        public List<Fabricantes> BuscarTodosLosFabricantes()
        {
            List<Fabricantes> fabricantes = new List<Fabricantes>();

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarFabricante", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "BUSCARTODOS");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Fabricantes fabricante = new Fabricantes(
                                reader["COD_FABRICANTE"].ToString(),
                                reader["COD_PER"].ToString(),
                                reader["COD_USER"].ToString(),
                                Convert.ToDateTime(reader["FEC_ABM"])

                            );
                            fabricantes.Add(fabricante);
                        }
                    }
                }
                con.Close();
            }
            return fabricantes;
        }

        public Fabricantes BuscarFabricantePorCodigo(string codFab)
        {
            Fabricantes fabricante = null;

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarFabricante", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "BUSCAR");
                    cmd.Parameters.AddWithValue("@COD_FABRICANTE", codFab);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            fabricante = new Fabricantes(
                                  reader["COD_FABRICANTE"].ToString(),
                                reader["COD_PER"].ToString(),
                                reader["COD_USER"].ToString(),
                                Convert.ToDateTime(reader["FEC_ABM"])
                            );
                        }
                    }
                }
                con.Close();
            }
            return fabricante;
        }

        public void EliminarFabricante(string codFab)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarFabricante", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "ELIMINAR");
                    cmd.Parameters.AddWithValue("@COD_FABRICANTE", codFab);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }



    }
}
