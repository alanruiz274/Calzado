using System;
using System.Windows.Forms;
using Entidades;
using Manejador;

namespace Presentacion
{
    public partial class frmVentas : Form
    {
        private VentasManejador ventasManejador;
        private Ventas ventas;
        int idVenta;
        public frmVentas()
        {
            InitializeComponent();
            ventas = new Ventas();
            ventasManejador = new VentasManejador();
            //BindingEmpleados();
            
        }
        private void frmProyectos_Load(object sender, EventArgs e)
        {
            llenarClientes("");
            llenarProductos("");
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.CustomFormat = "yyyy-MM-dd";
            dtgDatos.DataSource = ventasManejador.Mostrar("");

        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                BindingEmpleados();
                Guardar();
                dtgDatos.DataSource = ventasManejador.Mostrar("");
                //BuscarEmpleados("");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", ex.Message);
            }
        }
        private void BuscarEmpleados(String filtro)
        {
            dtgDatos.DataSource = ventasManejador.Mostrar(filtro);
        }
        private void dtgProyectos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BindingSelectEmpleado();
            BindingPasarDatos();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            BindingSelectEmpleado();
            BindingPasarDatos();
        }
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            BindingSelectEmpleado();
            if (MessageBox.Show("Estas seguro que deseas eliminar el registro", "Eliminar Registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    Eliminar();
                    BuscarEmpleados("");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo Eliminar \n", ex.Message);
                }
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        //Metodos generales para mandar llamar
        private void BindingEmpleados()
        {
            //pasamos los datos de UI alas entidades
            ventas.Producto = cmbProducto.SelectedValue.ToString();
            ventas.Cliente = cmbCliente.SelectedValue.ToString();
            ventas.Cantidad = Convert.ToInt32(txtCantidad.Text);
            ventas.Fecha = dtpFecha.Text;
        }
        private void BindingSelectEmpleado()
        {
            //pasamos los datos de la celda de data grid alas entidades
            /*ventas.Idc = Convert.ToInt32(dtgClientes.CurrentRow.Cells["Idc"].Value.ToString());
            ventas.Nombre = dtgClientes.CurrentRow.Cells["Nombre"].Value.ToString();
            ventas.Telefono = dtgClientes.CurrentRow.Cells["Telefono"].Value.ToString();
            ventas.Domicilio = dtgClientes.CurrentRow.Cells["Domicilio"].Value.ToString();
            ventas.Rfc = dtgClientes.CurrentRow.Cells["Rfc"].Value.ToString();*/
        }
        private void BindingPasarDatos()
        {
            //pasamos los datos de las entidades a UI
            /*idVenta = ventas.Idc;
            txtNombre.Text = ventas.Nombre;
            txtCorreo.Text = ventas.Telefono;
            txtCantidad.Text = ventas.Domicilio;
            txtTDireccion.Text = ventas.Rfc;*/
        }
        private void Eliminar()
        {
            //seleccionamos el ID que vamos a eliminar
            //ventas.Idc = Convert.ToInt32(dtgClientes.CurrentRow.Cells["Idc"].Value);
            //ventasManejador.Eliminar(ventas);
        }
        private void Guardar()
        {
                //despues validamos si contien ID para saber si va a modificar o guardar
                if (idVenta > 0)
                {
                    ventasManejador.Modificar(ventas);
                    Limpiar();
                }
                else
                {
                    ventasManejador.Guardar(ventas);
                    Limpiar();
                }
        }
        private void Limpiar()
        {
            //vaciamos los datos de las cajas de texto
            idVenta = 0;
            cmbProducto.Text = "";
            cmbCliente.Text = "";
            txtCantidad.Text = "";
            dtpFecha.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void llenarClientes(string filtro)
        {
            cmbCliente.DataSource = ventasManejador.ComboCliente(filtro);
            cmbCliente.DisplayMember = "Nombre";
            cmbCliente.ValueMember = "Idc";
        }
        private void llenarProductos(string filtro)
        {
            cmbProducto.DataSource = ventasManejador.ComboProducto(filtro);
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "Idp";
        }

        private void cmbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBuscar.SelectedIndex == 0)
            {
                lblTitulo.Text = cmbBuscar.Text;
                dtgDatos.DataSource = ventasManejador.MostarProducto();
            }
            if (cmbBuscar.SelectedIndex == 1)
            {
                lblTitulo.Text = cmbBuscar.Text;
                dtgDatos.DataSource = ventasManejador.MostarQuiencompromas();
            }
            if (cmbBuscar.SelectedIndex == 2)
            {
                lblTitulo.Text = cmbBuscar.Text;
                dtgDatos.DataSource = ventasManejador.MostrarDia();
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            lblTitulo.Text = "Ventas";
            dtgDatos.DataSource = ventasManejador.Mostrar("");
        }
    }
}
