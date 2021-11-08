using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System.Collections.Generic;

namespace PruebaUnitaria_Entidades
{
    [TestClass]
    public class TestClaseGenericaDeposito
    {
        /// <summary>
        /// Si el producto pasado como parametro es null, lanza una excepcion de tipo ArgumentNullException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestObtenerIndexNull()
        {
            Deposito<Producto> d = new Deposito<Producto>();

            d.ObtenerIndex(null);
        }

        /// <summary>
        /// Si el producto no se encuentra en el deposito retorna -1
        /// </summary>
        [TestMethod]
        public void TestObtenerIndexNoExistente()
        {
            Deposito<Producto> d = new Deposito<Producto>();
            MercadoLibre ml = new MercadoLibre("4053", "Dualsense Blanco PS5", 12500, 1, "Usado","Activo", "Clasica");

            Assert.AreEqual(-1, d.ObtenerIndex(ml));
        }

        /// <summary>
        /// Si el producto existe en el deposito, retorna el indice
        /// </summary>
        [TestMethod]
        public void TestGetProductoExistente()
        {
            Deposito<Producto> d = new Deposito<Producto>();
            MercadoLibre ml = new MercadoLibre("4053", "Dualsense Blanco PS5", 12500, 1, "Nuevo", "Activo", "Clasica");

            d.Agregar(ml);
            Assert.IsTrue(d.ObtenerIndex(ml) != -1);
        }



        /// <summary>
        /// Agrega un producto al deposito
        /// </summary>
        [TestMethod]
        public void TestAddDepositoTrue()
        {
            Deposito<Producto> d = new Deposito<Producto>();
            MercadoLibre ml = new MercadoLibre("4053", "Dualsense Blanco PS5", 12500, 1, "Nuevo" ,"Activo", "Clasica");

            d.Agregar(ml);
            Assert.AreEqual(1, d.CantidadProductos);
        }

        /// <summary>
        /// La clase deposito arroja una exception de tipo ArgumentNullException cuando se intenta aniadir un valor null
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddDepositoNull()
        {
            Deposito<Producto> d = new Deposito<Producto>();
            MercadoLibre ml = new MercadoLibre("4053", "Dualsense Blanco PS5", 12500, 5, "Usado","Activo", "Clasica");

            d.Agregar(null);
        }

