using System.Collections.Generic;

namespace Entidades
{
    public interface IListaDeposito<T> where T : Producto
    {
        /// <summary>
        /// Agrega una lista de productos al deposito
        /// </summary>
        /// <param name="lista">Lista que contiene los productos a ingresar</param>
        /// <returns>Retorna true si se agrego correctamente</returns>
        public bool AgregarLista(List<T> lista);
    }
}