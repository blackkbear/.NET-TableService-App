using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacion5.Entities
{
    public class RespListaProductosOrden
    {
        int _idOrden;
        int _idProducto;
        string _nombre;
        float _precio;
        int _idCategoria;
        int _cantidadEnOrden;

        public RespListaProductosOrden()
        {
            _idOrden = 0;
            _idProducto = 0;
            _nombre = "";
            _precio = 0;
            _idCategoria = 0;
            _cantidadEnOrden = 0;
        }

        public int IdProducto { get => _idProducto; set => _idProducto = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public float Precio { get => _precio; set => _precio = value; }
        public int IdCategoria { get => _idCategoria; set => _idCategoria = value; }
        public int CantidadEnOrden { get => _cantidadEnOrden; set => _cantidadEnOrden = value; }
        public int IdOrden { get => _idOrden; set => _idOrden = value; }
    }
}
