using PruebaUIs.DB;
using PruebaUIs.Model;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaUIs.Model.Parametros;

namespace PruebaUIs.Repository.Parametros
{
    class VendedorRepository
    {

        private readonly ConexionBD conexion;

        public VendedorRepository()
        {
            conexion = new ConexionBD();
        }


        public void InsertarVendedor(Vendedor vendedor)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarVendedor", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "INSERTAR");
                    cmd.Parameters.AddWithValue("@COD_VEN", vendedor.COD_VEN);
                    cmd.Parameters.AddWithValue("@FLG_INH_MOV", vendedor.FLG_INH_MOV);
                    cmd.Parameters.AddWithValue("@COD_USER", vendedor.COD_USER);
                    cmd.Parameters.AddWithValue("@FEC_ABM", vendedor.FEC_ABM);

                    cmd.ExecuteNonQuery();

                }
                con.Close();
            }

        }

        public void ActualizarVendedor(Vendedor vendedor)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarVendedor", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "INSERTAR");
                    cmd.Parameters.AddWithValue("@COD_VEN", vendedor.COD_VEN);
                    cmd.Parameters.AddWithValue("@FLG_INH_MOV", vendedor.FLG_INH_MOV);
                    cmd.Parameters.AddWithValue("@COD_USER", vendedor.COD_USER);
                    cmd.Parameters.AddWithValue("@FEC_ABM", vendedor.FEC_ABM);

                    cmd.ExecuteNonQuery();

                }
                con.Close();
            }

        }

        public List<Vendedor> BuscarTodosLosVendedores()
        {
            List<Vendedor> vendedores = new List<Vendedor>();

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarVendedor", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "BUSCARTODOS");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Vendedor vendedor = new Vendedor(
                                reader["COD_VEN"].ToString(),
                                reader["COD_PER"].ToString(),
                                Convert.ToBoolean(reader["FLG_INH_MOV"]),
                                reader["COD_USER"].ToString(),
                                Convert.ToDateTime(reader["FEC_ABM"])

                            );
                            vendedores.Add(vendedor);
                        }
                    }
                }
                con.Close();
            }
            return vendedores;
        }
        public Vendedor BuscarVendedorPorCodigo(string codVen)
        {
            Vendedor vendedor = null;

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarVendedor", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "BUSCAR");
                    cmd.Parameters.AddWithValue("@COD_VEN", codVen);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            vendedor = new Vendedor(
                                  reader["COD_VEN"].ToString(),
                                reader["COD_PER"].ToString(),
                                Convert.ToBoolean(reader["FLG_INH_MOV"]),
                                reader["COD_USER"].ToString(),
                                Convert.ToDateTime(reader["FEC_ABM"])
                            );
                        }
                    }
                }
                con.Close();
            }
            return vendedor;
        }

    }
}
