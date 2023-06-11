using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/* Unmerged change from project 'ProyectoProgramacion5 (net7.0-android)'
Before:
using System.Threading.Tasks;

namespace ProyectoProgramacion5.Entities.Usuarios.Response
After:
using System.Threading.Tasks;
using ProyectoProgramacion5;
using ProyectoProgramacion5.Entities;
using ProyectoProgramacion5.Entities;
using ProyectoProgramacion5.Entities.Usuarios;
using ProyectoProgramacion5.Entities.Usuarios.Response
*/
using System.Threading.Tasks;

namespace ProyectoProgramacion5.Entities
{
    public class RespListaUsuario
    {
        int _idUsuario;
        int _persona_ID;
        string _nombrePersona;
        string _apellido;
        string _correo;
        string _telefono;
        string _cedula;
        string _contrasena;
        int _idTipoUsuario;

        public RespListaUsuario()
        {
            _idUsuario = 0;
            _persona_ID = 0;
            _nombrePersona = "";
            _apellido = "";
            _correo = "";
            _telefono = "";
            _cedula = "";
            _contrasena = "";
            _idTipoUsuario = 0;
        }

        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public int Persona_ID { get => _persona_ID; set => _persona_ID = value; }
        public string NombrePersona { get => _nombrePersona; set => _nombrePersona = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string Correo { get => _correo; set => _correo = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public string Cedula { get => _cedula; set => _cedula = value; }
        public string Contrasena { get => _contrasena; set => _contrasena = value; }
        public int IdTipoUsuario { get => _idTipoUsuario; set => _idTipoUsuario = value; }
    }
    public class RespListaUsuarioCompleted : RespListaUsuario
    {
        public RespListaUsuario elusuario { get; set; }
        public bool result { get; set; }
        public string listaMensajesOErrores { get; set; }
    }
}

