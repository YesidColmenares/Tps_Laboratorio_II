using System;
using System.Collections.Generic;

namespace Entidades
{
    public interface IControlDeposito<T> where T : Producto
    {
        /// <summary>
        /// Controla que los productos esten activos o inactivos
        /// </summary>
        /// <returns>Retorna una lista con el informe</returns>
        public List<T> ControlPausadas();
    }
}