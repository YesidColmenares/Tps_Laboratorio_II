using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace PruebaUnitaria_Entidades
{
    [TestClass]
    public class TestClaseProducto
    {
        /// <summary>
        /// La sobrecarga del operador == compara por ID
        /// </summary>
        [TestMethod]
        public void TestSobrecargaIgualTrue()
        {
            MercadoLibre m1 = new MercadoLibre("123", "Spyro PS4", 4500, 4, "Nuevo", "Activo", "Clasica");
            MercadoLibre m2 = new MercadoLibre("123", "Spyro PS4", 4500, 4, "Nuevo", "Activo", "Clasica");

            Assert.IsTrue(m1 == m2);
        }
        [TestMethod]
        public void TestSobrecargaIgualFalse()
        {
            MercadoLibre m1 = new MercadoLibre("123", "Spyro PS4", 4500, 4, "Nuevo", "Activo", "Clasica");
            MercadoLibre m2 = new MercadoLibre("4", "Spyro PS4", 4500, 4, "Nuevo", "Activo", "Clasica");

            Assert.IsFalse(m1 == m2);
        }
        [TestMethod]
        public void TestSobrecargaIgualNull()
        {
            MercadoLibre m1 = new MercadoLibre("4", "Spyro PS4", 4500, 4, "Nuevo", "Activo", "Clasica");
            MercadoLibre m2 = null;

            Assert.IsFalse(m1 == m2);
        }


        /// <summary>
        /// Equals compara dos objetos por el ID, si comparten el mismo ID es True
        /// </summary>
        [TestMethod]
        public void TestEqualsTrue()
        {
            MercadoLibre m1 = new MercadoLibre("123", "Spyro PS4", 4500, 4, "Nuevo", "Activo", "Premium");
            MercadoLibre m2 = new MercadoLibre("123", "Spyro PS4", 4500, 4, "Nuevo", "Activo", "Premium");

            Assert.IsTrue(m1.Equals(m2));
        }
        [TestMethod]
        public void TestEqualsFalse()
        {
            MercadoLibre m1 = new MercadoLibre("123", "Spyro PS4", 4500, 4, "Nuevo", "Activo", "Premium");
            MercadoLibre m2 = new MercadoLibre("456", "Spyro PS4", 4500, 4, "Nuevo", "Activo", "Premium");

            Assert.IsFalse(m1.Equals(m2));
        }
        [TestMethod]
        public void TestEqualsNull()
        {
            MercadoLibre m1 = new MercadoLibre("123", "Spyro PS4", 4500, 4, "Nuevo", "Activo", "Premium");
            MercadoLibre m2 = null;

            Assert.IsFalse(m1.Equals(m2));
        }


        /// <summary>
        /// GetHasCode Obtiene el Has Code del atributo ID de Producto
        /// </summary>
        [TestMethod]
        public void TestGetHasCode()
        {
            MercadoLibre m2 = new MercadoLibre("50", "Batman Arkhan Knight PS4", 6500, 4, "Nuevo", "Activo", "Gratuita");

            int has = m2.GetHashCode();

            Assert.IsTrue(has == "50".GetHashCode());
        }

        /// <summary>
        /// La propiedad EstadoText convierte el texto ingresado al enumerado correspondiente
        /// </summary>
        [TestMethod]
        public void TestPropiedadEstadoTrue()
        {
            MercadoLibre m1 = new MercadoLibre("123", "Spyro PS4", 4500, 4, "Usado", "Activa", "Gratuita");

            Assert.IsTrue(m1.Estado == Producto.EEstado.Activa.ToString());
        }

        /// <summary>
        /// En caso de que no se identifique el esatdo ingresada se establece como EEstado.Ninguno
        /// </summary>
        [TestMethod]
        public void TestPropiedadEstadoFalse()
        {
            MercadoLibre m1 = new MercadoLibre("123", "Spyro PS4", 4500, 4, "Usado", "Atibo", "Gratuita");

            Assert.IsTrue(m1.Estado == Producto.EEstado.Ninguno.ToString());
        }



        /// <summary>
        /// La propiedad CondicionTexto convierte el texto ingresado al enumerado correspondiente
        /// </summary>
        [TestMethod]
        public void TestPropiedadCondicionTrue()
        {
            MercadoLibre m1 = new MercadoLibre("123", "Spyro PS4", 4500, 4, "Usado", "Activa", "Gratuita");

            Assert.IsTrue(m1.Condicion == Producto.ECondicion.Usado.ToString());
        }

        /// <summary>
        /// En caso de que no se identifique la condicion ingresada se establece como ECondicion.Ninguno
        /// </summary>
        [TestMethod]
        public void TestPropiedadCondicionFalse()
        {
            MercadoLibre m1 = new MercadoLibre("123", "Spyro PS4", 4500, 4, "Uzado", "Atibo", "Gratuita");

            Assert.IsTrue(m1.Condicion == Producto.ECondicion.Ninguno.ToString());
        }



        /// <summary>
        /// La propiedad TipoPublicacionTexto convierte el texto ingresado al enumerado correspondiente
        /// </summary>
        [TestMethod]
        public void TestPropiedadTipoPublicacionTrue()
        {
            MercadoLibre m1 = new MercadoLibre("123", "Spyro PS4", 4500, 4, "Usado", "Activa", "Gratuita");

            Assert.IsTrue(m1.TipoPublicacion == Producto.ETipoPublicacion.Gratuita.ToString());
        }

        /// <summary>
        /// En caso de que no se identifique la condicion ingresada se establece como ETipoPublicacion.Clasica
        /// </summary>
        [TestMethod]
        public void TestPropiedadTipoPubliacacionFalse()
        {
            MercadoLibre m1 = new MercadoLibre("123", "Spyro PS4", 4500, 4, "Uzado", "Atibo", "Gratuitaaa");

            Assert.IsTrue(m1.TipoPublicacion == Producto.ETipoPublicacion.Clasica.ToString());
        }
    }
}
