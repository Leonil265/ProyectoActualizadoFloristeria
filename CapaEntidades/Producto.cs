using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Producto
    {
      public int IdProducto { get; set; }
        public string Categoria { get; set; }

        public string Nombre { get; set; }
        public float Precio { get; set; }
        public float Costo { get; set; }
        public string Periodo { get; set; }
        public string Fecha_de_registro { get; set; }
    }
}
