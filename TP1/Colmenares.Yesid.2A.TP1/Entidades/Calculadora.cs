using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double valor = 0;

            if (num1 != null || num2 != null) 
            {
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
            }
            return valor;
        }
        private static char ValidarOperador(char operador)
        {
            char valor = '+';

            if (operador.Equals('+') || operador.Equals('-') || operador.Equals('/') || operador.Equals('*'))
            {
                valor = operador;
            }
            return valor;
        }
    }
}
