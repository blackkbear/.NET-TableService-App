using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacion5.Entities
{
    internal class RespListaUsuarios
    {
        int _idUsuario;
        string _correo;
        int _personaID;
        string _nombrePersona;
        string _apellido;
        int _idTipoUsuario;
        string _tipoRoll;

        public RespListaUsuarios()
        {
            _idUsuario = 0;
            _correo = "";
            _personaID = 0;
            _nombrePersona = "";
            _apellido = "";
            _idTipoUsuario = 0;
            _tipoRoll = "";
        }

        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public string Correo { get => _correo; set => _correo = value; }
        public int PersonaID { get => _personaID; set => _personaID = value; }
        public string NombrePersona { get => _nombrePersona; set => _nombrePersona = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public int IdTipoUsuario { get => _idTipoUsuario; set => _idTipoUsuario = value; }
        public string TipoRoll { get => _tipoRoll; set => _tipoRoll = value; }
    }
}
