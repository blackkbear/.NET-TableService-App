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
    public class GestionarOrdenController : ApiController
    {



        // POST: api/GestionarOrden // para cancelar orden
        public ResCancelarOrden Post([FromBody] ReqCancelarOrden req)
        {
            logOrden logicBackend = new logOrden();
            return logicBackend.cancelarOrden(req);

        }

        // PUT: api/GestionarOrden/5 // cobrar orden

        public ResCobrarOrden Put([FromBody] ReqCobrarOrden req)
        {
            logOrden logicBackend = new logOrden();
            return logicBackend.cobrarOrden(req);
        }



    }
}
