using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Taller
    {
        private int espacioDisponible;
        private List<Vehiculo> vehiculos;

        #region "Constructores"
        /// <summary>
        /// Constructor por defecto privado que inicializa la lista de vehiculos
        /// </summary>
        private Taller()
        {
            this.vehiculos = new List<Vehiculo>();
        }
        /// <summary>
        /// Sobrecarga del constructor recibiendo como parametro el espacio que sera disponible en la lista de vehiculos
        /// </summary>
        /// <param name="espacioDisponible"></param>
        public Taller(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion


        #region "Sobrecargas"
        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns>Retorna un string que muestra el estacionamiento y todos los vehiculos</returns>
        public override string ToString()
        {
            return Taller.Listar(this, ETipo.Todos);
        }
        #endregion


        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="taller">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns>Retorna un string con los datos del elemento del tipo requerido</returns>
        public static string Listar(Taller t, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", t.vehiculos.Count, t.espacioDisponible);
            sb.AppendLine("");
            foreach (Vehiculo v in t.vehiculos)
            {
                switch (tipo)
                {
                    case Taller.ETipo.SUV:
                        if (v is Suv) 
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;

                    case Taller.ETipo.Ciclomotor:
                        if (v is Ciclomotor)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;

                    case Taller.ETipo.Sedan:
                        if (v is Sedan) 
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;

                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion


        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="taller">Objeto donde se agregará el elemento</param>
        /// <param name="vehiculo">Objeto a agregar</param>
        /// <returns>Retorna un objeto del tipo Taller con el elmento agregado o no en la lista</returns>
        public static Taller operator +(Taller t, Vehiculo vehiculo)
        {
            bool valor = false;

            if (t.espacioDisponible > t.vehiculos.Count) 
            {
                foreach (Vehiculo v in t.vehiculos)
                {
                    if (v == vehiculo)
                    {
                        valor = true;
                        break;
                    }
                }

                if (valor == false)
                {
                    t.vehiculos.Add(vehiculo);
                }
            }
            
            return t;
        }

        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="taller">Objeto donde se quitará el elemento</param>
        /// <param name="vehiculo">Objeto a quitar</param>
        /// <returns>Retorna un objeto del tipo Taller con el elmento eliminado o no de la lista<</returns>
        public static Taller operator -(Taller t, Vehiculo vehiculo)
        {
            for (int i = 0; i< t.vehiculos.Count; i++) 
            { 
                if (t.vehiculos[i] == vehiculo)
                {
                    t.vehiculos.RemoveAt(i);
                    break;
                }
            }

            return t;
        }
        #endregion


        /// <summary>
        /// Enumerado que contiene los tipos de vehiculos
        /// </summary>
        public enum ETipo
        {
            Ciclomotor,
            Sedan,
            SUV,
            Todos
        }

    }
}
