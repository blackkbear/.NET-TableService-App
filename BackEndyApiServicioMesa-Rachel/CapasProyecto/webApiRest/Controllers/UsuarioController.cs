using Backend.Entities;
using Backend.Logic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace webApiRest.Controllers
{
    public class UsuarioController : ApiController
    {
        // GET api/usuario - obtener todos los usuarios/listar todos
        public ResObtenerTodosUsuarios Get()
        {
            ReqObtenerTodosUsuarios req = new ReqObtenerTodosUsuarios();

            logUsuario logicBackEnd = new logUsuario();
            return logicBackEnd.obtenerTodosUsuarios(req);
        }

        // GET api/usuario/<idUsuario> - obtener un usuario en especifico
        public ResObtenerUsuario Get(int id)
        {
            ReqObtenerUsuario req = new ReqObtenerUsuario();
            req.idUsuario = id;
            logUsuario logicBackend = new logUsuario();
            return logicBackend.obtenerUnUsuario(req);
            
        }

        // POST api/usuario - crear un nuevo usuario
        public ResIngresarUsuario Post([FromBody] ReqIngresarUsuario req)
        {
            logUsuario logicBackend = new logUsuario();
            return logicBackend.crearUsuario(req); 

        }

        // PUT api/usuario/<idUsuario> - actualizar el usuario/eliminar un usuario en especifico
        public ResActualizarUsuario Put([FromBody] ReqActualizarUsuario req)
        {
            logUsuario logicBackend = new logUsuario();
            return logicBackend.actualizarUsuario(req);
        }


        // DELETE api/usuario/<idUsuario>/  - eliminar un usuario en especifico
       
        public ResEliminarUsuario Delete(int id)
        {
            ReqEliminarUsuario req = new ReqEliminarUsuario();
            req.idUsuario = id;
            logUsuario logicBackend = new logUsuario();
            return logicBackend.eliminarUsuario(req);
        }
    }
}
