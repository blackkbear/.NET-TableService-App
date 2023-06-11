using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacion5.Entities
{
    internal class RespListaMesas
    {
        int _idMesa;
        string _nombreMesa;

        public RespListaMesas()
        {
            _idMesa = 0;
            _nombreMesa = "";
        }

        public int IdMesa { get => _idMesa; set => _idMesa = value; }
        public string NombreMesa { get => _nombreMesa; set => _nombreMesa = value; }
    }
}
