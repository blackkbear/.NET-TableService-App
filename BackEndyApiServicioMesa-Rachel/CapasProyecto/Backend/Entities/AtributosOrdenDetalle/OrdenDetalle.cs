using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Entities
{
    public class OrdenDetalle
    {
        
            public int idDetalleOrden { get; set; }
            public int cantidad { get; set; }
            public int idOrden { get; set; }

            public int idProducto { get; set; }

            public double subtotal { get; set; }


    }
}