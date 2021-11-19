using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciclomotor : Vehiculo
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="marca">Marca del vehiculo</param>
        /// <param name="chasis">Numero de serie del vehiculo</param>
        /// <param name="color">Color del vehiculo</param>
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color) : base (chasis, marca, color)
        {

        }
       

        /// <summary>
        /// Muestra todos los datos del objeto de tipo Ciclomotor
        /// </summary>
        /// <returns>Retorna un string con todo los datos del tipo Ciclomotor</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CICLOMOTOR");
            sb.Append(base.Mostrar());
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }


        /// <summary>
        /// Ciclomotor son 'Chico'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }
    }
}
