namespace Entidades
{
    public interface IAnalisisDeposito<T> 
        where T : Producto
    {
        public string ProductosActivosCostosos();
        public string ProductosInactivosEconomicos();
        public string ProductosTipoPremium();
        public string PromedioDePrecios();
        public string ProductosNuevosConTipoClasico();
        public string ProductosSinStock();
    }
}