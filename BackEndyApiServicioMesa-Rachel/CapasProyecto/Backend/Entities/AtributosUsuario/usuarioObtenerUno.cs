using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Entities
{
    public class usuarioObtenerUno
    {
        public int idUsuario { get; set; }

        public int Persona_ID { get; set; }
        public string NombrePersona { get; set; }

        public string Apellido { get; set; }

        public string correo { get; set; }

        public int Telefono { get; set; }

        public int Cedula { get; set; }
        public string contrasena { get; set; }

        public int idTipoUsuario { get; set; }


    }
}