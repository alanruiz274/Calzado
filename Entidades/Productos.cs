namespace Entidades
{
    public class Productos
    {
        private int _Idp;
        private string _Nombre;
        private string _Precio;

        public int Idp { get => _Idp; set => _Idp = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Precio { get => _Precio; set => _Precio = value; }
    }
}
