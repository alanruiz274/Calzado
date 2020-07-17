using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wnsg, int wparam, int lparam);

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSlide_Click(object sender, EventArgs e)
        {
            if (menuVertical.Width == 250)
                menuVertical.Width = 70;
            else
                menuVertical.Width = 250;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (this.Size == Screen.PrimaryScreen.WorkingArea.Size && this.Location == Screen.PrimaryScreen.WorkingArea.Location)
            {
                this.Size = new Size(1300, 650);
            }
            else
            {
                this.Size = Screen.PrimaryScreen.WorkingArea.Size;
                this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            //this.imgFondo.Visible = false;
            AbrirForm(new frmClientes());
        }


        private void logo_Click(object sender, EventArgs e)
        {
        }


        private void btnVentas_Click(object sender, EventArgs e)
        {
            //this.imgFondo.Visible = false;
            AbrirForm(new frmVentas());
        }

        private void imgLogo_Click(object sender, EventArgs e)
        {
            
        }

        private void AbrirForm(object Frmhijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = Frmhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }
        private void CerrarForm()
        {
            
        }
    }
}
