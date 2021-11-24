using System;

namespace Entidades
{
    public class DepositoException : Exception
    {
        /// <summary>
        /// Excepcion Deposito
        /// </summary>
        /// <param name="mensaje">Mensaje del error</param>
        public DepositoException(string mensaje)
            : base(mensaje)
        {
        }

        /// <summary>
        /// Excepcion Deposito
        /// </summary>
        /// <param name="mensaje">Mensaje del error</param>
        /// <param name="innerException">Excepcion raiz InnerException</param>
        public DepositoException(string mensaje, Exception innerException)
            : base(mensaje, innerException)
        {
        }

        /// <summary>
        /// Excepcion Deposito
        /// </summary>
        /// <param name="mensaje">Mensaje del error</param>
        /// <param name="innerException">Excepcion raiz InnerException</param>
        /// <param name="origenError">Origen del error</param>
        public DepositoException(string mensaje, Exception innerException, string origenError)
            : base(mensaje, innerException)
        {
            base.Source = origenError;
        }

        /// <summary>
        /// Retorna el mensaje del error y su origen
        /// </summary>
        /// <returns>string con la informacion</returns>
        public override string ToString()
        {
            return "Mensaje de error: " + base.Message + "\nOrigen: " + base.Source;
        }
    }
}