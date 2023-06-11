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
    public class MesaController : ApiController
    {
        // GET: api/Mesa
        public ResObtenerTodasMesas Get()
        {
            ReqObtenerTodasMesas req = new ReqObtenerTodasMesas();

            logMesa logicBackEnd = new logMesa();
            return logicBackEnd.obtenerTodasMesas(req);
        }

        //// GET: api/Mesa/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Mesa
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Mesa/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Mesa/5
        //public void Delete(int id)
        //{
        //}
    }
}
