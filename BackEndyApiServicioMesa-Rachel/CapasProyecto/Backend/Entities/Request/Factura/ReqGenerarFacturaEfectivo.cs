using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Backend.Entities
{
    public class ReqGenerarFacturaEfectivo : Reqbase
    {

        public int idOrden { get; set; }


        public string nombreCliente { get; set; }

    
        public int numTelef { get; set; }

        public int montoPago { get; set; }
    }
}