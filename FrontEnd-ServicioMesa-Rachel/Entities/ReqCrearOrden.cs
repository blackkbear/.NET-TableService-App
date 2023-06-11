using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/* Unmerged change from project 'ProyectoProgramacion5 (net7.0-android)'
Before:
using System.Threading.Tasks;

namespace ProyectoProgramacion5.Entities.Orden.Resquest
After:
using System.Threading.Tasks;
using ProyectoProgramacion5;
using ProyectoProgramacion5.Entities;
using ProyectoProgramacion5.Entities;
using ProyectoProgramacion5.Entities.Orden;
using ProyectoProgramacion5.Entities.Orden.Resquest
*/
using System.Threading.Tasks;

namespace ProyectoProgramacion5.Entities
{
    public class ReqCrearOrden
    {
        int idMesa;
        int idUsuario;

        public ReqCrearOrden()
        {
            idMesa = 0;
            idUsuario = 0;
        }

        public int IdMesa { get => idMesa; set => idMesa = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
    }
    public class ReqCrearLaOrden
    {
        public ReqCrearOrden laOrden = new ReqCrearOrden();
    }
}
