using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Entities
{
    public class Factura
    {
        public int idFactura { get; set; }
        public string nombreCliente { get; set; }
        public int telefonoCliente { get; set; }    
        public DateTime fecha { get; set; } 
        public double montoFactura { get; set; }
        public double montoPago { get; set; }  
        public double vueltoPago { get; set; }   
        public int numTarjeta { get; set; } 
        public int comprobSinpe {get; set; } 
        public int idMesa { get; set; } 
        public int idOrden { get; set; }
        public int idUsuario { get; set; }  
        public int idTipoPago { get; set; } 

    }
}