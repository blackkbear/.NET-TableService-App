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
    public class OrdenController : ApiController
    {
        // GET: api/Orden
        public ResObtenerTodasOrdenes Get()
        {
            ReqObtenerTodasOrdenes req = new ReqObtenerTodasOrdenes();

            logOrden logicBackEnd = new logOrden();
            return logicBackEnd.obtenerTodasOrdenes(req);
        }

        // GET: api/Orden/5
        public ResObtenerOrden Get(int idOrden)
        {
            ReqObtenerOrden req = new ReqObtenerOrden();
            req.idOrden = idOrden;
          
            logOrden logicBackend = new logOrden();
            return logicBackend.obtenerUnaOrden(req);

        }

        // POST: api/Orden
        public ResIngresarOrden Post([FromBody] ReqIngresarOrden req)
        {
            logOrden logicBackend = new logOrden();
            return logicBackend.crearOrden(req);

        }

        // PUT: api/Orden/5
        public ResActualizarOrden Put([FromBody] ReqActualizarOrden req)
        {
            logOrden logicBackend = new logOrden();
            return logicBackend.actualizarOrden(req);
        }

        // DELETE: api/Orden/5
        public ResEliminarOrden Delete(int idOrden, int idMesa)
        {
            ReqEliminarOrden req = new ReqEliminarOrden();
            req.idOrden = idOrden;
            req.idMesa = idMesa;
            logOrden logicBackend = new logOrden();
            return logicBackend.eliminarOrden(req);
        }
    }
}
