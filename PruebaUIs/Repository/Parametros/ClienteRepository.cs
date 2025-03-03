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
    public class ClienteRepository
    {
        private readonly ConexionBD conexion;

        public ClienteRepository()
        {
            conexion = new ConexionBD();
        }

        public void InsertarCliente(Cliente cliente)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarCliente", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "INSERTAR");
                    cmd.Parameters.AddWithValue("@COD_CLI", cliente.COD_CLI);
                    cmd.Parameters.AddWithValue("@COD_PER", cliente.COD_PER);
                    cmd.Parameters.AddWithValue("@COD_GRP_EMP", cliente.COD_GRP_EMP);
                    cmd.Parameters.AddWithValue("@COD_VEN", cliente.COD_VEN);
                    cmd.Parameters.AddWithValue("@COD_SEG", cliente.COD_SEG);
                    cmd.Parameters.AddWithValue("@COD_SSEG", cliente.COD_SSEG);
                    cmd.Parameters.AddWithValue("@FLG_INH_MOV", cliente.FLG_INH_MOV);
                    cmd.Parameters.AddWithValue("@COD_USER", cliente.COD_USER);
                    cmd.Parameters.AddWithValue("@FEC_ABM", cliente.FEC_ABM);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public void ActualizarCliente(Cliente cliente)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarCliente", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "EDITAR");
                    cmd.Parameters.AddWithValue("@COD_CLI", cliente.COD_CLI);
                    cmd.Parameters.AddWithValue("@COD_PER", cliente.COD_PER);
                    cmd.Parameters.AddWithValue("@COD_GRP_EMP", cliente.COD_GRP_EMP);
                    cmd.Parameters.AddWithValue("@COD_VEN", cliente.COD_VEN);
                    cmd.Parameters.AddWithValue("@COD_SEG", cliente.COD_SEG);
                    cmd.Parameters.AddWithValue("@COD_SSEG", cliente.COD_SSEG);
                    cmd.Parameters.AddWithValue("@FLG_INH_MOV", cliente.FLG_INH_MOV);
                    cmd.Parameters.AddWithValue("@COD_USER", cliente.COD_USER);
                    cmd.Parameters.AddWithValue("@FEC_ABM", cliente.FEC_ABM);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public void EliminarCliente(string codCli)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarCliente", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "ELIMINAR");
                    cmd.Parameters.AddWithValue("@COD_CLI", codCli);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public Cliente BuscarClientePorCodigo(string codCli)
        {
            Cliente cliente = null;
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarCliente", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "BUSCAR");
                    cmd.Parameters.AddWithValue("@COD_CLI", codCli);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cliente = new Cliente(
                                reader["COD_CLI"].ToString(),
                                reader["COD_PER"].ToString(),
                                reader["COD_GRP_EMP"].ToString(),
                                reader["COD_VEN"].ToString(),
                                reader["COD_SEG"].ToString(),
                                reader["COD_SSEG"].ToString(),
                                Convert.ToBoolean(reader["FLG_INH_MOV"]),
                                reader["COD_USER"].ToString(),
                                Convert.ToDateTime(reader["FEC_ABM"])
                            );
                        }
                    }
                }
                con.Close();
            }
            return cliente;
        }

        public List<Cliente> BuscarTodosLosClientes()
        {
            List<Cliente> lista = new List<Cliente>();
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarCliente", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "BUSCARTODOS");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cliente cliente = new Cliente(
                                reader["COD_CLI"].ToString(),
                                reader["COD_PER"].ToString(),
                                reader["COD_GRP_EMP"].ToString(),
                                reader["COD_VEN"].ToString(),
                                reader["COD_SEG"].ToString(),
                                reader["COD_SSEG"].ToString(),
                                Convert.ToBoolean(reader["FLG_INH_MOV"]),
                                reader["COD_USER"].ToString(),
                                Convert.ToDateTime(reader["FEC_ABM"])
                            );
                            lista.Add(cliente);
                        }
                    }
                }
                con.Close();
            }
            return lista;
        }
    }
}
