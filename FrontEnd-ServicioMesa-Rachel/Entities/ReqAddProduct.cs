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
    public class ReqAddProduct
    {
        float _precio;
        int _idCategoria;
        int _cantidadProductos;
        string _nombre;


        public ReqAddProduct()
        {
            _precio = 0;
            _idCategoria = 0;
            _nombre = "";
            _cantidadProductos = 1;
        }

        public float Precio { get => _precio; set => _precio = value; }
        public int IdCategoria { get => _idCategoria; set => _idCategoria = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public int CantidadProductos { get => _cantidadProductos; set => _cantidadProductos = value; }
    }

    public class elProductoRegistro
    {
        public ReqAddProduct elProducto = new ReqAddProduct();
    }
}

