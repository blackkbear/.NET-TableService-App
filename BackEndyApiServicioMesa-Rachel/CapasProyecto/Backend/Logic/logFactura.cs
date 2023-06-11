using Backend.dataAccess;
using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using iTextSharp.text.pdf;
using PdfSharp.Drawing;
//using PdfSharpCore.Pdf;
//using PdfSharpCore.Drawing;
using System.IO;
using System.Data.Linq;

namespace Backend.Logic
{
    public class logFactura
    {
        public ResObtenerTodasFacturas obtenerTodasFacturas(ReqObtenerTodasFacturas req)
        {
            ResObtenerTodasFacturas res = new ResObtenerTodasFacturas();
            try
            {

                conexionLinqDataContext laConexion = new conexionLinqDataContext();
                List<SP_ListarFacturasResult> result = laConexion.SP_ListarFacturas().ToList();
                if (result.Count != 0)
                {
                    res.listaTodasFacturas = new List<Factura>();
                    res.listaTodasFacturas = this.armarListadoFacturas(result);

                    res.result = true;
                }
                else
                {
                    res.listaMensajesOErrores = new List<string>();
                    res.listaMensajesOErrores.Add("No hay facturas.");
                    res.result = false;
                }


            }
            catch (Exception ex)
            {
                res.listaMensajesOErrores = new List<string>();
                res.listaMensajesOErrores.Add("Error al procesar la solicitud de obtener todas las facturas " + ex.Message);
                res.result = false;
            }
            return res;
        }
        //listado para el metodo de obtener todas las ordenes
        private List<Factura> armarListadoFacturas(List<SP_ListarFacturasResult> allFacturasListLinq)
        {
            List<Factura> allFacturasListaArmada = new List<Factura>();
            foreach (SP_ListarFacturasResult elementoLinq in allFacturasListLinq)
            {
                Factura listaFacturas = new Factura();
                listaFacturas.idFactura = elementoLinq.idFactura;
                listaFacturas.nombreCliente = elementoLinq.nombreCliente;
                listaFacturas.telefonoCliente = elementoLinq.telefonoCliente ?? 0;
                listaFacturas.fecha = (DateTime)elementoLinq.fecha;
                listaFacturas.montoFactura = (double)(elementoLinq.montoFactura ?? 0);
                listaFacturas.montoPago = (double)(elementoLinq.montoPago ?? 0);
                listaFacturas.vueltoPago = (double)(elementoLinq.vueltoPago ?? 0);
                listaFacturas.numTarjeta = (int)(elementoLinq.numTarjeta ?? 0);
                listaFacturas.comprobSinpe = (int)(elementoLinq.comprobSinpe ?? 0);
                listaFacturas.idMesa = (int)(elementoLinq.idMesa ?? 0);
                listaFacturas.idOrden = (int)(elementoLinq.idOrden ?? 0);
                listaFacturas.idUsuario = (int)(elementoLinq.idUsuario ?? 0);
                listaFacturas.idTipoPago = (int)(elementoLinq.idTipoPago ?? 0);


                allFacturasListaArmada.Add(listaFacturas);
            }
            return allFacturasListaArmada;
        }


            //public ResGenerarFacturaEfectivo GenerarFacturaEfectivo(ReqGenerarFacturaEfectivo req)
            //{
            //    // Initialize response object
            //    var res = new ResGenerarFacturaEfectivo();

            //    // Call stored procedure to generate invoice
            //    // Replace this with your own data access code
            //    var factura = GenerarFacturaDeDb(req);

            //    if (factura != null)
            //    {
            //        // Create new PDF document
            //        var document = new PdfDocument();

            //        // Add new page to PDF document
            //        var page = document.AddPage();

            //        // Create graphics object for the page
            //        var gfx = XGraphics.FromPdfPage(page);

            //        // Set font for the invoice
            //        var font = new XFont("Arial", 12, XFontStyle.Bold);

            //        // Define position for each invoice element
            //        var x = 50;
            //        var y = 50;

            //        // Add invoice elements to PDF document
            //        gfx.DrawString("FACTURA", font, XBrushes.Black, x, y);
            //        y += 20;
            //        gfx.DrawString("Cliente: " + factura.nombreCliente, font, XBrushes.Black, x, y);
            //        y += 20;
            //        gfx.DrawString("Teléfono: " + factura.TelefonoCliente, font, XBrushes.Black, x, y);
            //        y += 20;
            //        gfx.DrawString("Fecha: " + factura.Fecha.ToShortDateString(), font, XBrushes.Black, x, y);
            //        y += 20;
            //        gfx.DrawString("Monto: " + factura.MontoFactura.ToString("C"), font, XBrushes.Black, x, y);
            //        y += 20;
            //        gfx.DrawString("Monto recibido: " + req.MontoPago.ToString("C"), font, XBrushes.Black, x, y);
            //        y += 20;
            //        gfx.DrawString("Vuelto: " + (req.MontoPago - factura.MontoFactura).ToString("C"), font, XBrushes.Black, x, y);

            //        // Save PDF document to memory stream
            //        using (var stream = new MemoryStream())
            //        {
            //            document.Save(stream);
            //            res.PdfFile = stream.ToArray();
            //        }

            //        // Set success response
            //        res.Codigo = 1;
            //        res.Mensaje = "Factura generada exitosamente.";
            //    }
            //    else
            //    {
            //        // Set error response
            //        res.Codigo = -1;
            //        res.Mensaje = "Ocurrió un error al generar la factura.";
            //    }

            //    return res;
            //}
            //private Factura GenerarFacturaDeDb(ReqGenerarFacturaEfectivo req)
            //{

            //    var linqDataContext = new conexionLinqDataContext();
            //    var factura = linqDataContext.SP_GenerarFacturaEfectivo(req.idOrden, req.nombreCliente, req.numTelef, req.montoPago, ref errorId);

            //    return factura.FirstOrDefault();
            //}
    }
}