using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        /// <summary>
        /// Asignará el valor 0 al atributo numero
        /// </summary>
        public Operando() : this(0)
        {
        }

        /// <summary>
        /// Asignará el valor ingresado por el usuario 
        /// </summary>
        /// <param name="numero"> Valor double</param>
        public Operando(double numero) : this(numero.ToString())
        {
        }

        /// <summary>
        /// Asignará el valor ingresado por el usuario 
        /// </summary>
        /// <param name="strNumero">Valor string</param>
        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }


        /// <summary>
        /// comprobará que el valor recibido sea numérico. 
        /// </summary>
        /// <param name="strNumero"> Valor a validar</param>
        /// <returns>0 si el valor no es numerico o retorna un double con el valor</returns>
        private static double ValidarOperando(string strNumero)
        {
            double.TryParse(strNumero, out double valor);

            return valor;
        }

        /// <summary>
        /// Validará que la cadena de caracteres esté compuesta solamente por caracteres '0' y '1'
        /// </summary>
        /// <param name="binario">valor a validar</param>
        /// <returns>true si es binario, false si no es binario</returns>
        private static bool EsBinario(string binario)
        {
            bool retorno = false;

            foreach (char item in binario)
            {
                if (item != '1' && item != '0')
                {
                    retorno = false;
                    break;
                }
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Validará que se trate de un binario y luego convertirá ese número binario a decimal 
        /// </summary>
        /// <param name="binario">valor a convertir</param>
        /// <returns>El valor convertido a decimal o "Valor inválido" en caso que no se convierta</returns>
        public static string BinarioDecimal(string binario)
        {
            string numeroDecimal = "Valor inválido";

            if (Operando.EsBinario(binario))
            {
                numeroDecimal = Convert.ToInt32(binario, 2).ToString();
            }
            return numeroDecimal;
        }

        /// <summary>
        /// Validará que se trate de un decimal y luego convertirá ese número decimal a binario
        /// </summary>
        /// <param name="numero">valor a convertir</param>
        /// <returns>El valor convertido a binario o "Valor inválido" en caso que no se convierta</returns>
        public static string DecimalBinario(double numero)
        {
            return Operando.DecimalBinario(numero.ToString());
        }

        /// <summary>
        /// Validará que se trate de un decimal y luego convertirá ese número decimal a binario
        /// </summary>
        /// <param name="numero">valor a convertir</param>
        /// <returns>El valor convertido a binario o "Valor inválido" en caso que no se convierta</returns>
        public static string DecimalBinario(string numero)
        {
            long numeroDecimal;
            string numeroBinario = "Valor inválido";

            if (long.TryParse(numero, out numeroDecimal))
            {
                numeroBinario = Convert.ToString(numeroDecimal, 2);
            }
            
            return numeroBinario;
        }



        /// <summary>
        /// Sobrecarga del operador '-', me permite realizar la resta entre dos objetos de tipo Operando
        /// </summary>
        /// <param name="n1">Operando 1 </param>
        /// <param name="n2">Operando 2 </param>
        /// <returns>Un double con el resultado de la resta</returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador '*', me permite realizar la muliplicación entre dos objetos de tipo Operando
        /// </summary>
        /// <param name="n1">Operando 1 </param>
        /// <param name="n2">Operando 2 </param>
        /// <returns>Un double con el resultado de la muliplicación</returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador '/', me permite realizar la división entre dos objetos de tipo Operando
        /// </summary>
        /// <param name="n1">Operando 1 </param>
        /// <param name="n2">Operando 2 </param>
        /// <returns>Un double con el resultado de la división solo si el divisor es distinto de 0, en caso de serlo retornará double.MinValue</returns>
        public static double operator /(Operando n1, Operando n2)
        {
            double resultado = double.MinValue;

            if (n2.numero != 0)
            {
                resultado = n1.numero / n2.numero;
            }
            return resultado;
        }

        /// <summary>
        /// Sobrecarga del operador '+', me permite realizar la suma entre dos objetos de tipo Operando
        /// </summary>
        /// <param name="n1">Operando 1</param>
        /// <param name="n2">Operando 2</param>
        /// <returns>Un double con el resultado de la suma</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Validará y asignará un valor al atributo numero
        /// </summary>
        public string Numero
        {
            set 
            { 
                this.numero = Operando.ValidarOperando(value); 
            }
        }
    }
}
