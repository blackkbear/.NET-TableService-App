using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacion5.Entities
{
    public class RespLogin
    {
        int _idUsuario;
        int _idTipoUsuario;
        string _NombrePersona;
        string _Apellido;
        bool _esAdmin;
        bool _result;
        List<string> _listaMensajesOErrores;

        public RespLogin()
        {
            _idUsuario = 0;
            _idTipoUsuario = 0;
            _NombrePersona = "";
            _Apellido = "";
            _esAdmin = false;
            _result = false;
            _listaMensajesOErrores = new List<string>();
        }

        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public int IdTipoUsuario { get => _idTipoUsuario; set => _idTipoUsuario = value; }
        public string NombrePersona { get => _NombrePersona; set => _NombrePersona = value; }
        public string Apellido { get => _Apellido; set => _Apellido = value; }
        public bool EsAdmin { get => _esAdmin; set => _esAdmin = value; }
        public bool Result { get => _result; set => _result = value; }
        public List<string> ListaMensajesOErrores { get => _listaMensajesOErrores; set => _listaMensajesOErrores = value; }
    }
}
