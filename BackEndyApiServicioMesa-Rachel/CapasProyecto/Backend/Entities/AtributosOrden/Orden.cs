using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Entities

{
    public class Orden
    {
        public int idOrden { get; set; }
        public int idMesa { get; set; }
        public int idUsuario { get; set; }
    }
}