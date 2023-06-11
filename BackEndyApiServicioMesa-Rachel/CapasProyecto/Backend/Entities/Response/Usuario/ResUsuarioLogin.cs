using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Entities
{
    public class ResUsuarioLogin : Resbase
    {

        public int idUsuario;
        public int idTipoUsuario;
        public string NombrePersona;
        public string Apellido;
        public bool esAdmin;
    }
}