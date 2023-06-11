using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacion5.Entities
{
    public class RespListaProductos
    {
        int _idProducto;
        string _nombre;
        float _precio;
        int _idCategoria;
        string _descripcion;
        int _cantidadEnOrden;

        public RespListaProductos()
        {
            IdProducto = 0;
            Nombre = "";
            Precio = 0;
            IdCategoria = 0;
            Descripcion = "";
            _cantidadEnOrden = 0;
        }

        public int IdProducto { get => _idProducto; set => _idProducto = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public float Precio { get => _precio; set => _precio = value; }
        public int IdCategoria { get => _idCategoria; set => _idCategoria = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public int CantidadEnOrden { get => _cantidadEnOrden; set => _cantidadEnOrden = value; }
    }

}
