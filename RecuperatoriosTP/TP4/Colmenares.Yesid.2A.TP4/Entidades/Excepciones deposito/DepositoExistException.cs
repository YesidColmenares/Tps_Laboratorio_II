using System;
using System.Runtime.Serialization;
using System.Text;

namespace Entidades
{
    public class DepositoExistException : DepositoException
    {
        /// <summary>
        /// Constante que contiene el mensaje del error 
        /// </summary>
        private const string mensajeErrorExistException = "El ID del producto ya existe en el deposito";

        /// <summary>
        /// Excepcion DepositoExist
        /// </summary>
        public DepositoExistException() : base(mensajeErrorExistException)
        {
        }

        /// <summary>
        /// Excepcion DepositoExist
        /// </summary>
        /// <param name="innerException">Excepcion raiz</param>
        public DepositoExistException(Exception innerException) : base(mensajeErrorExistException, innerException)
        {
        }

        /// <summary>
        /// Excepcion DepositoExist
        /// </summary>
        /// <param name="innerException">Excepcion raiz</param>
        /// <param name="origenError">string con el origen del error</param>
        public DepositoExistException(Exception innerException, string origenError) : base(mensajeErrorExistException, innerException, origenError)
        {

        }
    }
}