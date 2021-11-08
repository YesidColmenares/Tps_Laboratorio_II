using System;
using System.Collections;
using System.Collections.Generic;

namespace Entidades
{
    public interface IGestionDeposito<T>
        where T : Producto
    {
        /// <summary>
        /// Retorna la posicion del producto en el deposito
        /// </summary>
        /// <param name="t">Producto</param>
        /// <returns>Retorna el index si este producto existe, de lo contrario -1</returns>
        public int ObtenerIndex(T t);

        /// <summary>
        /// Agrega un producto al deposito
        /// </summary>
        /// <param name="t">Producto</param>
        public void Agregar(T t);

        /// <summary>
        /// Elimina un producto del deposito
        /// </summary>
        /// <param name="t">Producto</param>
        /// <returns>Retorna true si se elimino el producto</returns>
        public bool Eliminar(T t);

        /// <summary>
        /// Verifica si existe el producto en el deposito
        /// </summary>
        /// <param name="t">Producto</param>
        /// <returns>Retorna true si existe en el deposito, de lo contrario false</returns>
        public bool Contiene(T t);

        /// <summary>
        /// Remplaza un producto del deposito
        /// </summary>
        /// <param name="t">Producto</param>
        /// <returns>Retorna true si se remplazo correctamente</returns>
        public bool Remplazar(T t);

        /// <summary>
        /// Limpia el deposito
        /// </summary>
        public void Limpiar();
    }
}