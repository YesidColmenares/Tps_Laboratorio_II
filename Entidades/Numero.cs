using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double valor;

        private Numero(double valor)
        {
            this.valor = valor;
        }

        public static bool operator ==(Numero n1, Numero n2)
        {
            return n1.valor == n2.valor;
        }
        public static bool operator !=(Numero n1, Numero n2)
        {
            return !(n1 == n2);
        }

        public static bool operator ==(Numero n1, Double n2)
        {
            return n1.valor == n2;
        }
        public static bool operator !=(Numero n1, Double n2)
        {
            return !(n1 == n2);
        }

        public static Numero operator +(Numero n1, Numero n2)
        {
            double suma = n1.valor + n2.valor;

            return new Numero(suma);
        }
        public static Numero operator -(Numero n1, Numero n2)
        {
            double resta = n1.valor - n2.valor;

            return new Numero(resta);
        }

        public static implicit operator Numero(Double valor)
        {
            return new Numero(valor);
        }
        public static explicit operator Double(Numero n1)
        {
            return n1.valor;
        }

        public static Numero operator ++(Numero n1)
        {
            double incremento = n1.valor++;

            return new Numero(incremento);
        }

        public static Numero operator --(Numero n1)
        {
            double decremento = n1.valor--;

            return new Numero(decremento);
        }

    }
}
