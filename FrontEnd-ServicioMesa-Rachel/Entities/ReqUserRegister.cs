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
    public class ReqUserRegister
    {
        string _nombrePersona;
        string _apellido;
        long _telefono;
        long _cedula;
        string _contrasena;
        string _correo;
        int _idTipoUsuario;

        public ReqUserRegister()
        {
            _nombrePersona = "";
            _apellido = "";
            _telefono = 0;
            _cedula = 0;
            _contrasena = "";
            _correo = "";
            _idTipoUsuario = 0;
        }

        public string NombrePersona { get => _nombrePersona; set => _nombrePersona = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public long Telefono { get => _telefono; set => _telefono = value; }
        public long Cedula { get => _cedula; set => _cedula = value; }
        public string Contrasena { get => _contrasena; set => _contrasena = value; }
        public string Correo { get => _correo; set => _correo = value; }
        public int IdTipoUsuario { get => _idTipoUsuario; set => _idTipoUsuario = value; }
    }

    public class elUsuarioRegistro
    {
        public ReqUserRegister elUsuario = new ReqUserRegister();
        //public string session { get; set; }
    }
}
