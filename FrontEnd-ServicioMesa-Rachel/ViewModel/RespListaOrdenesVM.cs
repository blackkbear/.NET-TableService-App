using Newtonsoft.Json;
using ProyectoProgramacion5.APIConnection;
using ProyectoProgramacion5.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacion5.ViewModel
{
    internal class RespListaOrdenesVM
    {
        string BaseURL = "https://apimesaservicioproyecto.azurewebsites.net/api";
        public List<RespListaOrdenes> listaOrdenes { get; set; } = new List<RespListaOrdenes>();

        public RespListaOrdenesVM()
        {
            APIModel API = new APIModel();
            API.Method = "GET";
            API.MYURL = BaseURL + "/Orden";
            API.Accept = "*/*";
            API.APICall(ref API);

            if (API.Exceptions.IsError == false)
            {                
                var jsonData = JsonConvert.DeserializeObject<dynamic>(API.Exceptions.ResponseText);
                if(jsonData.result == true) {
                    foreach (var data in jsonData.listaTodasOrdenes)
                    {
                        RespListaOrdenes Orden = new RespListaOrdenes();
                        Orden.IdOrden = data.idOrden;
                        Orden.NombreMesa = data.nombreMesa;
                        listaOrdenes.Add(Orden);
                    }
                }      
            }
        }

    }
}
