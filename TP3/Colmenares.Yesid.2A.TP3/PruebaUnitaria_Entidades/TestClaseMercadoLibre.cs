using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace PruebaUnitaria_Entidades
{
    [TestClass]
    public class TestClaseMercadoLibre
    {
        /// <summary>
        /// La propiedad EstadoText convierte el texto ingresado al enumerado correspondiente
        /// </summary>
        [TestMethod]
        public void TestPropiedadEstadoTrue()
        {
            MercadoLibre m1 = new MercadoLibre("123", "Spyro PS4", 4500, 4, "Usado", "Activa", "Gratuita");

            Assert.IsTrue(m1.EstadoEnum == MercadoLibre.EEstado.Activa);
        }

        /// <summary>
        /// En caso de que no se identifique el esatdo ingresada se establece como EEstado.Ninguno
        /// </summary>
        [TestMethod]
        public void TestPropiedadEstadoFalse()
        {
            MercadoLibre m1 = new MercadoLibre("123", "Spyro PS4", 4500, 4, "Usado", "Atibo", "Gratuita");

            Assert.IsTrue(m1.EstadoEnum == MercadoLibre.EEstado.Ninguno);
        }



        /// <summary>
        /// La propiedad CondicionTexto convierte el texto ingresado al enumerado correspondiente
        /// </summary>
        [TestMethod]
        public void TestPropiedadCondicionTrue()
        {
            MercadoLibre m1 = new MercadoLibre("123", "Spyro PS4", 4500, 4, "Usado", "Activa", "Gratuita");

            Assert.IsTrue(m1.CondicionEnum == MercadoLibre.ECondicion.Usado);
        }

        /// <summary>
        /// En caso de que no se identifique la condicion ingresada se establece como ECondicion.Ninguno
        /// </summary>
        [TestMethod]
        public void TestPropiedadCondicionFalse()
        {
            MercadoLibre m1 = new MercadoLibre("123", "Spyro PS4", 4500, 4, "Uzado", "Atibo", "Gratuita");

            Assert.IsTrue(m1.CondicionEnum == MercadoLibre.ECondicion.Ninguno);
        }



        /// <summary>
        /// La propiedad TipoPublicacionTexto convierte el texto ingresado al enumerado correspondiente
        /// </summary>
        [TestMethod]
        public void TestPropiedadTipoPublicacionTrue()
        {
            MercadoLibre m1 = new MercadoLibre("123", "Spyro PS4", 4500, 4, "Usado", "Activa", "Gratuita");

            Assert.IsTrue(m1.TipoPublicacionEnum == MercadoLibre.ETipoPublicacion.Gratuita);
        }

        /// <summary>
        /// En caso de que no se identifique la condicion ingresada se establece como ETipoPublicacion.Clasica
        /// </summary>
        [TestMethod]
        public void TestPropiedadTipoPubliacacionFalse()
        {
            MercadoLibre m1 = new MercadoLibre("123", "Spyro PS4", 4500, 4, "Uzado", "Atibo", "Gratuitaaa");

            Assert.IsTrue(m1.TipoPublicacionEnum == MercadoLibre.ETipoPublicacion.Clasica);
        }
    }
}
