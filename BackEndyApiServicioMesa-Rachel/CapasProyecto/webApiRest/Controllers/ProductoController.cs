using Backend.Entities;
using Backend.Entities.Response.Productos;
using Backend.Logic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace webApiRest.Controllers
{
    public class ProductoController : ApiController
    {


        // GET api/producto - obtener todos los productos/listar todos
        public ResObtenerTodosProductos Get()
        {
            ReqObtenerTodosProductos req = new ReqObtenerTodosProductos();

            logProductos logicBackEnd = new logProductos();
            return logicBackEnd.obtenerTodosProductos(req);
        }

        // GET api/producto/<idProducto> - obtener un producto en especifico
        public ResObtenerProducto Get(int id)
        {
            ReqObtenerProducto req = new ReqObtenerProducto();
            req.idProducto = id;
            logProductos logicBackend = new logProductos();
            return logicBackend.obtenerUnProducto(req);

        }

        // POST api/producto - crear un nuevo producto
        public ResIngresarProducto Post([FromBody] ReqIngresarProducto req)
        {
            logProductos logicBackend = new logProductos();
            return logicBackend.crearProducto(req);

        }

        // PUT api/producto/<idProducto> - actualizar el producto/eliminar un producto en especifico
        public ResActualizarProducto Put([FromBody] ReqActualizarProducto req)
        {
            logProductos logicBackend = new logProductos();
            return logicBackend.actualizarProducto(req);
        }


        // DELETE api/producto/<idProducto>/  - eliminar un producto en especifico

        public ResEliminarProducto Delete(int idProducto)
        {
            ReqEliminarProducto req = new ReqEliminarProducto();
            req.idProducto = idProducto;
            logProductos logicBackend = new logProductos();
            return logicBackend.eliminarProducto(req);
        }

    }
}