using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace ConexionBD
{
    public class Conexion
    {
        MySqlConnection _Conexion = new MySqlConnection("server=localhost; user=root; password=root; database=CALZADO");
        public  MySqlConnection AbrirConexion()
        {
            if (_Conexion.State == ConnectionState.Closed)
                _Conexion.Open();
            return _Conexion;
        }
        public  MySqlConnection CerarConexion()
        {
            if (_Conexion.State == ConnectionState.Open)
                _Conexion.Close();
            return _Conexion;
        }
        public void EjecutarConsulta(string cadena)
        {
            try
            {

                AbrirConexion();
                MySqlCommand cnn = new MySqlCommand(cadena, _Conexion);
                cnn.ExecuteNonQuery();
                CerarConexion();
            }
            catch (MySqlException) { }
        }
        public  DataSet Buscar(string cadena, string tabla)
        {
            var ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(cadena, _Conexion);
                da.Fill(ds, tabla);
                return ds;
        }
        public  DataSet ObtenerDatos(string cadena, string tabla)
        {
            var ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(cadena, _Conexion);
            da.Fill(ds, tabla);
            return ds;
        }
    }
}
