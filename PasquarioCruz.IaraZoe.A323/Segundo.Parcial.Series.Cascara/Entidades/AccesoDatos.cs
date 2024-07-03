using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class AccesoDatos
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        static AccesoDatos()
        {
            string connectionString = "Data Source=.;Initial Catalog=20240701-SP;Integrated Security=True";
            conexion = new SqlConnection(connectionString);
            comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = System.Data.CommandType.Text;
        }

        public static void ActualizarSerie(Serie item)
        {
            try
            {
                string query = "UPDATE series SET alumno = @alumno WHERE nombre = @nombre";
                comando.CommandText = query;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@nombre", item.Nombre);
                comando.Parameters.AddWithValue("@alumno", "nombre_del_alumno"); 


                conexion.Open();
                comando.ExecuteNonQuery();

                // Log de la operación
                Logger.Log($"Se actualizó la serie {item.Nombre}");
            }
            catch (Exception ex)
            {
                // Log de la excepción
                Logger.Log(ex);

                throw new Exception("Error al actualizar la serie en la base de datos.", ex);
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        public static List<Serie> ObtenerBacklog()
        {
            List<Serie> series = new List<Serie>();
            try
            {
                string query = "SELECT nombre, genero FROM series";

                comando.CommandText = query;

                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    string nombre = reader["nombre"].ToString();
                    string genero = reader["genero"].ToString();
                   

                    Serie serie = new Serie(nombre, genero);
                    series.Add(serie);
                }
                reader.Close();

               
                Logger.Log("Se obtuvo el backlog correctamente");
            }
            catch (Exception ex)
            {
               
                Logger.Log(ex);

                throw new Exception("Error al obtener el backlog de la base de datos", ex);
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return series;
        }
    }
}
