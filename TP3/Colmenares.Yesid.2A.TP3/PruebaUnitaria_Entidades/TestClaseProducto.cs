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
        /// Compare To realiza comparaciones en base al atributo ID de Producto
        /// </summary>
        [TestMethod]
        public void TestCompareToLessThanZero()
        {
            MercadoLibre m1 = new MercadoLibre("50", "World War Z PS4", 4500, 4, "Nuevo", "Activo", "Premium");
            MercadoLibre m2 = new MercadoLibre("50", "Spyro PS4", 6500, 4, "Nuevo", "Activo", "Premium");

            Assert.AreEqual(1, m1.CompareTo(m2));
        }
        [TestMethod]
        public void TestCompareToZero()
        {
            MercadoLibre m1 = new MercadoLibre("487", "Spyro PS4", 4500, 4, "Nuevo", "Activo", "Gratuita");
            MercadoLibre m2 = new MercadoLibre("123", "Spyro PS4", 4500, 4, "Nuevo", "Activo", "Gratuita");

            Assert.AreEqual(0, m1.CompareTo(m2));
        }
        [TestMethod]
        public void TestCompareToGreatherThanZero()
        {
            MercadoLibre m1 = new MercadoLibre("50", "Cod Modern Warfare PS4", 4500, 4, "Nuevo", "Activo", "Gratuita");
            MercadoLibre m2 = new MercadoLibre("50", "Hitman 3 PS4", 6500, 4, "Nuevo", "Activo", "Gratuita");

            Assert.AreEqual(-1, m1.CompareTo(m2));
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
    }
}
