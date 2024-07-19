using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Principal : Form
    {
        private bool isPerfilVisible = false;
        public Principal()
        {
            InitializeComponent();
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            personalizar();
        }

        private void personalizar()
        {
            SubMenuMant.Visible = false;
            SubMenuStock.Visible = false;
            SubMenuVentas.Visible = false;
            subMenuUser.Visible = false;
        }

        private void AbrirForm(object formhijo)
        {
            if (panelContenedor.Controls.Count > 0)
                panelContenedor.Controls.RemoveAt(0);
            Form fh = formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

        private void ocultar()
        {
            if (SubMenuMant.Visible == true)
            {
                SubMenuMant.Visible = false;
            }
            if (SubMenuStock.Visible == true)
            {
                SubMenuStock.Visible = false;
            }
            if (SubMenuVentas.Visible == true)
            {
                SubMenuVentas.Visible = false;
            }
            if (subMenuUser.Visible == true)
            {
                subMenuUser.Visible = false;
            }
        }

        private void mostrar(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                ocultar();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            label1.Text = "Usuario";
            mostrar(subMenuUser);
        }

        private void btnMant_Click(object sender, EventArgs e)
        {
            label1.Text = "Mantenimiento";
            mostrar(SubMenuMant);
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            label1.Text = "Stock";
            mostrar(SubMenuStock);
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            label1.Text = "Ventas";
            mostrar(SubMenuVentas);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            label1.Text = "Reportes";
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            label1.Text = "Configuración";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Inicio x = new Inicio();
            x.Show();
            this.Hide();
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            label1.Text = "Mantenimiento de Productos";
            AbrirForm(new Productos());
        }

        private void btnProovedor_Click(object sender, EventArgs e)
        {
            label1.Text = "Mantenimiento de Proveedores";
            AbrirForm(new Proveedor());
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            label1.Text = "Mantenimiento de Clientes";
            AbrirForm(new Cliente());
        }

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            label1.Text = "Mantenimiento de Empleados";
            AbrirForm(new Empleado());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            label1.Text = "Menu Prinicipal";
        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {
            label1.Text = "Entrada de Producto";
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            label1.Text = "Inventario";
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            label1.Text = "Salida de Producto";
        }

        private void btnCaja_Click(object sender, EventArgs e)
        {
            label1.Text = "Caja";
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            if (!isPerfilVisible)
            {
                // Mostrar el formulario de perfil
                AbrirForm(new PerfilEmpleado());
                isPerfilVisible = true;
            }
            else
            {
                // Ocultar el formulario de perfil
                panelContenedor.Controls.Clear();
                isPerfilVisible = false;
            }
        }
    }
}