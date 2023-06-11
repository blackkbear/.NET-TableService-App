using Backend.Entities;
using Backend.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace webApiRest.Controllers
{
    public class FacturaController : ApiController
    {
        // GET: api/Factura
        public ResObtenerTodasFacturas Get()
        {
            ReqObtenerTodasFacturas req = new ReqObtenerTodasFacturas();

            logFactura logicBackEnd = new logFactura();
            return logicBackEnd.obtenerTodasFacturas(req);
        }

        // GET: api/Factura/5


        // POST: api/Factura
        //public ResGenerarFacturaEfectivo Post([FromBody] ReqGenerarFacturaEfectivo req)
        //{
        //    logFactura logicBackend = new logFactura();
        //    return logicBackend.generarFacturaEnEfectivo(req);

        //}

        // PUT: api/Factura/5


        // DELETE: api/Factura/5

    }
}
