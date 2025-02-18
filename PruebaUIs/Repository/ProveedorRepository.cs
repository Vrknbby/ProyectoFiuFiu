using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaUIs.DB;
using PruebaUIs.Model;
using System.Data;
using System.Data.SqlClient;
namespace PruebaUIs.Repository
{
    class ProveedorRepository
    {
        private readonly ConexionBD conexion;

        public ProveedorRepository()
        {
            conexion = new ConexionBD();
        }

        public void InsertarProveedor(Proveedor proveedor)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarProveedor", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "INSERTAR");
                    cmd.Parameters.AddWithValue("@COD_PRV", proveedor.COD_PRV);
                    cmd.Parameters.AddWithValue("@COD_PER", proveedor.COD_PER);
                    cmd.Parameters.AddWithValue("@FLG_INH_MOV", proveedor.FLG_INH_MOV);
                    cmd.Parameters.AddWithValue("@VAL_TIE_ATC", proveedor.VAL_TIE_ATC);
                    cmd.Parameters.AddWithValue("@VAL_CMN_UMO", proveedor.VAL_CMN_UMO);
                    cmd.Parameters.AddWithValue("@COD_USER", proveedor.COD_USER);
                    cmd.Parameters.AddWithValue("@FEC_ABM", proveedor.FEC_ABM);
   
                    cmd.ExecuteNonQuery();

                }
                con.Close();
            }

        }

        public void ActualizarProveedor(Locacion locacion)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarProveedor", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "EDITAR");
                    cmd.Parameters.AddWithValue("@COD_PRV", locacion.COD_USER);
                    cmd.Parameters.AddWithValue("@COD_PER", locacion.COD_USER);
                    cmd.Parameters.AddWithValue("@FLG_INH_MOV", locacion.COD_USER);
                    cmd.Parameters.AddWithValue("@VAL_TIE_ATC", locacion.COD_USER);
                    cmd.Parameters.AddWithValue("@VAL_CMN_UMO", locacion.COD_USER);
                    cmd.Parameters.AddWithValue("@COD_USER", locacion.COD_USER);
                    cmd.Parameters.AddWithValue("@FEC_ABM", locacion.COD_USER);

                    cmd.ExecuteNonQuery();

                }
                con.Close();
            }

        }

        public List<Proveedor> BuscarTodosLosProveedores()
        {
            List<Proveedor> proveedores = new List<Proveedor>();

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarProveedor", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "BUSCARTODOS");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Proveedor proveedor = new Proveedor(
                                reader["COD_PRV"].ToString(),
                                reader["COD_PER"].ToString(),
                                Convert.ToBoolean(reader["FLG_INH_MOV"]),
                                Convert.ToInt32(reader["VAL_TIE_ATC"]),
                                Convert.ToInt32(reader["VAL_CMN_UMO"]),
                                reader["COD_USER"].ToString(),
                                Convert.ToDateTime(reader["FEC_ABM"])
                                
                              
                                
                            );
                            proveedores.Add(proveedor);
                        }
                    }
                }
                con.Close();
            }
            return proveedores;
        }

        public Proveedor BuscarProveedorPorCodigo(string codPrv)
        {
            Proveedor proveedor = null;

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarProveedor", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "BUSCAR");
                    cmd.Parameters.AddWithValue("@COD_PRV", codPrv);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            proveedor = new Proveedor(
                                  reader["COD_PRV"].ToString(),
                                reader["COD_PER"].ToString(),
                                Convert.ToBoolean(reader["FLG_INH_MOV"]),
                                Convert.ToInt32(reader["VAL_TIE_ATC"]),
                                Convert.ToInt32(reader["VAL_CMN_UMO"]),
                                reader["COD_USER"].ToString(),
                                Convert.ToDateTime(reader["FEC_ABM"])
                            );
                        }
                    }
                }
                con.Close();
            }
            return proveedor;
        }


    }
}
