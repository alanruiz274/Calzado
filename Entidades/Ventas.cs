namespace Entidades
{
    public class Ventas
    {
        private int _Idv;
        private string _Producto;
        private string _Cliente;
        private int _Cantidad;
        private string _Fecha;
        private double _Precio;
        private string _Total;

        public int Idv { get => _Idv; set => _Idv = value; }
        public string Producto { get => _Producto; set => _Producto = value; }
        public string Cliente { get => _Cliente; set => _Cliente = value; }
        public int Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public string Fecha { get => _Fecha; set => _Fecha = value; }
        public double Precio { get => _Precio; set => _Precio = value; }
        public string Total { get => _Total; set => _Total = value; }
    }
}
