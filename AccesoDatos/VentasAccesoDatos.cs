using System;
using System.Collections.Generic;
using System.Data;
using ConexionBD;
using Entidades;

namespace AccesoDatos
{
    public class VentasAccesoDatos
    {
        Conexion conexion;
        Ventas ventas;
        Productos productos;
        Clientes clientes;
        public VentasAccesoDatos()
        {
            conexion = new Conexion();
            ventas = new Ventas();
            productos = new Productos();
            clientes = new Clientes();
        }

        public string Eliminar(dynamic accion)
        {
            ventas = accion;
            var consulta = string.Format("delete from VENTA WHERE id_v='{0}'", ventas.Idv);
            conexion.EjecutarConsulta(consulta);
            return "";
        }
        public string Guardar(dynamic accion)
        {
            ventas = accion;
            var consulta = string.Format("insert into VENTA values(null,'{0}', '{1}', '{2}', '{3}')", ventas.Producto, ventas.Cliente, ventas.Cantidad, ventas.Fecha);
            conexion.EjecutarConsulta(consulta);
            return "";
        }
        public string Modificar(dynamic accion)
        {
            ventas = accion;
            var consulta = string.Format("update VENTA set fkproducto_v = '{0}', fkcliente_v = '{1}', cantidad_v = '{2}', fecha_v = '{3}' WHERE id_v='{4}'", ventas.Producto, ventas.Cliente, ventas.Cantidad, ventas.Fecha, ventas.Idv);
            conexion.EjecutarConsulta(consulta);
            return "";
        }

        public List<Ventas> Mostar(string filtro)//string filtro)
        {
            var list = new List<Ventas>();
            string consulta = string.Format("Select * from v_ventas", filtro);
            var ds = conexion.ObtenerDatos(consulta, "v_ventas");
            var dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                var ventas = new Ventas
                {
                    Idv = Convert.ToInt32(row["id_v"].ToString()),
                    Producto = row["nombre_p"].ToString(),
                    Cliente = row["nombre_c"].ToString(),
                    Cantidad = Convert.ToInt32(row["cantidad_v"].ToString()),
                    Fecha = row["fecha"].ToString(),
                    Precio = Convert.ToDouble(row["precio_p"].ToString()),
                    Total = Convert.ToDouble(row["total"].ToString())
                };
                list.Add(ventas);
            }
            return list;
        }
        public List<Productos> ComboProducto(string filtro)//string filtro)
        {
            var list = new List<Productos>();
            string consulta = string.Format("Select * from PRODUCTO where nombre_p like '%{0}%' order by id_p desc", filtro);
            var ds = conexion.ObtenerDatos(consulta, "PRODUCTO");
            var dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                var productos = new Productos
                {
                    Idp = Convert.ToInt32(row["id_p"].ToString()),
                    Nombre = row["nombre_p"].ToString(),
                    Precio = Convert.ToDouble(row["precio_p"].ToString())
                };
                list.Add(productos);
            }
            return list;
        }
        public List<Ventas> MostarDia()
        {
            var list = new List<Ventas>();
            string consulta = string.Format("Select * from v_quediavendemas");
            var ds = conexion.ObtenerDatos(consulta, "v_quediavendemas");
            var dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                var ventas = new Ventas
                {
                    Fecha = row["fecha"].ToString()
                };
                list.Add(ventas);
            }
            return list;
        }
        public List<Productos> MostarProducto()
        {
            var list = new List<Productos>();
            string consulta = string.Format("Select * from v_productomasvendido");
            var ds = conexion.ObtenerDatos(consulta, "v_productomasvendido");
            var dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                var productos = new Productos
                {
                    Idp = Convert.ToInt32(row["id_p"].ToString()),
                    Nombre = row["nombre_p"].ToString(),
                    Precio = Convert.ToDouble(row["total"].ToString())
                };
                list.Add(productos);
            }
            return list;
        }
        public List<Clientes> MostarQuiencompromas()
        {
            var list = new List<Clientes>();
            string consulta = string.Format("Select * from v_quiencompramas");
            var ds = conexion.ObtenerDatos(consulta, "v_quiencompramas");
            var dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                var clientes = new Clientes
                {
                    Nombre = row["nombre_c"].ToString()
                };
                list.Add(clientes);
            }
            return list;
        }
    }
}
