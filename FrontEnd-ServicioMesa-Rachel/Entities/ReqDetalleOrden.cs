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
    public class reqDetalleOrden
    {
        int _idOrden;
        int _productID;
        int _cantidad;

        public reqDetalleOrden()
        {
            _idOrden = 0;
            _productID = 0;
            _cantidad = 0;
        }

        public int IdOrden { get => _idOrden; set => _idOrden = value; }
        public int idProducto { get => _productID; set => _productID = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }
    }

    internal class reqDetalleLaOrden
    {
        public reqDetalleOrden crearDetalleDeOrden = new reqDetalleOrden();
    }

    internal class reqDetalleActLaOrden
    {
        public reqDetalleOrden actualizarDetalleDeOrden = new reqDetalleOrden();
    }
}
