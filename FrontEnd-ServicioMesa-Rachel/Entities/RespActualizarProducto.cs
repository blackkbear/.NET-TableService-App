using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacion5.Entities
{
    internal class RespActualizarProducto
    {
        public bool result { get; set; }
        public List<string> listaMensajesOErrores = new List<string>();
    }
}
