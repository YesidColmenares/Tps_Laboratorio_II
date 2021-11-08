using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    public class Archivo
    {
        /// <summary>
        /// Carga un archivo txt de productos
        /// </summary>
        /// <param name="path">Ruta al archivo</param>
        /// <param name="plataforma">Plataforma del producto, si es Amazon o MercadoLibre</param>
        /// <returns>Retorna una lista de productos</returns>
        /// <exception cref="ArgumentNullException">Si el path es null</exception>
        /// <exception cref="Exception">Otras excepciones</exception>
        public static List<Producto> CargarTxt(string path, EPlataforma plataforma)
        {
            List<Producto> listaAux = new List<Producto>();
            string linea;
            string[] array;

            if (path is not null)
            {
                using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
                {
                    while (!reader.EndOfStream)
                    {
                        linea = reader.ReadLine();
                        array = linea.Split(',');
                        float.TryParse(array[2], out float precio);
                        int.TryParse(array[3], out int cantidad);

                        if (plataforma == EPlataforma.MercadoLibre)
                        {
                            listaAux.Add(new MercadoLibre(array[0], array[1], precio, cantidad, array[4], array[5], array[6]));
                        }
                        else if (plataforma == EPlataforma.Amazon)
                        {
                            listaAux.Add(new Amazon(array[0], array[1], precio, cantidad, array[4], array[5], array[6]));
                        }
                    }
                }
            }
            else
            {
                throw new ArgumentNullException("Archivo","La ruta al archivo txt es null");
            }

            return listaAux;
        }
        /// <summary>
        /// Guarda una lista de productos en un archivo txt
        /// </summary>
        /// <param name="path">Ruta al archivo</param>
        /// <param name="lista">La lista de productos a guardar</param>
        /// <param name="plataforma">La plataforma del tipo de Producto a guardar</param>
        /// <exception cref="ArgumentNullException">Si el path es null</exception>
        /// <exception cref="Exception">Otras excepciones</exception>
        public static bool GuardarTxt(string path, List<Producto> lista, EPlataforma plataforma)
        {
            bool valor = false;

            if (path is not null)
            {
                using (StreamWriter writer = new StreamWriter(path, false, Encoding.UTF8))
                {
                    foreach (Producto item in lista)
                    {
                        if (item.GetType().Name == plataforma.ToString())
                        {
                            writer.WriteLine($"{item.Id},{item.Nombre},{item.Precio},{item.Cantidad},{item.Condicion}," +
                            $"{item.Estado},{item.TipoPublicacion}");
                        }
                    }
                    valor = true;
                }
            }
            else
            {
                throw new ArgumentNullException("Archivo", "La ruta al archivo txt es null");
            }

            return valor;
        }


        /// <summary>
        /// Guarda y realiza una serializacion de una lista de productos
        /// </summary>
        /// <param name="path">Ruta al archivo</param>
        /// <param name="lista">Lista de productos a guardar</param>
        /// <param name="type">Tipo a guardar</param>
        /// <returns>True si ese guardo correctamente</returns>
        /// <exception cref="ArgumentNullException">Si el path es null</exception>
        /// <exception cref="Exception">Otras excepciones</exception>
        public static bool GuardarXml(string path, List<Producto> lista, Type type)
        {
            bool valor = false;

            if (path is not null)
            {
                using (XmlTextWriter writer = new XmlTextWriter(path, Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(type);

                    ser.Serialize(writer, lista);
                    valor = true;
                }
            }
            else
            {
                throw new ArgumentNullException("Archivo", "La ruta al archivo xml es null");
            }
            return valor;
        }
        /// <summary>
        /// Cargar una serializacion 
        /// </summary>
        /// <param name="path">Ruta al archivo</param>
        /// <param name="type">Tipo a deserializar</param>
        /// <returns>Retorna una lista con los productos cargados</returns>
        /// <exception cref="ArgumentNullException">Si el path es null</exception>
        /// <exception cref="Exception">Otras excepciones</exception>
        public static List<Producto> CargarXml(string path, Type type)
        {
            List<Producto> lista;

            if (path is not null)
            {
                using (XmlTextReader reader = new XmlTextReader(path))
                {
                    XmlSerializer ser = new XmlSerializer(type);

                    lista = (List<Producto>)ser.Deserialize(reader);
                }
            }
            else
            {
                throw new ArgumentNullException("Archivo", "La ruta al archivo txt es null");
            }

            return lista;
        }
    }
}
