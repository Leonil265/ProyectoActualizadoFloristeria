using CapaDatos;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Empleado : Form
    {
        static private Conexion conect = new Conexion();
        SqlConnection connection = conect.ObtenerConexion();
        SqlDataAdapter adaptador;
        private DataTable dt = new DataTable();

        public Empleado()
        {
            InitializeComponent();
        }

        private void Empleado_Load(object sender, EventArgs e)
        {
            adaptador = new SqlDataAdapter("SELECT * FROM Empleado", connection);
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;

            // Cambiar el nombre de las columnas en el DataGridView
            dataGridView1.Columns["NombreCompleto"].HeaderText = "Nombre Completo";
            dataGridView1.Columns["Usuario"].HeaderText = "Usuario";
            dataGridView1.Columns["Correo"].HeaderText = "Correo Electrónico";
            dataGridView1.Columns["Telefono"].HeaderText = "Teléfono";
            dataGridView1.Columns["Direccion"].HeaderText = "Dirección";
            dataGridView1.Columns["Rol"].HeaderText = "Rol";
            dataGridView1.Columns["Estado"].HeaderText = "Estado";
        }

        private void txtcCI_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcCI_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y el carácter de control para eliminar
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txtNombreCompleto.Text = row.Cells["NombreCompleto"].Value.ToString();
                txtcCI.Text = row.Cells["IdEmpleado"].Value.ToString();
                txtTelefono.Text = row.Cells["Telefono"].Value.ToString();
                txtCorreo.Text = row.Cells["Correo"].Value.ToString();
                txtDireccion.Text = row.Cells["Direccion"].Value.ToString();
                txtUsuario.Text = row.Cells["Usuario"].Value.ToString();
                txtContraseña.Text = row.Cells["Contraseña"].Value.ToString();
                chkActivo.Checked = row.Cells["Estado"].Value.ToString() == "Activo";
                if (row.Cells["Rol"].Value.ToString() == "Administrador")
                {
                    rbAdmin.Checked = true;
                }
                else
                {
                    rbCajero.Checked = true;
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que txtcCI no esté vacío
                if (string.IsNullOrWhiteSpace(txtcCI.Text))
                {
                    MessageBox.Show("El campo C.I no puede estar vacío.");
                    return;
                }

                int idEmpleado;
                if (!int.TryParse(txtcCI.Text, out idEmpleado))
                {
                    MessageBox.Show("El campo C.I debe ser un número válido.");
                    return;
                }

                string estado = chkActivo.Checked ? "Activo" : "Inactivo";
                string rol = rbAdmin.Checked ? "Administrador" : "Cajero";

                SqlCommand command = new SqlCommand("INSERT INTO Empleado (IdEmpleado, NombreCompleto, Telefono, Correo, Direccion, Usuario, Contraseña, Rol, Estado) VALUES (@IdEmpleado, @NombreCompleto, @Telefono, @Correo, @Direccion, @Usuario, @Contraseña, @Rol, @Estado)", connection);
                command.Parameters.AddWithValue("@IdEmpleado", idEmpleado);
                command.Parameters.AddWithValue("@NombreCompleto", txtNombreCompleto.Text);
                command.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                command.Parameters.AddWithValue("@Correo", txtCorreo.Text);
                command.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                command.Parameters.AddWithValue("@Usuario", txtUsuario.Text);
                command.Parameters.AddWithValue("@Contraseña", txtContraseña.Text);
                command.Parameters.AddWithValue("@Rol", rol);
                command.Parameters.AddWithValue("@Estado", estado);

                connection.Open();
                int result = command.ExecuteNonQuery();
                connection.Close();

                if (result > 0)
                {
                    MessageBox.Show("Empleado creado correctamente");
                }
                else
                {
                    MessageBox.Show("No se pudo crear el empleado.");
                }

                // Refrescar el DataGridView
                dt.Clear();
                adaptador.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand("DELETE FROM Empleado WHERE IdEmpleado=@IdEmpleado", connection);
                command.Parameters.AddWithValue("@IdEmpleado", txtcCI.Text);

                connection.Open();
                int result = command.ExecuteNonQuery();
                connection.Close();

                if (result > 0)
                {
                    MessageBox.Show("Empleado eliminado correctamente");
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el empleado. Verifica que el ID es correcto.");
                }

                // Refrescar el DataGridView
                dt.Clear();
                adaptador.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}
