using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    //DELEGADOS
    public delegate void CantidadCeroEvent();
    public delegate void ProductoEliminadoEvent(string id, string nombre);

    public class Deposito<T> : IGestionDeposito<T>, IControlDeposito<T>, IInformesDeposito<T>, IListaDeposito<T>, IAnalisisDeposito<T>
        where T : Producto
    {

        //EVENTOS
        /// <summary>
        /// Evento que se invoca cuando el producto ingresado al deposito tiene cantidad 0
        /// </summary>
        public event CantidadCeroEvent CantidadCeroEvent;
        /// <summary>
        /// Evento que se invoca cuando el producto es eliminado del deposito
        /// </summary>
        public event ProductoEliminadoEvent ProductoEliminadoEvent;


        //ATRIBUTOS
        /// <summary>
        /// Lista donde guardaremos los productos
        /// </summary>
        private List<T> productos;


        //CONSTRUCTOR
        /// <summary>
        /// Constructor por defecto que inicializa la lista de productos
        /// </summary>
        public Deposito()
        {
            this.productos = new List<T>();
        }


        //METODOS
        /// <summary>
        /// Lanza una excepcion del tipo ArgumentNullException, si el tipo T pasado como parametro es null
        /// </summary>
        /// <param name="t">Instancia a validar</param>
        /// <returns>True si no es null</returns>
        /// <exception cref="ArgumentNullException">Si la instancia es null</exception> 
        private bool IsNotNull(T t)
        {
            bool valor = true;

            if (t is null)
            {
                throw new ArgumentNullException("El producto pasado como parametro es null, no hay ninguna referencia");
            }
            return valor;
        }


        //IMPLEMENTACION INTERFAZ IgestionDeposito<T>
        /// <summary>
        /// Agrega un producto al deposito
        /// </summary>
        /// <param name="t">Producto</param>
        /// <exception cref="ArgumentNullException">Si el producto es null</exception>
        /// <exception cref="DepositoExistException">Si el producto ya existe en el deposito</exception>
        public void Agregar(T t)
        {
            if (this.Contiene(t))
            {
                throw new DepositoExistException();
            }
            else
            {
                if (t.Cantidad == 0)
                {
                    if (this.CantidadCeroEvent is not null)
                    {
                        this.CantidadCeroEvent.Invoke();
                    }
                }
                this.productos.Add(t);
            }
        }
        /// <summary>
        /// Determina si existe el producto en el deposito
        /// </summary>
        /// <param name="t">Producto</param>
        /// <returns>Retorna true si existe en el deposito, de lo contrario false</returns>
        /// <exception cref="ArgumentNullException">Si el producto es null</exception>
        public bool Contiene(T t)
        {
            bool valor = false;

            if (this.IsNotNull(t))
            {
                if (this.productos.Contains(t))
                {
                    valor = true;
                }
            }
            return valor;
        }
        /// <summary>
        /// Elimina un producto del deposito
        /// </summary>
        /// <param name="t">Producto</param>
        /// <returns>Retorna true si se elimino el producto</returns>
        /// <exception cref="ArgumentNullException">Si el producto es null</exception>
        /// <exception cref="DepositoNotExistException">Si el producto no existe en el deposito</exception>
        public bool Eliminar(T t)
        {
            bool valor = false;

            if (!this.Contiene(t))
            {
                throw new DepositoNotExistException();
            }
            else
            {
                valor = this.productos.Remove(t);

                if (valor && this.ProductoEliminadoEvent is not null)
                {
                    this.ProductoEliminadoEvent.Invoke(t.Id, t.Nombre);
                }
            }
            
            return valor;
        }
        /// <summary>
        /// Limpia el deposito
        /// </summary>
        public void Limpiar()
        {
            this.productos.Clear();
        }
        /// <summary>
        /// Obtiene el indice del producto especificado
        /// </summary>
        /// <param name="t">Producto</param>
        /// <returns>Retorna el index si este producto existe, de lo contrario -1</returns>
        /// <exception cref="ArgumentNullException">Si el producto es null</exception>
        public int ObtenerIndex(T t)
        {
            int auxIndex = -1;

            if (this.IsNotNull(t))
            {
                auxIndex = this.productos.IndexOf(t);
            }

            return auxIndex;
        }
        /// <summary>
        /// Remplaza un producto del deposito
        /// </summary>
        /// <param name="t">Producto</param>
        /// <returns>Retorna true si se remplazo correctamente</returns>
        /// <exception cref="ArgumentNullException">Si el producto es null</exception>
        /// <exception cref="DepositoNotExistException">Si el producto no existe en el deposito</exception>
        public bool Remplazar(T t)
        {
            bool valor = false;

            if (this.Contiene(t))
            {
                if (this.Eliminar(t))
                {
                    this.Agregar(t);
                    valor = true;
                }
            }
            else
            {
                throw new DepositoNotExistException();
            }
            return valor;
        }


        //IMPLEMENTACION INTERFAZ IControlDeposito<T>
        /// <summary>
        /// Controla que esten activos los productos que tienen mas de 1 unidad
        /// </summary>
        /// <returns>Retorna una lista con el informe</returns>
        public List<T> ControlPausadas()
        {
            List<T> listaAux = new List<T>();

            foreach (T item in this.productos)
            {
                if (item.Estado == Producto.EEstado.Inactiva.ToString() && item.Cantidad > 0 
                    || item.Estado == Producto.EEstado.Activa.ToString() && item.Cantidad <= 0)
                {
                    listaAux.Add(item);
                }
            }
            return listaAux;
        }


        //IMPLEMENTACION INTERFAZ IListaDeposito<T>
        /// <summary>
        /// Agrega una lista de productos al deposito
        /// </summary>
        /// <param name="lista">Lista que contiene los productos a ingresar</param>
        /// <returns>Retorna true si se agrego correctamente</returns>
        /// <exception cref="ArgumentNullException">Si la lista es null</exception>
        /// <exception cref="DepositoListZeroAggregateException">Si no se agrego ningun elemento al deposito</exception>
        public bool AgregarLista(List<T> lista)
        {
            bool valor = false;

            if (lista is not null)
            {
                if (lista.Count > 0)
                {
                    foreach (T i in lista)
                    {
                        if (!this.Contiene(i))
                        {
                            this.productos.Add(i);
                            valor = true;
                        }
                    }
                }
                else
                {
                    throw new DepositoListZeroAggregateException(null, "Entidades.Deposito<T>.AgregarLista(List<T> lista), Linea 217");
                }
            }
            else
            {
                throw new ArgumentNullException("La lista pasada como parametro es null, no hay ninguna referencia");
            }
            return valor;
        }


        //IMPLEMENTACION INTERFAZ IInfoDeposito<T>
        /// <summary>
        /// Genera un informe con la lista de productos que se encuentran en el deposito
        /// </summary>
        /// <returns>Lista con el informe</returns>
        public List<T> InfoListaProductos()
        {
            List<T> list = new List<T>();

            foreach (T item in this.productos)
            {
                list.Add(item);
            }

            return list;
        }

        /// <summary>
        /// Genera un informe con la lista de productos que se encuentran sin stock
        /// </summary>
        /// <returns>Lista con el informe</returns>
        public List<T> InfoSinStock()
        {
            List<T> list = new List<T>();

            foreach (T item in this.productos)
            {
                if (item.Cantidad == 0)
                {
                    list.Add(item);
                }
            }
            return list;
        }

        /// <summary>
        /// Genera un informe con la lista de productos que tienen stock
        /// </summary>
        /// <returns>Lista con el informe</returns>
        public List<T> InfoConStock()
        {
            List<T> list = new List<T>();

            foreach (T item in this.productos)
            {
                if (item.Cantidad > 0)
                {
                    list.Add(item);
                }
            }
            return list;
        }

        /// <summary>
        /// Genera un informe con la lista de productos que esten activos
        /// </summary>
        /// <returns>Lista con el informe</returns>
        public List<T> InfoEstadoActivo()
        {
            List<T> list = new List<T>();

            foreach (T item in this.productos)
            {
                if (item.Estado == Producto.EEstado.Activa.ToString())
                {
                    list.Add(item);
                }
            }
            return list;
        }

        /// <summary>
        /// Genera un informe con la lista de productos que esten incativos
        /// </summary>
        /// <returns>Lista con el informe</returns>
        public List<T> InfoEstadoInactivo()
        {
            List<T> list = new List<T>();

            foreach (T item in this.productos)
            {
                if (item.Estado == Producto.EEstado.Inactiva.ToString())
                {
                    list.Add(item);
                }
            }
            return list;
        }

        /// <summary>
        /// Genera un informe con la lista de productos que no tengan ningun estado
        /// </summary>
        /// <returns>Lista con el informe</returns>
        public List<T> InfoEstadoNinguno()
        {
            List<T> list = new List<T>();

            foreach (T item in this.productos)
            {
                if (item.Estado == Producto.EEstado.Ninguno.ToString())
                {
                    list.Add(item);
                }
            }
            return list;
        }

        /// <summary>
        /// Genera un informe con la lista de productos que su condicion sea nuevo
        /// </summary>
        /// <returns>Lista con el informe</returns>
        public List<T> InfoCondicionNuevo()
        {
            List<T> list = new List<T>();

            foreach (T item in this.productos)
            {
                if (item.Condicion == Producto.ECondicion.Nuevo.ToString())
                {
                    list.Add(item);
                }
            }
            return list;
        }

        /// <summary>
        /// Genera un informe con la lista de productos que su condicion sea usado
        /// </summary>
        /// <returns>Lista con el informe</returns>
        public List<T> InfoCondicionUsado()
        {
            List<T> list = new List<T>();

            foreach (T item in this.productos)
            {
                if (item.Condicion == Producto.ECondicion.Usado.ToString())
                {
                    list.Add(item);
                }
            }
            return list;
        }

        /// <summary>
        /// Genera un informe con la lista de productos que su condicion es reacondicionado
        /// </summary>
        /// <returns>Lista con el informe</returns>
        public List<T> InfoCondicionReacondicionado()
        {
            List<T> list = new List<T>();

            foreach (T item in this.productos)
            {
                if (item.Condicion == Producto.ECondicion.Reacondicionado.ToString())
                {
                    list.Add(item);
                }
            }
            return list;
        }

        /// <summary>
        /// Genera un informe con la lista de productos que no tiene condicion
        /// </summary>
        /// <returns>Lista con el informe</returns>
        public List<T> InfoCondicionNinguno()
        {
            List<T> list = new List<T>();

            foreach (T item in this.productos)
            {
                if (item.Condicion == Producto.ECondicion.Ninguno.ToString())
                {
                    list.Add(item);
                }
            }
            return list;
        }


        //IMPLEMENTACION INTERFAZ IAnalisisDeposito<T>
        /// <summary>
        /// Analiza la cantidad de productos que sean costosos y que esten activos 
        /// </summary>
        /// <returns>Retorna un float con el porcentaje</returns>
        public string ProductosActivosCostosos()
        {
            StringBuilder sb = new StringBuilder();
            int cantidad = 0;
            float porcentaje = 0;

            foreach (T item in this.productos)
            {
                if (item.Estado == Producto.EEstado.Activa.ToString())
                {
                    if (item.Precio > 10000)
                    {
                        cantidad++;
                    }
                }
            }
            if (this.CantidadProductos > 0)
            {
                porcentaje = (cantidad * 100) / this.CantidadProductos;
            }
            sb.Append($"El porcentaje de productos activos que tengan un precio mayor a $10000 es: {porcentaje}%");
            
            return sb.ToString();
        }

        /// <summary>
        /// Analiza la cantidad de productos que sean economicos y que no esten activos
        /// </summary>
        /// <returns></returns>
        public string ProductosInactivosEconomicos()
        {
            StringBuilder sb = new StringBuilder();
            int cantidad = 0;
            float porcentaje = 0;

            foreach (T item in this.productos)
            {
                if (item.Estado == Producto.EEstado.Inactiva.ToString())
                {
                    if (item.Precio < 3000)
                    {
                        cantidad++;
                    }
                }
            }
            if (this.CantidadProductos > 0)
            {
                porcentaje = (cantidad * 100) / this.CantidadProductos;
            }
            sb.Append($"El porcentaje de productos inactivos que tengan un precio menor a $3000 es: {porcentaje}%");

            return sb.ToString();
        }

        /// <summary>
        /// Analiza la cantidad de productos de tipo premium
        /// </summary>
        /// <returns></returns>
        public string ProductosTipoPremium()
        {
            StringBuilder sb = new StringBuilder();
            int cantidad = 0;
            float porcentaje = 0;

            foreach (T item in this.productos)
            {
                if (item.TipoPublicacion == Producto.ETipoPublicacion.Premium.ToString())
                {
                    cantidad++;
                }
            }
            if (this.CantidadProductos > 0)
            {
                porcentaje = (cantidad * 100) / this.CantidadProductos;
            }
            sb.Append($"El porcentaje de productos con tipo de publicacion Premium es: {porcentaje}%");

            return sb.ToString();
        }

        /// <summary>
        /// Analiza el promedio del precio de los productos en el deposito
        /// </summary>
        /// <returns></returns>
        public string PromedioDePrecios()
        {
            StringBuilder sb = new StringBuilder();
            float precio = 0;
            float promedio = 0;

            foreach (T item in this.productos)
            {
                precio += item.Precio;
            }
            if (this.CantidadProductos > 0)
            {
                promedio = precio / this.CantidadProductos;
            }
            sb.Append($"El promedio del precio de los producto es: ${promedio}");

            return sb.ToString();
        }

        /// <summary>
        /// Analiza el promedio de productos nuevos con el tipo de publicacion clasico
        /// </summary>
        /// <returns></returns>
        public string ProductosNuevosConTipoClasico()
        {
            StringBuilder sb = new StringBuilder();
            int cantidad = 0;
            float porcentaje = 0;

            foreach (T item in this.productos)
            {
                if (item.Condicion == Producto.ECondicion.Nuevo.ToString())
                {
                    if (item.TipoPublicacion == Producto.ETipoPublicacion.Clasica.ToString())
                    {
                        cantidad++;
                    }
                }
            }
            if (this.CantidadProductos > 0)
            {
                porcentaje = (cantidad * 100) / this.CantidadProductos;
            }
            sb.Append($"El porcentaje de productos nuevos con tipo de publicacion Clasico es: {porcentaje}%");

            return sb.ToString();
        }

        /// <summary>
        /// Analiza el porcentaje de productos que no tienen stock 
        /// </summary>
        /// <returns></returns>
        public string ProductosSinStock()
        {
            StringBuilder sb = new StringBuilder();
            int cantidad = 0;
            float porcentaje = 0;

            foreach (T item in this.productos)
            {
                if (item.Cantidad == 0)
                {
                    cantidad++;
                }
            }
            if (this.CantidadProductos > 0)
            {
                porcentaje = (cantidad * 100) / this.CantidadProductos;
            }
            sb.Append($"El porcentaje de productos que no tienen stock es: {porcentaje}%");

            return sb.ToString();
        }


        //PROPIEDADES
        /// <summary>
        /// Retorna la cantidad de productos que tengo en el deposito
        /// </summary>
        public int CantidadProductos
        {
            get
            {
                return this.productos.Count;
            }
        }

        /// <summary>
        /// Rretorna la lista de productos
        /// </summary>
        public List<T> Productos
        {
            get
            {
                return this.productos;
            }
        }
    }
}