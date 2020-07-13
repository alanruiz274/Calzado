namespace Entidades
{
    public class Clientes
    {
        private int _Idc;
        private string _Nombre;
        private string _Telefono;
        private string _Domicilio;
        private string _Rfc;

        public int Idc { get => _Idc; set => _Idc = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Domicilio { get => _Domicilio; set => _Domicilio = value; }
        public string Rfc { get => _Rfc; set => _Rfc = value; }
    }
}
