using System;
using System.Collections.Generic;

namespace Entidades
{
    public class Deposito<T> : IGestionDeposito<T>, IControlDeposito<T>, IInformesDeposito<T>, IListaDeposito<T>
        where T : Producto
    {        
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