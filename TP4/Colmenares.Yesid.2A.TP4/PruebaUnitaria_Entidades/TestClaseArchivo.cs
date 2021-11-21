using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace PruebaUnitaria_Entidades
{
    [TestClass]
    public class TestClaseArchivo
    {
        /// <summary>
        /// Cargo una lista de productos desde un archivo Serializado xml
        /// </summary>
        [TestMethod]
        public void TestAgregarListaSerializadaTrue()
        {
            string pathSerializacion = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Tps_Laboratorio_II\\TP3\\Colmenares.Yesid.2A.TP3\\Archivos\\Serializacion.xml";
            Deposito<Producto> d = new Deposito<Producto>();

            List<Producto> listaProductos = Archivo.CargarXml(pathSerializacion, typeof(List<Producto>));

            d.AgregarLista(listaProductos);

            Assert.IsTrue(d.CantidadProductos > 0);
        }

        /// <summary>
        /// Guardo una lista de productos en un archivo serializado xml
        /// </summary>
        [TestMethod]
        public void TestGuardarListaSerializadaTrue()
        {
            Deposito<Producto> d = new Deposito<Producto>();

            string pathSerializacion = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Tps_Laboratorio_II\\TP3\\Colmenares.Yesid.2A.TP3\\Archivos\\Serializacion.xml";
            string pathXMLGuardar = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Tps_Laboratorio_II\\TP3\\Colmenares.Yesid.2A.TP3\\Archivos\\SerializacionCopia2.xml";

            List<Producto> listaProductos = Archivo.CargarXml(pathSerializacion, typeof(List<Producto>));
            d.AgregarLista(listaProductos);

            Assert.IsTrue(Archivo.GuardarXml(pathXMLGuardar, d.Productos, typeof(List<Producto>)));
        }

    }
}
