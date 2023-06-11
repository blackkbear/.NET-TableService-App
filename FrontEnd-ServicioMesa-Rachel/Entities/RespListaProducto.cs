using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/* Unmerged change from project 'ProyectoProgramacion5 (net7.0-android)'
Before:
using System.Threading.Tasks;

namespace ProyectoProgramacion5.Entities.Productos.Response
After:
using System.Threading.Tasks;
using ProyectoProgramacion5;
using ProyectoProgramacion5.Entities;
using ProyectoProgramacion5.Entities;
using ProyectoProgramacion5.Entities.Productos;
using ProyectoProgramacion5.Entities.Productos.Response
*/
using System.Threading.Tasks;

namespace ProyectoProgramacion5.Entities
{
    public class RespListaProducto
    {
        int _idProducto;
        string _nombre;
        float _precio;
        int _idCategoria;
        string _descripcion;

        public RespListaProducto()
        {
            _idProducto = 0;
            _nombre = "";
            _precio = 0;
            _idCategoria = 0;
            _descripcion = "";
        }

        public int IdProducto { get => _idProducto; set => _idProducto = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public float Precio { get => _precio; set => _precio = value; }
        public int IdCategoria { get => _idCategoria; set => _idCategoria = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
    }

    public class RespListaProductoCompleted : RespListaProducto
    {
        public RespListaProducto elProducto { get; set; }
        public bool result { get; set; }
        public string listaMensajesOErrores { get; set; }
    }
}
