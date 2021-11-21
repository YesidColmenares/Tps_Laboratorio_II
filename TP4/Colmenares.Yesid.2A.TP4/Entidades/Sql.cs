using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    public class Sql
    {
        //ATRIBUTOS
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;


        //CONSTRUCTOR
        /// <summary>
        /// Toma como parametro el nombre del servidor, de la base de datos y de la tabla
        /// </summary>
        /// <param name="servidor"></param>
        /// <param name="nombreBaseDatos"></param>
        /// <param name="tabla"></param>
        public Sql(string servidor, string nombreBaseDatos, string tabla)
        {
            this.Servidor = servidor;
            this.NombreBaseDatos = nombreBaseDatos;
            this.Tabla = tabla;
        }


        //METODOS
        /// <summary>
        /// Obtiene la lista de productos que estan en esa tabla y base de daos
        /// </summary>
        /// <param name="Tabla">Nombre de la tabla</param>
        /// <returns>Retorna la lista de productos</returns>
        public List<Producto> ObtenerLista(string Tabla)
        {
            List<Producto> l = null;

            try
            {
                using (this.connection = new SqlConnection($"Server={this.Servidor};Database={this.NombreBaseDatos};Trusted_Connection=True;"))
                {
                    this.command = new SqlCommand($"SELECT * FROM {Tabla}", this.connection);
                    this.connection.Open();

                    this.reader = this.command.ExecuteReader();

                    l = new List<Producto>();

                    while (this.reader.Read())
                    {
                        string id = (string)this.reader["ID"];
                        string nombre = (string)this.reader["Nombre"];
                        float precio = float.Parse(this.reader["Precio"].ToString());
                        int cantidad = (int)this.reader["Cantidad"];
                        string condicion = (string)this.reader["Condicion"];
                        string estado = (string)this.reader["Estado"];
                        string tipoPublicacion = (string)this.reader["TipoPublicacion"];

                        if (Tabla == "MercadoLibre")
                        {
                            l.Add(new MercadoLibre(id, nombre, precio, cantidad, condicion, estado, tipoPublicacion));
                        }
                        else if (Tabla == "Amazon")
                        {
                            l.Add(new Amazon(id, nombre, precio, cantidad, condicion, estado, tipoPublicacion));
                        }
                    }

                    this.reader.Close();
                }
            }
            catch (Exception)
            {
                l = null;
            }
            return l;
        }
        /// <summary>
        /// Agrega un producto a la base de datos
        /// </summary>
        /// <param name="p">Producto a agregar</param>
        /// <returns>True si se agrego correctamente, false si no se agrego</returns>
        public bool Agregar(Producto p)
        {
            bool valor = true;

            try
            {
                using (this.connection = new SqlConnection($"Server={this.Servidor};Database={this.NombreBaseDatos};Trusted_Connection=True;"))
                {
                    string queryString = $"INSERT INTO {this.Tabla} (ID, Nombre, Precio, Cantidad, Condicion, Estado, TipoPublicacion)";

                    queryString += $" VALUES('{p.Id}','{p.Nombre}', {p.Precio}, {p.Cantidad},'{p.Condicion}','{p.Estado}','{p.TipoPublicacion}')";

                    this.command = new SqlCommand(queryString, this.connection);

                    this.connection.Open();

                    if (this.command.ExecuteNonQuery() == 0)
                    {
                        valor = false;
                    }
                }

            }
            catch (Exception)
            {
                valor = false;
            }

            return valor;
        }
        /// <summary>
        /// Modifica un producto de la base de datos
        /// </summary>
        /// <param name="p">Producto a modificar</param>
        /// <returns>Retorna true si se modifico correctamente, false si no se modifico</returns>
        public bool Modificar(Producto p)
        {
            bool valor = true;
            try
            {
                using (this.connection = new SqlConnection($"Server={this.Servidor};Database={this.NombreBaseDatos};Trusted_Connection=True;"))
                {
                    this.command = new SqlCommand();

                    this.command.Parameters.AddWithValue("@ID", p.Id);
                    this.command.Parameters.AddWithValue("@Nombre", p.Nombre);
                    this.command.Parameters.AddWithValue("@Precio", p.Precio);
                    this.command.Parameters.AddWithValue("@Cantidad", p.Cantidad);
                    this.command.Parameters.AddWithValue("@Condicion", p.Condicion);
                    this.command.Parameters.AddWithValue("@Estado", p.Estado);
                    this.command.Parameters.AddWithValue("@TipoPublicacion", p.TipoPublicacion);

                    string queryString = $"UPDATE {this.Tabla} ";

                    queryString += "SET " +
                        "Nombre = @Nombre, " +
                        "Precio = @Precio, " +
                        "Cantidad = @Cantidad, " +
                        "Condicion = @Condicion, " +
                        "Estado = @Estado, " +
                        "TipoPublicacion = @TipoPublicacion " +
                        "WHERE ID = @ID";

                    this.command.Connection = this.connection;
                    this.command.CommandType = CommandType.Text;
                    this.command.CommandText = queryString;

                    this.connection.Open();

                    if (this.command.ExecuteNonQuery() == 0)
                    {
                        valor = false;
                    }
                }
            }
            catch (Exception)
            {
                valor = false;
            }

            return valor;
        }
        /// <summary>
        /// Elimina un producto de la base de datos
        /// </summary>
        /// <param name="p">Producto a eliminar</param>
        /// <returns>True si se elimino correctamente, false si hubo un error</returns>
        public bool Eliminar(Producto p)
        {
            bool valor = true;

            try
            {
                using (this.connection = new SqlConnection($"Server={this.Servidor};Database={this.NombreBaseDatos};Trusted_Connection=True;"))
                {
                    this.command = new SqlCommand($"DELETE FROM {this.Tabla} WHERE ID = {p.Id}", this.connection);

                    this.connection.Open();

                    if (this.command.ExecuteNonQuery() == 0)
                    {
                        valor = false;
                    }
                }
            }
            catch (Exception)
            {
                valor = false;
            }

            return valor;
        }


        //PROPIEDADES
        /// <summary>
        /// Servidor de la base de datos
        /// </summary>
        public string Servidor { get; set; }
        /// <summary>
        /// Nombre de la base de datos
        /// </summary>
        public string NombreBaseDatos { get; set; }
        /// <summary>
        /// Tabla de la base de datos
        /// </summary>
        public string Tabla { get; set; }
    }
}
