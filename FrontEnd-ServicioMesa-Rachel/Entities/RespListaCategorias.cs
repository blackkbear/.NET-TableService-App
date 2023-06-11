using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacion5.Entities
{
    class RespListaCategorias
    {
        int _idCategoria;
        string _descripcion;

        public RespListaCategorias()
        {
            _idCategoria = 0;
            _descripcion = "";
        }

        public int IdCategoria { get => _idCategoria; set => _idCategoria = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
    }
}