        /// <summary>
        /// Arroja una excepcion de tipo DepositoExistException, cuando el propducto ya existe en el deposito
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DepositoExistException))]
        public void TestAddDepositoProductoRepetido()
        {
            Deposito<Producto> d = new Deposito<Producto>();
            MercadoLibre ml1 = new MercadoLibre("4053", "Dualsense Blanco PS5", 12500, 1, "Usado","Activo", "Clasica");
            MercadoLibre ml2 = new MercadoLibre("4053", "Dualsense Blanco PS5", 12500, 1, "Usado", "Activo", "Clasica");

            d.Agregar(ml1);
            d.Agregar(ml2);
        }



        /// <summary>
        /// Retorna true cuando el producto fue eliminado correctamente del deposito
        /// </summary>
        [TestMethod]
        public void TestRemoveDepositoTrue()
        {
            Deposito<Producto> d = new Deposito<Producto>();
            MercadoLibre ml = new MercadoLibre("4053", "Dualsense Blanco PS5", 12500, 1, "Usado","Activo", "Premium");

            d.Agregar(ml);
            Assert.IsTrue(d.Eliminar(ml));
        }

        /// <summary>
        /// Arroja una excepcion del tipo ArgumentNullException cuando se pasa un parametro null
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestRemoveDepositoNull()
        {
            Deposito<Producto> d = new Deposito<Producto>();
            MercadoLibre ml = new MercadoLibre("4053", "Dualsense Blanco PS5", 12500, 1, "Usado", "Activo", "Premium");

            d.Agregar(ml);
            d.Eliminar(null);
        }

        /// <summary>
        /// Arroja una excepcion del tipo DepositoNotExistException cuando el producto no esta en el deposito
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DepositoNotExistException))]
        public void TestRemoveDepositoNoExistente()
        {
            Deposito<Producto> d = new Deposito<Producto>();

            MercadoLibre ml = new MercadoLibre("4053", "Dualsense Blanco PS5", 12500, 1, "Usado","Activo", "Premium");
            MercadoLibre ml2 = new MercadoLibre("1254", "Dualsense Rojo PS5", 12500, 1, "Nuevo","Activo", "Premium");

            d.Agregar(ml);
            d.Eliminar(ml2);
        }


        /// <summary>
        /// Si el producto esta en el deposito entonces retornara true
        /// </summary>
        [TestMethod]
        public void TestContieneTrue()
        {
            Deposito<Producto> d = new Deposito<Producto>();

            MercadoLibre ml = new MercadoLibre("4053", "Dualsense Blanco PS5", 12500, 1, "Nuevo", "Activo", "Premium");
            MercadoLibre ml2 = new MercadoLibre("4053", "Dualsense Blanco PS5", 12500, 1, "Nuevo", "Activo", "Premium");

            d.Agregar(ml);
            Assert.IsTrue(d.Contiene(ml2));
        }

        /// <summary>
        /// Si un producto pasado como parametro es null, arroja una excepcion de tipo ArgumentNullException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestContieneNull()
        {
            Deposito<Producto> d = new Deposito<Producto>();
            MercadoLibre ml = new MercadoLibre("4053", "Dualsense Blanco PS5", 12500, 1, "Nuevo","Activo", "Premium");

            d.Agregar(ml);
            d.Contiene(null);
        }

        /// <summary>
        /// Retorna la cantidad de productos que estan en el deposito
        /// </summary>
        [TestMethod]
        public void TestPropiedadCantidadProductos()
        {
            Deposito<Producto> d = new Deposito<Producto>();

            MercadoLibre ml1 = new MercadoLibre("4584", "Dualsense Blanco PS5", 12500, 1, "Usado","Activo", "Premium");
            MercadoLibre ml2 = new MercadoLibre("4053", "Dualsense Negro PS5", 12500, 1, "Reacondicionado", "Activo", "Premium");

            d.Agregar(ml1);
            d.Agregar(ml2);

            Assert.AreEqual(2, d.CantidadProductos);
        }

        /// <summary>
        /// Limpia el deposito quedando como nuevo, 0 productos
        /// </summary>
        [TestMethod]
        public void TestLimpiar()
        {
            Deposito<Producto> d = new Deposito<Producto>();
            MercadoLibre ml1 = new MercadoLibre("4584", "Dualsense Blanco PS5", 12500, 1, "Usado","Activo", "Premium");
            MercadoLibre ml2 = new MercadoLibre("4053", "Dualsense Negro PS5", 12500, 1, "Nuevo","Activo", "Premium");

            d.Agregar(ml1);
            d.Agregar(ml2);
            d.Limpiar();

            Assert.AreEqual(0, d.CantidadProductos);
        }

        /// <summary>
        /// Remplaza un producto por uno que tenga el mismo ID
        /// </summary>
        [TestMethod]
        public void TestRemplazarTrue()
        {
            Deposito<Producto> d = new Deposito<Producto>();
            MercadoLibre ml1 = new MercadoLibre("4584", "Dualsense Blanco PS5", 12500, 1, "Usado", "Activo", "Premium");
            MercadoLibre ml2 = new MercadoLibre("4584", "Dualsense Negro PS5", 12500, 1, "Nuevo", "Activo", "Premium");

            d.Agregar(ml1);

            Assert.IsTrue(d.Remplazar(ml2));
        }


        /// <summary>
        /// Si un producto no existe en el deposito lanza la excepcion DepositoNotExistException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DepositoNotExistException))]
        public void TestRemplazarNull()
        {
            Deposito<Producto> d = new Deposito<Producto>();
            MercadoLibre ml1 = new MercadoLibre("4584", "Dualsense Blanco PS5", 12500, 1, "Usado", "Activo", "Premium");
            MercadoLibre ml2 = new MercadoLibre("4584", "Dualsense Negro PS5", 12500, 1, "Nuevo", "Activo", "Premium");

            Assert.IsTrue(d.Remplazar(ml2));
        }
    }
}
