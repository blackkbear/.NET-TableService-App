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
    public class LoginController : ApiController
    {
        public IHttpActionResult Post([FromBody] ReqUsuarioLogin req)
        {
            logValidarLogin validarLogin = new logValidarLogin();
            ResUsuarioLogin response = validarLogin.validarLogin(req);

            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
