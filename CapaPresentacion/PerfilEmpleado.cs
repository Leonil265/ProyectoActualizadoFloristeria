using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaPresentacion
{
    public partial class PerfilEmpleado : Form
    {
        static private Conexion conect = new Conexion();
        SqlConnection connection = conect.ObtenerConexion();
        SqlDataAdapter adaptador;
        public PerfilEmpleado()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void PerfilEmpleado_Load(object sender, EventArgs e)
        {
            CargarDatosEmpleado();
        }
        private void CargarDatosEmpleado()
        {
            try
            {
                int idEmpleado = Sesion.IdEmpleado;
                adaptador = new SqlDataAdapter("SELECT NombreCompleto, Direccion, Telefono, Usuario FROM Empleado WHERE IdEmpleado=@IdEmpleado", connection);
                adaptador.SelectCommand.Parameters.AddWithValue("@IdEmpleado", idEmpleado);

                DataTable dtEmpleado = new DataTable();
                adaptador.Fill(dtEmpleado);

                if (dtEmpleado.Rows.Count > 0)
                {
                    DataRow row = dtEmpleado.Rows[0];
                    lblNombreCompletosb.Text = row["NombreCompleto"].ToString();
                    lblDireccionsb.Text = row["Direccion"].ToString();
                    lblTelefonosb.Text = row["Telefono"].ToString();
                    lblUsuariosb.Text = row["Usuario"].ToString();
                }
                else
                {
                    MessageBox.Show("Empleado no encontrado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del empleado: " + ex.Message);
            }
        }

        private void lblDireccionsb_Click(object sender, EventArgs e)
        {

        }
    }
}