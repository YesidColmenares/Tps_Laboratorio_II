using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        private string chasis;
        private ConsoleColor color;
        private EMarca marca;


        /// <summary>
        /// Constructor de la clase abstracta Vehiculo, crea un vehiculo con los siguientes atributos; Chasis, Marca y color
        /// </summary>
        /// <param name="chasis">Numero de serie del vehiculo</param>
        /// <param name="marca">Marca del vehiculo</param>
        /// <param name="color">Color del vehiculo</param>
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }


        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns>Retorna un string con todos los datos del vehiculo</returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }


        /// <summary>
        /// Conversion explicita del tipo Vehiculo a String
        /// </summary>
        /// <param name="p">Vehiculo a mostrar</param>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CHASIS: {0}\r\n", p.chasis);
            sb.AppendFormat("MARCA : {0}\r\n", p.marca);
            sb.AppendFormat("COLOR : {0}\r\n", p.color);
            sb.AppendLine("---------------------");
            sb.AppendFormat("\nTAMAÑO : {0}", p.Tamanio);

            return sb.ToString();
        }


        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1">Primer vehiculo a comparar</param>
        /// <param name="v2">Segundo vehiculo a comparar</param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return v1.chasis == v2.chasis;
        }

        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1">Primer vehiculo a comparar</param>
        /// <param name="v2">Segundo vehiculo a comparar</param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }


        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        protected abstract ETamanio Tamanio 
        { 
            get; 
        }


        /// <summary>
        /// Enumerado que contiene marcas de los vehiculos
        /// </summary>
        public enum EMarca
        {
            Chevrolet,
            Ford,
            Renault,
            Toyota,
            BMW,
            Honda,
            HarleyDavidson
        }
        /// <summary>
        /// Enumerado que contiene los tamanios de los vehiculos
        /// </summary>
        public enum ETamanio
        {
            Chico,
            Mediano,
            Grande
        }
    }
}
