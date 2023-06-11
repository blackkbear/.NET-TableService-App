using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Entities
{
    public class usuarioObtenerTodos
    {
        public int idUsuario { get; set; }
        public string correo { get; set; }
        public int Persona_ID { get; set; }
        public string NombrePersona { get; set; }
        public string Apellido { get; set; }
        public int idTipoUsuario { get; set; }
        public string TipoUsuario { get; set; }
    }
}