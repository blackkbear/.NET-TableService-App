using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Entities
{
    public class ReqEliminarOrden : Reqbase
    {
        public int idOrden;
        public int idMesa;
    }
}