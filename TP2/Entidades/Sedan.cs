using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        private ETipo tipo;


        /// <summary>
        /// Por defecto, TIPO será CuatroPuertas
        /// </summary>
        /// <param name="marca">Marca del vehiculo</param>
        /// <param name="chasis">Numero de serie del vehiculo</param>
        /// <param name="color">Color del vehiculo</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color) : this(marca, chasis, color, ETipo.CuatroPuertas)
        {
        }


        /// <summary>
        /// Sobrecarga del constructor que agrega el parametro tipo de puerta
        /// </summary>
        /// <param name="marca">Marca del vehiculo</param>
        /// <param name="chasis">Numero de serie del vehiculo</param>
        /// <param name="color">Color del vehiculo</param>
        /// <param name="tipo">Tipo de puerta del vehiculo</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo) : base(chasis, marca, color)
        {
            this.tipo = tipo;
        }


        /// <summary>
        /// Muestra todos los datos del objeto de tipo Sedan
        /// </summary>
        /// <returns>Retorna un string con todo los datos del tipo Sedan</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }


        /// <summary>
        /// Sedan son 'Mediano'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return Vehiculo.ETamanio.Mediano;
            }
        }


        /// <summary>
        /// Enumerado que contiene el tipo de puerta del vehiculo
        /// </summary>
        public enum ETipo
        {
            CuatroPuertas,
            CincoPuertas
        }
    }
}
