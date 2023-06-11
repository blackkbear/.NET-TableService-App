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
    public class CategoriaController : ApiController
    {
        // GET: api/Categoria
        public ResObtenerTodasCategorias Get()
        {
            ReqObtenerTodasCategorias req = new ReqObtenerTodasCategorias();

            logCategoria logicBackEnd = new logCategoria();
            return logicBackEnd.obtenerTodasCategorias(req);
        }

        // POST api/usuario - crear categoria
        public ResIngresarCategoria Post([FromBody] ReqIngresarCategoria req)
        {
            logCategoria logicBackend = new logCategoria();
            return logicBackend.crearCategoria(req);

        }

        // PUT api/usuario/<idCategoria> - actualizar el usuario/eliminar una categoria en especifico
        public ResActualizarCategoria Put([FromBody] ReqActualizarCategoria req)
        {
            logCategoria logicBackend = new logCategoria();
            return logicBackend.actualizarCategoria(req);
        }


        // DELETE api/usuario/<idUsuario>/  - eliminar una categoria en especifico

        [HttpDelete]
        public ResEliminarCategoria Delete(int idCateg, string descripcion)
        {
            ReqEliminarCategoria req = new ReqEliminarCategoria();
            req.idCateg = idCateg;
            req.descripcion = descripcion;
            logCategoria logicBackend = new logCategoria();
            return logicBackend.eliminarCategoria(req);
        }
    }
}
