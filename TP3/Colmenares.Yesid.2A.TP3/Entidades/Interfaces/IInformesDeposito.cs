using System.Collections.Generic;

namespace Entidades
{
    public interface IInformesDeposito<T> where T : Producto
    {
        /// <summary>
        /// Genera un informe con el contenido del deposito
        /// </summary>
        /// <returns>Lista con el informe</returns>
        public List<T> InfoListaProductos();

        /// <summary>
        /// Genera un informe de los productos sin stock
        /// </summary>
        /// <returns>Lista con el informe</returns>
        public List<T> InfoSinStock();

        /// <summary>
        /// Genera un informe de los productos con stock
        /// </summary>
        /// <returns>Lista con el informe</returns>
        public List<T> InfoConStock();

        /// <summary>
        /// Genera un informe de los productos con estado activo
        /// </summary>
        /// <returns>Lista con el informe</returns>
        public List<T> InfoEstadoActivo();

        /// <summary>
        /// Genera un informe de los productos con estado inactivo
        /// </summary>
        /// <returns>Lista con el informe</returns>
        public List<T> InfoEstadoInactivo();

        /// <summary>
        /// Genera un informe de los productos con ningun estado
        /// </summary>
        /// <returns>Lista con el informe</returns>
        public List<T> InfoEstadoNinguno();

        /// <summary>
        /// Genera un informe de los productos con condicion nuevo
        /// </summary>
        /// <returns>Lista con el informe</returns>
        public List<T> InfoCondicionNuevo();

        /// <summary>
        /// Genera un informe de los productos con condicion usado
        /// </summary>
        /// <returns>Lista con el informe</returns>
        public List<T> InfoCondicionUsado();

        /// <summary>
        /// Genera un informe de los productos con condicion reacondicionado
        /// </summary>
        /// <returns>Lista con el informe</returns>
        public List<T> InfoCondicionReacondicionado();

        /// <summary>
        /// Genera un informe de los productos no tengan ninguna condicion
        /// </summary>
        /// <returns>Lista con el informe</returns>
        public List<T> InfoCondicionNinguno();
    }
}