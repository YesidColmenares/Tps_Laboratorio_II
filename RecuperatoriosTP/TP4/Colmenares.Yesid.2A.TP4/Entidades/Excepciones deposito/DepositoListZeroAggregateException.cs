using System;
using System.Runtime.Serialization;

namespace Entidades
{
    public class DepositoListZeroAggregateException : DepositoException
    {
        /// <summary>
        /// Constante que contiene el mensaje del error 
        /// </summary>
        private const string mensajeErrorListZeroAggregateException = "No se agrego ningun producto al deposito";

        /// <summary>
        /// Excepcion DepositoListZeroAggregate
        /// </summary>
        public DepositoListZeroAggregateException() : base(mensajeErrorListZeroAggregateException)
        {

        }

        /// <summary>
        /// Excepcion DepositoListZeroAggregate
        /// </summary>
        /// <param name="innerException">Excepcion raiz</param>
        public DepositoListZeroAggregateException(Exception innerException) : base(mensajeErrorListZeroAggregateException, innerException)
        {
        }

        /// <summary>
        /// Excepcion DepositoListZeroAggregate
        /// </summary>
        /// <param name="innerException">Excepcion raiz</param>
        /// <param name="origenError">string con el origen del error</param>
        public DepositoListZeroAggregateException(Exception innerException, string origenError) : base(mensajeErrorListZeroAggregateException, innerException, origenError)
        {
        }
    }
}