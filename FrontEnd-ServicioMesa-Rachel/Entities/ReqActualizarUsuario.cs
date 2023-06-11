using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/* Unmerged change from project 'ProyectoProgramacion5 (net7.0-android)'
Before:
using System.Threading.Tasks;

namespace ProyectoProgramacion5.Entities.Usuarios.Request
After:
using System.Threading.Tasks;
using ProyectoProgramacion5;
using ProyectoProgramacion5.Entities;
using ProyectoProgramacion5.Entities;
using ProyectoProgramacion5.Entities.Usuarios;
using ProyectoProgramacion5.Entities.Usuarios.Request
*/
using System.Threading.Tasks;

namespace ProyectoProgramacion5.Entities
{
    public class ReqActualizarUsuario
    {
        int _idUsuario;
        string _nombrePersona;
        string _apellido;
        string _correo;
        int _telefono;
        int _cedula;
        string _contrasena;
        int _idTipoUsuario;

        public ReqActualizarUsuario()
        {
            _idUsuario = 0;
            _nombrePersona = "";
            _apellido = "";
            _correo = "";
            _telefono = 0;
            _cedula = 0;
            _contrasena = "";
            _idTipoUsuario = 0;
        }

        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public string NombrePersona { get => _nombrePersona; set => _nombrePersona = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string Correo { get => _correo; set => _correo = value; }
        public int Telefono { get => _telefono; set => _telefono = value; }
        public int Cedula { get => _cedula; set => _cedula = value; }
        public string Contrasena { get => _contrasena; set => _contrasena = value; }
        public int IdTipoUsuario { get => _idTipoUsuario; set => _idTipoUsuario = value; }
    }

    public class elUsuarioActualizar
    {
        public ReqActualizarUsuario elUsuario = new ReqActualizarUsuario();
        public string session { get; set; }
    }
}
