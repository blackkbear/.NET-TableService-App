using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProyectoProgramacion5.APIConnection;
using ProyectoProgramacion5.Entities;

namespace ProyectoProgramacion5.ViewModel
{
    internal class RespListaProductosVM
    {
        string BaseURL = "https://apimesaservicioproyecto.azurewebsites.net/api";

        public List<RespListaProductos> listaProductos { get; set; } = new List<RespListaProductos>();

        public RespListaProductosVM()
        {
            RespListaProductos obj = new RespListaProductos();

            APIModel API = new APIModel();
            API.Method = "GET";
            API.MYURL = BaseURL + "/producto";
            API.Accept = "*/*";
            API.APICall(ref API);

            if (API.Exceptions.IsError == false)
            {
                var jsonData = JsonConvert.DeserializeObject<dynamic>(API.Exceptions.ResponseText);
                if (jsonData.result == true)
                {
                    if (jsonData.listaTodosProductos != null ) {
                        foreach (var data in jsonData.listaTodosProductos)
                        {
                            RespListaProductos producto = new RespListaProductos();
                            producto.IdProducto = data.idProducto;
                            producto.Nombre = data.nombre;
                            producto.Precio = data.precio;
                            producto.IdCategoria = data.idCategoria;
                            listaProductos.Add(producto);
                        }
                    }
                }
            }
        }
    }
}
