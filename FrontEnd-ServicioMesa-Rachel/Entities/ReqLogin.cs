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
    public class ReqLogin
    {
        string _correo;
        string _contrasena;

        public ReqLogin()
        {
            _correo = "";
            _contrasena = "";
        }

        public string Correo { get => _correo; set => _correo = value; }
        public string Contrasena { get => _contrasena; set => _contrasena = value; }
    }
    public class ReqElUserLogin
    {
        public ReqLogin elUserLogin = new ReqLogin();
    }
}
