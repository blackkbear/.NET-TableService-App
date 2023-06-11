using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Entities
{
    public class Usuario
    //get y set son para indicar que podemos obtener o modificar
    {
        //atributos persona
        public int Persona_ID { get; set; }  
        public string NombrePersona { get; set; }

        public string Apellido { get; set; }

        public int Telefono { get; set; }

        public int Cedula { get; set; }

        // atributos de usuario
        public int idUsuario { get; set; }
        public string contrasena { get; set; }
        public string correo { get; set; }
        public int idTipoUsuario { get; set; }
        public string TipoUsuario { get; set; }
    
          
    }
}