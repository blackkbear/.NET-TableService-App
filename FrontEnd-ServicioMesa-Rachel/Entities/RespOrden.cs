using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/* Unmerged change from project 'ProyectoProgramacion5 (net7.0-android)'
Before:
using System.Threading.Tasks;

namespace ProyectoProgramacion5.Entities.Orden.Response
After:
using System.Threading.Tasks;
using ProyectoProgramacion5;
using ProyectoProgramacion5.Entities;
using ProyectoProgramacion5.Entities;
using ProyectoProgramacion5.Entities.Orden;
using ProyectoProgramacion5.Entities.Orden.Response
*/
using System.Threading.Tasks;

namespace ProyectoProgramacion5.Entities
{
    public class RespOrden
    {
        int _idOrden;
        decimal _montoOrden;

        public RespOrden()
        {
            _idOrden = 0;
            _montoOrden = 0;
        }

        public int IdOrden { get => _idOrden; set => _idOrden = value; }
        public decimal MontoOrden { get => _montoOrden; set => _montoOrden = value; }
    }
    public class RespLaOrden
    {
        public RespOrden laOrden = new RespOrden();
        public bool result { get; set; }
        public string listaMensajesOErrores { get; set; }
    }
}
