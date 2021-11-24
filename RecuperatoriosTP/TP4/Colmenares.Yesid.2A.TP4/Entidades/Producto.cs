using System;
using System.Text;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Amazon))]
    [XmlInclude(typeof(MercadoLibre))]
    public abstract class Producto : IEquatable<Producto>
    {
        //ENUMERADOS
        /// <summary>
        /// Enumerado que contiene las condiciones del producto
        /// </summary>
        public enum ECondicion
        {
            Nuevo,
            Usado,
            Reacondicionado,
            Ninguno
        }
        /// <summary>
        /// Enumerado que contiene el estado del producto
        /// </summary>
        public enum EEstado
        {
            Activa,
            Inactiva,
            Ninguno
        }
        /// <summary>
        /// Enumerado que contiene el tipo de publicacion del producto
        /// </summary>
        public enum ETipoPublicacion
        {
            Gratuita,
            Clasica,
            Premium
        }


        //ATRIBUTOS
        /// <summary>
        /// ID del producto
        /// </summary>
        protected string id;
        /// <summary>
        /// Nombre del producto
        /// </summary>
        protected string nombre;
        /// <summary>
        /// Precio del producto
        /// </summary>
        protected float precio;
        /// <summary>
        /// Cantidad del Producto
        /// </summary>
        protected int cantidad;
        /// <summary>
        /// La condicion del producto, Nuevo, Usado, Reacondicionado o Ninguno 
        /// </summary>
        protected ECondicion condicion;
        /// <summary>
        /// Estado del producto, Activa, Inactiva o Ninguno
        /// </summary>
        protected EEstado estado;
        /// <summary>
        /// Tipo de publicacion del producto, Gratuita, Clasica o Premium
        /// </summary>
        protected ETipoPublicacion tipoPublicacion;


        //CONSTRUCTORES
        /// <summary>
        /// Constructor por defecto que necesito para serializar
        /// </summary>
        public Producto()
        {

        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">ID del producto</param>
        /// <param name="nombre">Nombre del producto</param>
        /// <param name="precio">Precio del producto</param>
        /// <param name="cantidad">Cantidad del producto</param>
        public Producto(string id, string nombre, float precio, int cantidad, string condicion, string estado, string tipoPublicacion)
        {
            this.id = id;
            this.nombre = nombre;
            this.precio = precio;
            this.cantidad = cantidad;
            this.Condicion = condicion;
            this.Estado = estado;
            this.TipoPublicacion = tipoPublicacion;
        }


        //IMPLEMENTACION DE METODOS VIRTUALES
        /// <summary>
        /// Genera un string con la informacion del producto
        /// </summary>
        /// <returns>Retorna un string con los datos</returns>
        protected virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"ID: {this.Id} | ");
            sb.Append($"Nombre: {this.Nombre} | ");
            sb.Append($"Precio: {this.Precio} | ");
            sb.Append($"Cantidad: {this.Cantidad} | ");
            sb.Append($"Estado: {this.Estado} | ");
            sb.Append($"Condicion: {this.Condicion} | ");
            sb.Append($"Tipo publicacion: {this.TipoPublicacion} |\n");

            return sb.ToString();
        }


        //IMPLEMENTACION INTERFAZ
        /// <summary>
        /// Compara que no sea null y que cumpla con la sobrecarga == de producto
        /// </summary>
        /// <param name="other">Instancia de producto</param>
        /// <returns>Retorna true si cumple con la condicion, de lo contrario false</returns>
        public bool Equals(Producto other)
        {
            bool valor = false;

            if (other is not null)
            {
                valor = other == this;
            }
            return valor;
        }


        //IMPLEMENTACION E INVALIDACION DE METODOS Object.Equals(Object obj) y Object.GetHasCode()
        /// <summary>
        /// Compara si la instancia pasada como parametro es del tipo de la instancia actual y compara si cumple con la sobrecarga == de producto
        /// </summary>
        /// <param name="obj">Instancia de producto</param>
        /// <returns>Retorna true si cumple con la condicion,de lo contrario false</returns>
        public override bool Equals(object obj)
        {
            bool valor = false;

            if (obj is not null && obj is Producto)
            {
                valor = this.Equals((Producto)obj);
            }
            return valor;
        }

        /// <summary>
        /// Obtiene el Has Code de la instancia actual
        /// </summary>
        /// <returns>Retorna int con el Has Code</returns>
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }


        //SOBRECARGA DE OPERADORES
        /// <summary>
        /// Dos productos son iguales solo si sus IDs son los mismos
        /// </summary>
        /// <param name="p1">Producto 1</param>
        /// <param name="p2">Producto 2</param>
        /// <returns>True si son iguales, false si no lo son</returns>
        public static bool operator ==(Producto p1, Producto p2)
        {
            bool valor = false;

            if (p1 is not null && p2 is not null)
            {
                if (p1.Id == p2.Id)
                {
                    valor = true;
                }
            }
            return valor;
        }

        /// <summary>
        /// Dos productos son distintos solo si sus IDs son diferentes
        /// </summary>
        /// <param name="p1">Producto 1</param>
        /// <param name="p2">Producto 2</param>
        /// <returns>True si son distintos, false si no lo son</returns>
        public static bool operator !=(Producto p1, Producto p2)
        {
            return !(p1 == p2);
        }


        //LAS PROPIEDADES TENIA QUE HACERLAS DE LECTURA Y ESCRITURA PARA PODER SERIALIZAR
        /// <summary>
        /// Rretorna y guarda el ID del producto
        /// </summary>
        public string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
        /// <summary>
        /// Retorna y guarda el nombre del producto
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }
        /// <summary>
        /// Retorna y guarda el precio del producto
        /// </summary>
        public float Precio
        {
            get
            {
                return this.precio;
            }
            set
            {
                this.precio = value;
            }
        }
        /// <summary>
        /// Retorna y Guarda la cantidad del producto
        /// </summary>
        public int Cantidad
        {
            get
            {
                return this.cantidad;
            }
            set
            {
                this.cantidad = value;
            }
        }
        /// <summary>
        /// Retorna y Guarda el estado del producto segun el enumerado correspondiente
        /// </summary>
        public string Estado
        {
            set
            {
                this.estado = EEstado.Ninguno;

                if (Enum.TryParse(value, out EEstado tipo))
                {
                    this.estado = tipo;
                }
            }
            get
            {
                return this.estado.ToString();
            }
        }
        /// <summary>
        /// Retorna y Guarda la condicion del producto segun el enumerado correspondiente
        /// </summary>
        public string Condicion
        {
            get
            {
                return this.condicion.ToString();
            }
            set
            {
                this.condicion = ECondicion.Ninguno;

                if (Enum.TryParse(value, out ECondicion tipo))
                {
                    this.condicion = tipo;
                }
            }
        }
        /// <summary>
        /// Retorna y Guarda el tipo de publicacion del producto segun el enumerado correspondiente
        /// </summary>
        public string TipoPublicacion
        {
            get
            {
                return this.tipoPublicacion.ToString();
            }
            set
            {
                this.tipoPublicacion = ETipoPublicacion.Clasica;

                if (Enum.TryParse(value, out ETipoPublicacion tipo))
                {
                    this.tipoPublicacion = tipo;
                }  
            }
        }
    }

}
