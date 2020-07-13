using System;
using System.Collections.Generic;
using System.Data;
using ConexionBD;
using Entidades;

namespace AccesoDatos
{
    public class ClientesAccesoDatos
    {
        Conexion conexion;
        Clientes clientes;
        public ClientesAccesoDatos()
        {
            conexion = new Conexion();
            clientes = new Clientes();
        }

        public string Eliminar(dynamic accion)
        {
            clientes = accion;
            var consulta = string.Format("delete from CLIENTE WHERE id_c='{0}'", clientes.Idc);
            conexion.EjecutarConsulta(consulta);
            return "";
        }
        public string Guardar(dynamic accion)
        {
            clientes = accion;
            var consulta = string.Format("insert into CLIENTE values(null,'{0}', '{1}', '{2}', '{3}')", clientes.Nombre, clientes.Telefono, clientes.Domicilio, clientes.Rfc);
            conexion.EjecutarConsulta(consulta);
            return "";
        }
        public string Modificar(dynamic accion)
        {
            clientes = accion;
            var consulta = string.Format("update CLIENTE set nombre_c = '{0}', telefono_c = '{1}', domicilio_c = '{2}', rfc_c = '{3}' WHERE id_c='{4}'", clientes.Nombre, clientes.Telefono, clientes.Domicilio, clientes.Rfc, clientes.Idc);
            conexion.EjecutarConsulta(consulta);
            return "";
        }

        public List<Clientes> Mostar(string filtro)//string filtro)
        {
            var list = new List<Clientes>();
            string consulta = string.Format("Select * from CLIENTE where nombre_c like '%{0}%' order by id_c desc", filtro);
            var ds = conexion.ObtenerDatos(consulta, "CLIENTE");
            var dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                var clientes = new Clientes
                {
                    Idc = Convert.ToInt32(row["id_c"].ToString()),
                    Nombre = row["nombre_c"].ToString(),
                    Telefono = row["telefono_c"].ToString(),
                    Domicilio = row["domicilio_c"].ToString(),
                    Rfc = row["rfc_c"].ToString()
                };
                list.Add(clientes);
            }
            return list;
        }
    }
}
