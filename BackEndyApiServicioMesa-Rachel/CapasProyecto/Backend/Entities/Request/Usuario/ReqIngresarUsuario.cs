using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Entities
{
    //se referencia a reqbase para la sesion, y aqui se crea el metodo para obtener atributo del usuario, que se pediran al servidor
    public class ReqIngresarUsuario : Reqbase
    {
        public Usuario elUsuario;
    }
}