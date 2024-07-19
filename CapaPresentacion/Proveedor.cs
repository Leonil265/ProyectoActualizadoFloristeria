using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Proveedor : Form
    {
        public Proveedor()
        {
            InitializeComponent();
        }

        private void Proveedor_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //boton de nuevo 
            txtID.Clear();
            txtRif.Clear();
            txtNombre.Clear();
            txtTelef.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
            txtID.ReadOnly = false;
            txtNombre.ReadOnly = false;
            txtTelef.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtDireccion.ReadOnly = false;
            checkMateriaP.Checked = false;
            checkPapeleria.Checked = false;
            checkPapeleria.Checked = false;
            
        }
    }
}
