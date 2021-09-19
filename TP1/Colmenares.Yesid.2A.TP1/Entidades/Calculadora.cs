using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Validará y realizará la operación pedida entre ambos números.
        /// </summary>
        /// <param name="num1">Objeto de la clase Entidades.Operando</param>
        /// <param name="num2">Objeto de la clase Entidades.Operando</param>
        /// <param name="operador"> Caracter que contiene el operador </param>
        /// <returns>Resultado de la operación en un double</returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double valor = 0;

            switch (Calculadora.ValidarOperador(operador))
            {
                case '+':
                    valor = num1 + num2;
                    break;

                case '-':
                    valor = num1 - num2;
                    break;

                case '/':
                    valor = num1 / num2;
                    break;

                case '*':
                    valor = num1 * num2;
                    break;
            }
            return valor;
        }

        /// <summary>
        /// validará que el operador recibido sea ( + , - , / , *)
        /// </summary>
        /// <param name="operador"> Caracter que contiene el operador </param>
        /// <returns> En caso que no se encuentre el operador retornará '+'</returns>
        private static char ValidarOperador(char operador)
        {
            char valor = operador;

            if (operador.Equals('\0'))
            {
                valor = '+';
            }
            return valor;
        }
    }
}
