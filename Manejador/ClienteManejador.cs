using System.Collections.Generic;
using Entidades;
using AccesoDatos;

namespace Manejador
{
    public class ClienteManejador
    {
        private static ClientesAccesoDatos clientesAccesoDatos;
        public ClienteManejador()
        {
            clientesAccesoDatos = new ClientesAccesoDatos();
        }
        public void Guardar(Clientes clientes)
        {
            clientesAccesoDatos.Guardar(clientes);
        }
        public void Eliminar(Clientes clientes)
        {
            clientesAccesoDatos.Eliminar(clientes);
        }
        public void Modificar(Clientes clientes)
        {
            clientesAccesoDatos.Modificar(clientes);
        }
        public List<Clientes> Mostrar(string filtro)
        {
            var list = new List<Clientes>();
            list = clientesAccesoDatos.Mostar(filtro);
            return list;
        }
    }
}
