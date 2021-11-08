using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Amazon : Producto
    {
        //CONSTRUCTORES
        /// <summary>
        /// Constructor por defecto para poder Serializar
        /// </summary>
        public Amazon()
        {

        }

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="id">ID del producto</param>
        /// <param name="nombre">Nombre del producto</param>
        /// <param name="precio">Precio del producto</param>
        /// <param name="cantidad">Cantidad del producto</param>
        /// <param name="condicion">Condicion del producto</param>
        /// <param name="estado">Estado del producto</param>
        /// <param name="tipoPublicacion">Tipo de publicacion</param>
        /// <param name="plataforma">Tipo de plataforma</param>
        public Amazon(string id, string nombre, float precio, int cantidad, string condicion, string estado, string tipoPublicacion) 
            : base (id, nombre, precio, cantidad, condicion, estado, tipoPublicacion)
        {

        }


        //IMPLEMENTACION METODO HEREDADO DE PRODUCTO
        /// <summary>
        /// Genera la informacion del producto Amazon
        /// </summary>
        /// <returns>Retorna un string con los datos</returns>
        protected override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("AMAZON | ");
            sb.Append(base.Mostrar());

            return sb.ToString();
        }


        //IMPLEMENTACION E INVALIDACION DE METODOS Object.ToString()
        /// <summary>
        /// Llama la funcion this.Mostrar()
        /// </summary>
        /// <returns>Retorna un string con los datos del producto</returns>
        public override string ToString()
        {
            return this.Mostrar();
        }
    }
}
