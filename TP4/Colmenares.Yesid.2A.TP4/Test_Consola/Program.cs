using Entidades;
using System;
using System.Collections.Generic;
using System.IO;

namespace Test_Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathML = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Tps_Laboratorio_II\\TP3\\Colmenares.Yesid.2A.TP3\\Archivos\\MercadoLibre.txt";
            string pathAZ = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Tps_Laboratorio_II\\TP3\\Colmenares.Yesid.2A.TP3\\Archivos\\Amazon.txt";
            string pathXML = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Tps_Laboratorio_II\\TP3\\Colmenares.Yesid.2A.TP3\\Archivos\\Serializacion.xml";
            string pathMLGuardar = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Tps_Laboratorio_II\\TP3\\Colmenares.Yesid.2A.TP3\\Archivos\\MercadoLibreCopia.txt";
            string pathAZGuardar = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Tps_Laboratorio_II\\TP3\\Colmenares.Yesid.2A.TP3\\Archivos\\AmazonCopia.txt";
            string pathXMLGuardar = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Tps_Laboratorio_II\\TP3\\Colmenares.Yesid.2A.TP3\\Archivos\\SerializacionCopia.xml";



            Deposito<Producto> deposito;

            //FUNCION AGREGAR
            Console.WriteLine("******************************************************************");
            Console.WriteLine("AGREGO AL DEPOSITO DOS PRODUCTOS DE MERCADO LIBRE Y DOS DE AMAZON\n");
            deposito = Program.AgregarProductosAlDeposito();


            //INFORMES DEL DEPOSITO
            Console.WriteLine("******************************************************************");
            Console.WriteLine("MUESTRO ALGUNOS INFORMES DEL DEPOSITO\n");
            Program.GenerarInformesDelDeposito(deposito);


            //CONTROLES DEL DEPOSITO
            Console.WriteLine("******************************************************************");
            Console.WriteLine("CONTROLO Y GENERO EL CONTROL DE PAUSADAS\n");
            Program.ControlDePausadas(deposito);


            //ELIMINO UN PRODUCTO DEL DEPOSITO
            Console.WriteLine("******************************************************************");
            Console.WriteLine("ELIMINO EL PRIMER PRODUCTO DEL DEPOSITO\n");
            Program.EliminoUnProductoDelDeposito(deposito);


            //REMPLAZO UN PRODUCTO DEL DEPOSITO
            Console.WriteLine("******************************************************************");
            Console.WriteLine("REMPLAZO EL PRIMER PRODUCTO DEL DEPOSITO POR OTRO\n");
            Program.RemplazoUnProductoDelDeposito(deposito);


            //OBTENGO EL INDEX DEL PRODUCTO
            Console.WriteLine("******************************************************************");
            Console.WriteLine("OBTENGO EL INDEX DEL PRODUCTO HITMAN 3 DEL DEPOSITO\n");
            Program.ObtengoElIndexDelProducto(deposito);


            //LIMPIO DEL DEPOSITO
            Console.WriteLine("******************************************************************");
            Console.WriteLine("LIMPIO DEL DEPOSITO\n");
            Program.LimpioElDeposito(deposito);


            //CARGO UN LISTA DE PRODUCTOS DESDE UN ARCHIVO SERIALIZADO XML
            Console.WriteLine("******************************************************************");
            Console.WriteLine("CARGO UNA LISTA DE PRODUCTOS DESDE UN ARCHIVO SERIALIZADO XML\n");
            deposito = Program.CargarListaDeProductosDesdeArchivoSerializadoXML(pathXML, deposito);


            //GUARDO UNA LISTA DE PRODUCTOS EN UN ARCHIVO XML
            Console.WriteLine("******************************************************************");
            Console.WriteLine("GUARDO UNA LISTA DE PRODUCTOS EN UN ARCHIVO SERIALIZADO XML\n");
            Program.GuardarListaDeProductosArchivoSerializadoXML(pathXMLGuardar, deposito.Productos);
        }

        public static Deposito<Producto> AgregarProductosAlDeposito()
        {
            MercadoLibre ml_JurassicWorld = new MercadoLibre("258", "Jurassic World", 3000, 1, "Nuevo", "Activa", "Gratuita");
            MercadoLibre ml_SuperMarioWorld = new MercadoLibre("369", "SuperMarioWorld", 12000, 0, "Usado", "Inactiva", "Gratuita");
            MercadoLibre ml_CrashTeamRacing = new MercadoLibre("787", "Crash Team Racing", 8400, 2, "Nuevo", "Activa", "Gratuita");
            MercadoLibre ml_NeedForSpeedHeat = new MercadoLibre("951", "Need For Speed Heat", 6600, 3, "Nuevo", "Activa", "Gratuita");
            MercadoLibre ml_SpidermanGoty = new MercadoLibre("623", "Spiderman Goty", 4800, 7, "Nuevo", "Activa", "Gratuita");

            Amazon ml_GhostOfTshima = new Amazon("487", "Ghost Of Tshima", 8500, 2, "Usado", "Activa", "Gratuita");
            Amazon ml_MarvelAvengers = new Amazon("159", "Marvel Avengers", 8000, 0, "Usado", "Activa", "Gratuita");
            Amazon ml_Hitman3 = new Amazon("326", "Hitman 3", 7500, 1, "Usado", "Activa", "Gratuita");
            Amazon ml_CODColdWar = new Amazon("195", "COD Cold War", 10000, 1, "Usado", "Activa", "Gratuita");
            Amazon ml_Outlast = new Amazon("623", "Outlast", 12000, 5, "Usado", "Activa", "Gratuita");

            Deposito<Producto> deposito = new Deposito<Producto>();

            deposito.Agregar(ml_JurassicWorld);
            deposito.Agregar(ml_SuperMarioWorld);
            deposito.Agregar(ml_GhostOfTshima);
            deposito.Agregar(ml_MarvelAvengers);
            deposito.Agregar(ml_CrashTeamRacing);
            deposito.Agregar(ml_Hitman3);

            foreach (Producto item in deposito.Productos)
            {
                Console.WriteLine(item);
            }

            return deposito;
        }

        public static void GenerarInformesDelDeposito(Deposito<Producto> deposito)
        {
            Console.WriteLine("INFORME PRODUCTOS CON CONDICION NUEVO");
            foreach (Producto item in deposito.InfoCondicionNuevo())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("INFORME PRODUCTOS CON ESTADO INACTIVO");
            foreach (Producto item in deposito.InfoEstadoInactivo())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("INFORME PRODUCTOS SIN STOCK");
            foreach (Producto item in deposito.InfoSinStock())
            {
                Console.WriteLine(item);
            }
        }

        public static void ControlDePausadas(Deposito<Producto> deposito)
        {
            Console.WriteLine("SIGUIENTES PRODUCTOS TIENEN UN ERROR EN LAS PAUSADAS");
            foreach (Producto item in deposito.ControlPausadas())
            {
                Console.WriteLine(item);
            }
        }

        public static void EliminoUnProductoDelDeposito(Deposito<Producto> deposito)
        {
            MercadoLibre ml_JurassicWorld = new MercadoLibre("258", "Jurassic World", 3000, 1, "Nuevo", "Activa", "Gratuita");

            deposito.Eliminar(ml_JurassicWorld);

            foreach (Producto item in deposito.Productos)
            {
                Console.WriteLine(item);
            }
        }

        public static void RemplazoUnProductoDelDeposito(Deposito<Producto> deposito)
        {
            MercadoLibre ml_SuperMarioWorld = new MercadoLibre("369", "Remplazo Producto", 12000, 0, "Usado", "Activa", "Premium");

            deposito.Remplazar(ml_SuperMarioWorld);

            foreach (Producto item in deposito.Productos)
            {
                Console.WriteLine(item);
            }
        }

        public static void ObtengoElIndexDelProducto(Deposito<Producto> deposito)
        {
            Amazon ml_Hitman3 = new Amazon("326", "Hitman 3", 7500, 1, "Usado", "Activa", "Gratuita");

            Console.WriteLine("El index del producto Hitman 3 es: {0}",deposito.ObtenerIndex(ml_Hitman3));
        }

        public static void LimpioElDeposito(Deposito<Producto> deposito)
        {
            deposito.Limpiar();

            Console.WriteLine("LISTA DE PRODUCTOS: {0}", deposito.CantidadProductos);

            foreach (Producto item in deposito.Productos)
            {
                Console.WriteLine(item);
            }
        }

        public static Deposito<Producto> CargarListaDeProductosDesdeArchivoSerializadoXML(string path, Deposito<Producto> deposito)
        {
            List<Producto> listaProductos = Archivo.CargarXml(path, typeof(List<Producto>));

            deposito.AgregarLista(listaProductos);

            Console.WriteLine("MUESTRO EL DEPOSITO");
            foreach (Producto item in deposito.Productos)
            {
                Console.WriteLine(item);
            }

            return deposito;
        }

        public static void GuardarListaDeProductosArchivoSerializadoXML(string path, List<Producto> listaProductos)
        {
            Archivo.GuardarXml(path, listaProductos, typeof(List<Producto>));
        }
    }
}
