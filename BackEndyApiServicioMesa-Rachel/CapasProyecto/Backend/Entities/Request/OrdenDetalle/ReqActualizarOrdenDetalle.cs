using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Entities
{
    public class ReqActualizarOrdenDetalle : Reqbase
    {
        //verificar esto porque el sp espera cantidad, idOrder, idProducto
        public actualizarOrdenDetalle actualizarDetalleDeOrden;
    }
}