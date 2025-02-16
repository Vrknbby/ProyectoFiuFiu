using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaUIs.DB;
using PruebaUIs.Model;

namespace PruebaUIs.Service
{
    public class UsuarioService
    {
        private readonly ConexionBD conexion;

        public UsuarioService()
        {
            conexion = new ConexionBD();
        }


        public void GestionarUsuario(Usuario usuario, string Accion)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("spGestionarUsuario", con))
                {


                    if (Accion == "ELIMINAR")
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CACCION", Accion);
                        cmd.Parameters.AddWithValue("@COD_USER", usuario.DES_USER);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CACCION", Accion);
                        cmd.Parameters.AddWithValue("@COD_USER", usuario.COD_USER);
                        cmd.Parameters.AddWithValue("@DES_USER", usuario.DES_USER);
                        cmd.Parameters.AddWithValue("@EMAIL_USER", usuario.EMAIL_USER);
                        cmd.Parameters.AddWithValue("@CLAVE_USER", usuario.CLAVE_USER);
                        cmd.Parameters.AddWithValue("@FLG_EST_USER", usuario.FLG_EST_USER);
                        cmd.Parameters.AddWithValue("@FEC_ABM", usuario.FEC_ABM);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }

    
}
