using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacion5.Entities
{
    internal class RespListaOrdenes
    {
        int _idOrden;
        string _nombreMesa;

        public RespListaOrdenes()
        {
            _idOrden = 0;
            _nombreMesa = "";
        }

        public int IdOrden { get => _idOrden; set => _idOrden = value; }
        public string NombreMesa { get => _nombreMesa; set => _nombreMesa = value; }
    }
}
