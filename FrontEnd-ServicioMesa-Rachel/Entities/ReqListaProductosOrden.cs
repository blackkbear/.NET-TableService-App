using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacion5.Entities
{
    class ReqListaProductosOrden
    {
        int _idOrden;

        public ReqListaProductosOrden()
        {
            _idOrden = 0;
        }

        public int IdOrden { get => _idOrden; set => _idOrden = value; }
    }
}
