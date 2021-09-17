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

        public Operando() : this(0)
        {
        }
        public Operando(double numero)
        {
            this.numero = numero;
        }
        public Operando(string strNumero) : this()
        {
            double.TryParse(strNumero, out this.numero);
        }

        private static double ValidarOperando(string strNumero)
        {
            double valor = 0;
            double.TryParse(strNumero, out valor);

            return valor;
        }
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
        public static string BinarioDecimal(string binario)
        {
            string numeroDecimal = "Valor Invalido";

            if (Operando.EsBinario(binario))
            {
                numeroDecimal = Convert.ToInt32(binario, 2).ToString();
            }
            return numeroDecimal;
        }
        public static string DecimalBinario(double numero)
        {
            return Operando.DecimalBinario(numero.ToString());
        }
        public static string DecimalBinario(string numero)
        {
            double numeroDecimal;
            string numeroBinario = "Valor Invalido";

            if (double.TryParse(numero, out numeroDecimal)) 
            {
                numeroBinario = Convert.ToString((long) numeroDecimal,2);
            }
            return numeroBinario;
        }

        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
        public static double operator /(Operando n1, Operando n2)
        {
            double resultado = double.MinValue;

            if (n2.numero != 0)
            {
                resultado = n1.numero / n2.numero;
            }
            return resultado;
        }
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        public string Numero
        {
            set 
            { 
                this.numero = Operando.ValidarOperando(value); 
            }
        }
    }
}
