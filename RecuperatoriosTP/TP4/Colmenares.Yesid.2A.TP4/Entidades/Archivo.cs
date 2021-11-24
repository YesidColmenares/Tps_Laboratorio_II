using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    public class Archivo
    {
        /// <summary>
        /// Carga un archivo txt
        /// </summary>
        /// <param name="path">Ruta al archivo</param>
        /// <returns>Retorna el archivo leido</returns>
        /// <exception cref="ArgumentNullException">Si el path es null</exception>
        /// <exception cref="Exception">Otras excepciones</exception>
        public static string CargarTxt(string path)
        {
            string txt;

            if (path is not null)
            {
                using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
                {
                    txt = reader.ReadToEnd();
                }
            }
            else
            {
                throw new ArgumentNullException("Archivo","La ruta al archivo txt es null");
            }

            return txt;
        }
        /// <summary>
        /// Guarda una cadena de caracteres 
        /// </summary>
        /// <param name="path">Ruta al archivo</param>
        /// <exception cref="ArgumentNullException">Si el path es null</exception>
        /// <exception cref="Exception">Otras excepciones</exception>
        public static bool GuardarTxt(string path, string txt)
        {
            bool valor = false;

            if (path is not null)
            {
                using (StreamWriter writer = new StreamWriter(path, false, Encoding.UTF8))
                {
                    writer.Write(txt);
                }
                valor = true;
            }
            else
            {
                throw new ArgumentNullException("Archivo", "La ruta al archivo txt es null");
            }

            return valor;
        }


        /// <summary>
        /// Guarda y realiza una serializacion XML de una lista de productos
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
        /// Cargar una serializacion XML
        /// </summary>
        /// <param name="path">Ruta al archivo</param>
        /// <param name="type">Tipo a deserializar</param>
        /// <returns>Retorna una lista con los productos cargados</returns>
        /// <exception cref="ArgumentNullException">Si el path es null</exception>
        /// <exception cref="Exception">Otras excepciones</exception>
        public static List<Producto> CargarXml(string path, Type type)
        {
            List<Producto> lista = null;

            if (path is not null)
            {
                using (XmlTextReader reader = new XmlTextReader(path))
                {
                    XmlSerializer ser = new XmlSerializer(type);

                    try
                    {
                        lista = (List<Producto>)ser.Deserialize(reader);
                    }
                    catch (InvalidOperationException exception)
                    {
                        throw new InvalidOperationException("El archivo esta roto o no contiene datos validos.");
                    }
                }
            }
            else
            {
                throw new ArgumentNullException("Archivo", "La ruta al archivo xml es null");
            }

            return lista;
        }
    }
}
