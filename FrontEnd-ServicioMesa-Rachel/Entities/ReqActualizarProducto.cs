using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/* Unmerged change from project 'ProyectoProgramacion5 (net7.0-android)'
Before:
using System.Threading.Tasks;

namespace ProyectoProgramacion5.Entities.Productos.Request
After:
using System.Threading.Tasks;
using ProyectoProgramacion5;
using ProyectoProgramacion5.Entities;
using ProyectoProgramacion5.Entities;
using ProyectoProgramacion5.Entities.Productos;
using ProyectoProgramacion5.Entities.Productos.Request
*/
using System.Threading.Tasks;

namespace ProyectoProgramacion5.Entities
{
    public class ReqActualizarProducto
    {
        int _idProducto;
        float _precio;
        int _idCategoria;
        string _nombre;
        int _cantidad;

        public ReqActualizarProducto()
        {
            _idProducto = 0;
            _precio = 0;
            _idCategoria = 0;
            _nombre = "";
            _cantidad = 1;

        }

        public int IdProducto { get => _idProducto; set => _idProducto = value; }
        public float Precio { get => _precio; set => _precio = value; }
        public int IdCategoria { get => _idCategoria; set => _idCategoria = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public int cantidadProductos { get => _cantidad; set => _cantidad = value; }
    }

    public class elProductoActualizar
    {
        public ReqActualizarProducto elProducto = new ReqActualizarProducto();
        //public string session { get; set; }
    }

}
