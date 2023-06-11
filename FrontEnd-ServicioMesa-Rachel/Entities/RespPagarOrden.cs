using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacion5.Entities
{
    public class RespPagarOrden
    {
        public bool result { get; set; }
        public List<string> listaMensajesOErrores = new List<string>();
    }
}
