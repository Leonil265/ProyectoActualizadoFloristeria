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
    public partial class Inicio : Form
    {
        public Conexion conect = new Conexion();


        public Inicio()
        {
            InitializeComponent();
            personalizar();
            timer1.Enabled = false;
        }

        private void personalizar()
        {
            panelcarga.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btningreso_Click(object sender, EventArgs e)
        {
            if (txtuser.Text.Length != 0 && txtpassword.Text.Length != 0)
            {
                string user = txtuser.Text, password = txtpassword.Text;

                string consulta = "Select IdEmpleado from Empleado where Usuario = @user and Contraseña = @password";

                using (SqlConnection connection = conect.ObtenerConexion())
                {
                    connection.Open();

                    using (SqlCommand cm = new SqlCommand(consulta, connection))
                    {
                        cm.Parameters.AddWithValue("@user", user);
                        cm.Parameters.AddWithValue("@password", password);

                        using (SqlDataReader leer = cm.ExecuteReader())
                        {
                            if (leer.Read())
                            {
                                Sesion.IdEmpleado = leer.GetInt32(0); // Guardar el IdEmpleado en la clase estática Sesion
                                panelcarga.Visible = true;
                                timer1.Enabled = true;
                                timer1.Interval = 3000;
                                timer1.Tick += (s, args) =>
                                {
                                    timer1.Enabled = false;
                                    Principal x = new Principal();
                                    x.Show();
                                    this.Hide();
                                };
                            }
                            else
                            {
                                MessageBox.Show("Usuario o contraseña incorrectos");
                            }
                        }
                    }
                }
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            btnOcultar.BringToFront();
            txtpassword.UseSystemPasswordChar = false;
        }

        private void btnOcultar_Click(object sender, EventArgs e)
        {
            btnMostrar.BringToFront();
            txtpassword.UseSystemPasswordChar = true;

        }

        private void txtuser_Enter(object sender, EventArgs e)
        {
            if (txtuser.Text == "Usuario")
            {
                txtuser.Text = "";
                txtuser.ForeColor = Color.Black;
            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (txtuser.Text == "")
            {
                txtuser.Text = "Usuario";
                txtuser.ForeColor = Color.DimGray;
            }
        }

        private void txtpassword_Enter(object sender, EventArgs e)
        {
            if (txtpassword.Text == "Contraseña")
            {
                txtpassword.Text = "";
                txtpassword.ForeColor = Color.Black;
                txtpassword.UseSystemPasswordChar= true;
            }
        }

        private void txtpassword_Leave(object sender, EventArgs e)
        {
            if (txtpassword.Text == "Contraseña")
            {
                txtpassword.Text = "";
                txtpassword.ForeColor = Color.DimGray;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
