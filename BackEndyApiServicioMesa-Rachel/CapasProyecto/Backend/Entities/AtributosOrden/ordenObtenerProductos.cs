using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Entities
{
    public class ordenObtenerProductos
    {
        public int idOrden { get; set; }   
        public int idProducto { get; set; }
        public string nombre { get; set; } 
        public double precio { get; set; }  

        public int idCategoria { get; set; }
        public string cantidad { get; set; }   
    }
}