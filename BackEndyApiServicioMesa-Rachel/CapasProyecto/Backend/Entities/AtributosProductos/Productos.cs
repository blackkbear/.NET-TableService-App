using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Entities
{
    public class Productos
    {
        public int idProducto { get; set; }
        public float precio { get; set; }
        public int idCategoria { get; set; }
        public int cantidadProductos { get; set; }
        public string nombre { get; set; }


    }
}