using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class SqlExtension
    {
        /// <summary>
        /// Realiza una prueba de conexion a la base de datos
        /// </summary>
        /// <param name="servidor">Nombre del servidor</param>
        /// <param name="nombreBaseDatos">Nombre de la base de datos</param>
        /// <returns>Retorna true si se pudo establecer conexion, false lo contrario</returns>
        public static bool ProbarConexion(this Sql sql, string servidor, string nombreBaseDatos)
        {
            bool valor = true;
            SqlConnection connection;

            try
            {
                if (servidor != "" && nombreBaseDatos != "")
                {
                    using (connection = new SqlConnection($"Server={servidor};Database={nombreBaseDatos};Trusted_Connection=True;"))
                    {
                        connection.Open();
                    }
                }
                else
                {
                    valor = false;
                }
            }
            catch (Exception)
            {
                valor = false;
            }

            return valor;
        }
    }
}
