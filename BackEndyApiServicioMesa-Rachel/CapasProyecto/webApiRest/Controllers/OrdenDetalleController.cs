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
    public class OrdenDetalleController : ApiController
    {
        // GET: api/OrdenDetalle - listar
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/OrdenDetalle/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/OrdenDetalle - crear orden detalle nuevo
        public ResIngresarOrdenDetalle Post([FromBody] ReqIngresarOrdenDetalle req)
        {
            logOrdenDetalle logicBackend = new logOrdenDetalle();
            return logicBackend.crearOrdenDetalle(req);

        }

        // PUT: api/OrdenDetalle/5 - actualizar orden detalle

        public ResActualizarOrdenDetalle Put([FromBody] ReqActualizarOrdenDetalle req)
        {
            logOrdenDetalle logicBackend = new logOrdenDetalle();
            return logicBackend.actualizarOrdenDetalle(req);
        }


        // DELETE: api/OrdenDetalle/5 - eliminar orden detalle especifico
        public ResEliminarOrdenDetalle Delete(int idDetalleOrden)
        {
            ReqEliminarOrdenDetalle req = new ReqEliminarOrdenDetalle();
            req.idDetalleOrden = idDetalleOrden;
            logOrdenDetalle logicBackend = new logOrdenDetalle();
            return logicBackend.eliminarOrdenDetalle(req);
        }
    }
}
