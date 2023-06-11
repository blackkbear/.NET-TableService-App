using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Backend.Entities 
{
    public class ResGenerarFacturaEfectivo : Resbase
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public byte[] PdfFile { get; set; }
        public string NombreCliente { get; set; }
        public string TelefonoCliente { get; set; }
        public DateTime Fecha { get; set; }
        public decimal MontoFactura { get; set; }
    }

}