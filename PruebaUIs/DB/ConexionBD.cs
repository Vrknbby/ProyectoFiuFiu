using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace PruebaUIs.DB
{
    public class ConexionBD
    {
        private readonly string cadenaConexion;

        public ConexionBD()
        {
            cadenaConexion = "Server=DESKTOP-TP8INE4;Database=Prueba02;Integrated Security=True;";
        }



        public SqlConnection ObtenerConexion()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
                return null;
            }

        }

        public DataTable EjecutarConsulta(string consulta)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                if (conexion == null) return null;

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    DataTable tabla = new DataTable();
                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                    }
                    return tabla;
                }
            }
        }


        public bool EjecutarComando(string comandoSQL)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                if (conexion == null) return false;
                using (SqlCommand comando = new SqlCommand(comandoSQL, conexion))
                {
                    int filasafectadas = comando.ExecuteNonQuery();
                    return filasafectadas > 0;
                }
            }
        }
    }
}
