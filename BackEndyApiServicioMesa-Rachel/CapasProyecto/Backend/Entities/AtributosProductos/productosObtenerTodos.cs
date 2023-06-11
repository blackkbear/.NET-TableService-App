using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Entities.AtributosProductos
{
    public class productosObtenerTodos
    {

        public int idProducto { get; set; }

        public float precio { get; set; }

        public int idCategoria { get; set; }

        public float cantidadProductos { get; set; }
        public string nombre { get; set; }

    }
}