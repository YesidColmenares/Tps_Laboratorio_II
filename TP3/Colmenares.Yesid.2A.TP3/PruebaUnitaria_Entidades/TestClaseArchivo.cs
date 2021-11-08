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
        /// Cargo una lista de productos de Mercado Libre  desde un archivo txt
        /// </summary>
        [TestMethod]
        public void TestAgregarListaMercadoLibreTrue()
        {
            string pathML = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Tps_Laboratorio_II\\TP3\\Colmenares.Yesid.2A.TP3\\Archivos\\MercadoLibre.txt";
            Deposito<Producto> d = new Deposito<Producto>();

            List<Producto> listaProductos = Archivo.CargarTxt(pathML, EPlataforma.MercadoLibre);

            d.AgregarLista(listaProductos);

            Assert.IsTrue(d.CantidadProductos > 0);
        }

        /// <summary>
        /// Cargo una lista de productos de Amazon desde un archivo txt
        /// </summary>
        [TestMethod]
        public void TestAgregarListaAmazonTrue()
        {
            string pathAmazon = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Tps_Laboratorio_II\\TP3\\Colmenares.Yesid.2A.TP3\\Archivos\\Amazon.txt";
            Deposito<Producto> d = new Deposito<Producto>();

            List<Producto> listaProductos = Archivo.CargarTxt(pathAmazon, EPlataforma.Amazon);

            d.AgregarLista(listaProductos);

            Assert.IsTrue(d.CantidadProductos > 0);
        }

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
        /// Guardo una lista de productos de Mercado Libre en un archivo txt
        /// </summary>
        [TestMethod]
        public void TestGuardarListaMercadoLibreTrue()
        {
            string pathML = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Tps_Laboratorio_II\\TP3\\Colmenares.Yesid.2A.TP3\\Archivos\\MercadoLibre.txt";
            string pathMLGuardar = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Tps_Laboratorio_II\\TP3\\Colmenares.Yesid.2A.TP3\\Archivos\\MercadoLibreCopia2.txt";

            List<Producto> listaProductos = Archivo.CargarTxt(pathML, EPlataforma.MercadoLibre);

            Assert.IsTrue(Archivo.GuardarTxt(pathMLGuardar, listaProductos, EPlataforma.MercadoLibre));
        }

        /// <summary>
        /// Guardo una lista de productos de Amazon en un archivo txt
        /// </summary>
        [TestMethod]
        public void TestGuardarListaAmazonTrue()
        {
            string pathAmazon = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Tps_Laboratorio_II\\TP3\\Colmenares.Yesid.2A.TP3\\Archivos\\Amazon.txt";
            string pathAmazonGuardar = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Tps_Laboratorio_II\\TP3\\Colmenares.Yesid.2A.TP3\\Archivos\\AmazonCopia2.txt";

            List<Producto> listaProductos = Archivo.CargarTxt(pathAmazon, EPlataforma.Amazon);

            Assert.IsTrue(Archivo.GuardarTxt(pathAmazonGuardar, listaProductos, EPlataforma.Amazon));
        }

        /// <summary>
        /// Guardo una lista de productos en un archivo serializado xml
        /// </summary>
        [TestMethod]
        public void TestGuardarListaSerializadaTrue()
        {
            Deposito<Producto> d = new Deposito<Producto>();

            string pathML = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Tps_Laboratorio_II\\TP3\\Colmenares.Yesid.2A.TP3\\Archivos\\MercadoLibre.txt";
            string pathAZ = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Tps_Laboratorio_II\\TP3\\Colmenares.Yesid.2A.TP3\\Archivos\\Amazon.txt";
            string pathXMLGuardar = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Tps_Laboratorio_II\\TP3\\Colmenares.Yesid.2A.TP3\\Archivos\\SerializacionCopia2.xml";

            List<Producto> listaProductos = Archivo.CargarTxt(pathAZ, EPlataforma.Amazon);
            List<Producto> listaProductos2 = Archivo.CargarTxt(pathML, EPlataforma.MercadoLibre);

            d.AgregarLista(listaProductos);
            d.AgregarLista(listaProductos2);

            Assert.IsTrue(Archivo.GuardarXml(pathXMLGuardar, d.Productos, typeof(List<Producto>)));
        }

    }
}
