using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Entities
{
    public class actualizarOrdenDetalle
    {
        internal int? idOrden;

        public int cantidad { get; set; }
        public int IdOrden { get; set; }

        public int idProducto { get; set; }
    }
}