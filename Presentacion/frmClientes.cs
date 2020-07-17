using System;
using System.Windows.Forms;
using Entidades;
using Manejador;

namespace Presentacion
{
    public partial class frmClientes : Form
    {
        private ClienteManejador clientesManejador;
        private Clientes clientes;
        int idCliente;
        public frmClientes()
        {
            InitializeComponent();
            clientes = new Clientes();
            clientesManejador = new ClienteManejador();
            BindingEmpleados();
            
        }
        private void frmProyectos_Load(object sender, EventArgs e)
        {
            BuscarEmpleados("");
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                BindingEmpleados();
                Guardar();
                BuscarEmpleados("");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", ex.Message);
            }
        }
        private void BuscarEmpleados(String filtro)
        {
            dtgClientes.DataSource = clientesManejador.Mostrar(filtro);
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarEmpleados(txtBuscar.Text);
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
            clientes.Nombre = txtNombre.Text;
            clientes.Telefono = txtCorreo.Text;
            clientes.Domicilio = txtTelefono.Text;
            clientes.Rfc = txtTDireccion.Text;
        }
        private void BindingSelectEmpleado()
        {
            //pasamos los datos de la celda de data grid alas entidades
            clientes.Idc = Convert.ToInt32(dtgClientes.CurrentRow.Cells["Idc"].Value.ToString());
            clientes.Nombre = dtgClientes.CurrentRow.Cells["Nombre"].Value.ToString();
            clientes.Telefono = dtgClientes.CurrentRow.Cells["Telefono"].Value.ToString();
            clientes.Domicilio = dtgClientes.CurrentRow.Cells["Domicilio"].Value.ToString();
            clientes.Rfc = dtgClientes.CurrentRow.Cells["Rfc"].Value.ToString();
        }
        private void BindingPasarDatos()
        {
            //pasamos los datos de las entidades a UI
            idCliente = clientes.Idc;
            txtNombre.Text = clientes.Nombre;
            txtCorreo.Text = clientes.Telefono;
            txtTelefono.Text = clientes.Domicilio;
            txtTDireccion.Text = clientes.Rfc;
        }
        private void Eliminar()
        {
            //seleccionamos el ID que vamos a eliminar
            clientes.Idc = Convert.ToInt32(dtgClientes.CurrentRow.Cells["Idc"].Value);
            clientesManejador.Eliminar(clientes);
        }
        private void Guardar()
        {
            try
            {
                //despues validamos si contien ID para saber si va a modificar o guardar
                if (idCliente > 0)
                {
                    clientesManejador.Modificar(clientes);
                    Limpiar();
                }
                else
                {
                    clientesManejador.Guardar(clientes);
                    Limpiar();
                }
            }
            catch
            {
                MessageBox.Show("error en los datos");
            }
        }
        private void Limpiar()
        {
            //vaciamos los datos de las cajas de texto
            idCliente = 0;
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            txtTDireccion.Text = "";
        }
    }
}
