using CapaDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Productos : Form
    {
        static private Conexion conect = new Conexion();

        SqlConnection connection = conect.ObtenerConexion();
        SqlDataAdapter adaptador;
        private DataTable dt = new DataTable();
        public Productos()
        {
            InitializeComponent();
            label2.Text = DateTime.Now.ToString("dd/MM/yyyy");
            
        }

        private void cboxColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxColor.SelectedIndex != -1) 
            { 
                if (cboxColor.SelectedIndex == 0)
                    panelColor.BackColor = Color.Yellow;
                if (cboxColor.SelectedIndex == 1)
                    panelColor.BackColor = Color.DarkOrange;
                if (cboxColor.SelectedIndex == 2)
                    panelColor.BackColor = Color.Red;
                if (cboxColor.SelectedIndex == 3)
                    panelColor.BackColor = Color.HotPink;
                if (cboxColor.SelectedIndex == 4)
                    panelColor.BackColor = Color.DarkViolet;
                if (cboxColor.SelectedIndex == 5)
                    panelColor.BackColor = Color.LightSkyBlue;
                if (cboxColor.SelectedIndex == 6)
                    panelColor.BackColor = Color.LimeGreen;
                if (cboxColor.SelectedIndex == 7)
                    panelColor.BackColor = Color.WhiteSmoke;
                if (cboxColor.SelectedIndex == 8)
                    panelColor.BackColor = Color.Black;
            }
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                adaptador = new SqlDataAdapter("SELECT * FROM Producto", connection);
                adaptador.Fill(dt);
                dataGridView1.DataSource = dt;

                // Cambiar los nombres de las columnas
                dataGridView1.Columns["IdProducto"].HeaderText = "ID del Producto";
                dataGridView1.Columns["Fecha_de_registro"].HeaderText = "Fecha de registro";
                // Cambiar el tamaño de las columnas
                // Establecer el ancho en píxeles
                dataGridView1.Columns["Nombre"].Width = 250;
                // Cambiar el tamaño de la fuente de una columna específica (por ejemplo, NombreColumnaBD1)
                dataGridView1.Columns["Nombre"].HeaderCell.Style.Font = new Font("Arial", 8, FontStyle.Bold);
                // Cambiar el tamaño de la fuente de los nombres de las columnas
                // dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14);
                // Opcional: Auto ajustar el tamaño de las columnas basado en el contenido
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                // Cambiar el tamaño de las celdas
                dataGridView1.DefaultCellStyle.Font = new Font("Arial", 11); // Cambiar el tamaño de la fuente
                dataGridView1.RowTemplate.Height = 30; // Cambiar la altura de las filas

                // Ocultar la segunda columna y quinta columna

                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                // Ocultar las últimas 3 columnas

                int totalColumns = dataGridView1.Columns.Count;
                dataGridView1.Columns[totalColumns - 1].Visible = false;
                dataGridView1.Columns[totalColumns - 2].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y el carácter de control para eliminar
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Solo permitir un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y el carácter de control para eliminar
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Solo permitir un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
    }
}
