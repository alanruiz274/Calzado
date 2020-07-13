using System.Collections.Generic;
using Entidades;
using AccesoDatos;

namespace Manejador
{
    public class VentasManejador
    {
        private static VentasAccesoDatos ventasAccesoDatos;
        private static ClientesAccesoDatos clientesAccesoDatos;

        public VentasManejador()
        {
            ventasAccesoDatos = new VentasAccesoDatos();
            clientesAccesoDatos = new ClientesAccesoDatos();
        }
        public void Guardar(Ventas ventas)
        {
            ventasAccesoDatos.Guardar(ventas);
        }
        public void Eliminar(Ventas ventas)
        {
            ventasAccesoDatos.Eliminar(ventas);
        }
        public void Modificar(Ventas ventas)
        {
            ventasAccesoDatos.Modificar(ventas);
        }
        public List<Ventas> Mostrar(string filtro)
        {
            var list = new List<Ventas>();
            list = ventasAccesoDatos.Mostar(filtro);
            return list;
        }
        public List<Productos> ComboProducto(string filtro)
        {
            var list = new List<Productos>();
            list = ventasAccesoDatos.ComboProducto(filtro);
            return list;
        }
        public List<Clientes> ComboCliente(string filtro)
        {
            var list = new List<Clientes>();
            list = clientesAccesoDatos.Mostar(filtro);
            return list;
        }
        public List<Productos> MostarProducto()
        {
            var list = new List<Productos>();
            list = ventasAccesoDatos.MostarProducto();
            return list;
        }
        public List<Clientes> MostarQuiencompromas()
        {
            var list = new List<Clientes>();
            list = ventasAccesoDatos.MostarQuiencompromas();
            return list;
        }
        public List<Ventas> MostrarDia( )
        {
            var list = new List<Ventas>();
            list = ventasAccesoDatos.MostarDia();
            return list;
        }
    }
}
