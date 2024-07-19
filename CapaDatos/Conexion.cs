using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDatos
{
    public class Conexion
    {
        public static string Cn = "Data Source= LAPTOP-O2E6A0VL\\SQLEXPRESS; Initial Catalog= Floristería; Integrated Security = true;";

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(Cn);
        }

        public void AbrirConexion() 
        { 
            using (SqlConnection Conexion = new SqlConnection(Cn))
            { 
                try 
                { 
                    Conexion.Open(); 
                } 
                catch (Exception e)
                {
                    MessageBox.Show("Error de conexion: "+ e.Message);
                }
            }
        }
    }
}
