using PruebaUIs.DB;
using PruebaUIs.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaUIs.Repository
{
    public class UsuarioRepository
    {
        private readonly ConexionBD conexion;


        public UsuarioRepository()
        {
            conexion = new ConexionBD();
        }


        public void InsertarUsuario(Usuario usuario)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarUsuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "INSERTAR");
                    cmd.Parameters.AddWithValue("@COD_USER", usuario.COD_USER);
                    cmd.Parameters.AddWithValue("@DES_USER", usuario.DES_USER);
                    cmd.Parameters.AddWithValue("@EMAIL_USER", usuario.EMAIL_USER);
                    cmd.Parameters.AddWithValue("@CLAVE_USER", usuario.CLAVE_USER);
                    cmd.Parameters.AddWithValue("@FLG_EST_USER", usuario.FLG_EST_USER);
                    cmd.Parameters.AddWithValue("@FEC_ABM", usuario.FEC_ABM);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
            

        }

        public void ActualizarUsuario(Usuario usuario)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarUsuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "EDITAR");
                    cmd.Parameters.AddWithValue("@COD_USER", usuario.COD_USER);
                    cmd.Parameters.AddWithValue("@DES_USER", usuario.DES_USER);
                    cmd.Parameters.AddWithValue("@EMAIL_USER", usuario.EMAIL_USER);
                    cmd.Parameters.AddWithValue("@CLAVE_USER", usuario.CLAVE_USER);
                    cmd.Parameters.AddWithValue("@FLG_EST_USER", usuario.FLG_EST_USER);
                    cmd.Parameters.AddWithValue("@FEC_ABM", usuario.FEC_ABM);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public void EliminarUsuario(Usuario usuario)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarUsuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "ELIMINAR");
                    cmd.Parameters.AddWithValue("@COD_USER", usuario.COD_USER);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public List<Usuario> BuscarTodosLosUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarUsuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "BUSCARTODOS");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Usuario usuario = new Usuario(
                                reader["COD_USER"].ToString(),
                                reader["DES_USER"].ToString(),
                                reader["EMAIL_USER"].ToString(),
                                reader["CLAVE_USER"].ToString(),
                                Convert.ToBoolean(reader["FLG_EST_USER"]),
                                Convert.ToDateTime(reader["FEC_ABM"])
                            );
                            usuarios.Add(usuario);
                        }
                    }
                }
                con.Close();
            }
            return usuarios;
        }

        public Usuario BuscarUsuarioPorCodigo(string codUser)
        {
            Usuario usuario = null;

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarUsuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "BUSCAR");
                    cmd.Parameters.AddWithValue("@COD_USER", codUser);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) 
                        {
                            usuario = new Usuario(
                                reader["COD_USER"].ToString(),
                                reader["DES_USER"].ToString(),
                                reader["EMAIL_USER"].ToString(),
                                reader["CLAVE_USER"].ToString(),
                                Convert.ToBoolean(reader["FLG_EST_USER"]),
                                Convert.ToDateTime(reader["FEC_ABM"])
                            );
                        }
                    }
                }
                con.Close();
            }
            return usuario; 
        }

        public bool ValidarCredenciales(string email, string clave)
        {
            bool credencialesValidas = false;

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarUsuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "VALIDAR");
                    cmd.Parameters.AddWithValue("@EMAIL_USER", email);
                    cmd.Parameters.AddWithValue("@CLAVE_USER", clave);

                    try
                    {
                        int resultado = Convert.ToInt32(cmd.ExecuteScalar());
                        credencialesValidas = (resultado == 1);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al validar credenciales: " + ex.Message);
                    }
                }
            }

            return credencialesValidas;
        }

        public bool CorreoExiste(string correo)
        {
            bool existe = false;

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spGestionarUsuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CACCION", "BUSCARCORREO");
                    cmd.Parameters.AddWithValue("@EMAIL_USER", correo);

                    existe = Convert.ToBoolean(cmd.ExecuteScalar());
                }
                con.Close();
            }
            return existe;
        }
    }
}
