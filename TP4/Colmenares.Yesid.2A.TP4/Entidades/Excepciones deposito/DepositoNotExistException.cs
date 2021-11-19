using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DepositoNotExistException : DepositoException
    {
        /// <summary>
        /// Constante que contiene el mensaje del error 
        /// </summary>
        private const string mensajeNotExistException = "El ID del producto no existe en el deposito";

        /// <summary>
        /// Excepcion DepositoNotExist
        /// </summary>
        public DepositoNotExistException() : base(mensajeNotExistException)
        {
        }

        /// <summary>
        /// Excepcion DepositoNotExist
        /// </summary>
        /// <param name="innerException">Excepcion raiz</param>
        public DepositoNotExistException(Exception innerException) : base(mensajeNotExistException, innerException)
        {
        }

        /// <summary>
        /// Excepcion DepositoNotExist
        /// </summary>
        /// <param name="innerException">Excepcion raiz</param>
        /// <param name="origenError">string con el origen del error</param>
        public DepositoNotExistException(Exception innerException, string origenError) : base(mensajeNotExistException, innerException, origenError)
        {
        }
    }
}
