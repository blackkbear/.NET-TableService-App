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
    class RespListaCategoriasVM
    {
        string BaseURL = "https://apimesaservicioproyecto.azurewebsites.net/api";
        public List<RespListaCategorias> listaCategorias { get; set; } = new List<RespListaCategorias>();

        public RespListaCategoriasVM()
        {
            APIModel API = new APIModel();
            API.Method = "GET";
            API.MYURL = BaseURL + "/Categoria";
            API.Accept = "*/*";
            API.APICall(ref API);

            if (API.Exceptions.IsError == false)
            {
                var jsonData = JsonConvert.DeserializeObject<dynamic>(API.Exceptions.ResponseText);
                if (jsonData.result == true)
                {
                    foreach (var data in jsonData.listaTodasCategorias)
                    {
                        RespListaCategorias categoria = new RespListaCategorias();
                        categoria.IdCategoria = data.idCategoria;
                        categoria.Descripcion = data.descripcion;
                        listaCategorias.Add(categoria);
                    }
                }
            }
        }
    }
}
