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
    public class ProductosOrdenController : ApiController
    {
        //// GET: api/ProductosOrden
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/ProductosOrden/5

        public ResObtenerProductosOrden Get(int idOrden)
        {
            ReqObtenerProductosOrden req = new ReqObtenerProductosOrden();
            req.idOrden = idOrden;
            logOrden logicBackend = new logOrden();
            return logicBackend.obtenerProductosOrden(req);

        }

        //// POST: api/ProductosOrden
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/ProductosOrden/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/ProductosOrden/5
        //public void Delete(int id)
        //{
        //}
    }
}
