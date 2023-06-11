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
    internal class CrearOrdenesVM
    {
        string BaseURL = "https://apimesaservicioproyecto.azurewebsites.net/api";
        public List<RespListaMesas> listaMesas { get; set; } = new List<RespListaMesas>();
        public List<RespListaProductos> listaProductos { get; set; } = new List<RespListaProductos>();

        public RespListaMesas MesaSeleccionada { get; set; } = new RespListaMesas();

        public void addProduct(int id)
        {
            foreach (RespListaProductos obj in listaProductos)
            {
                if (obj.IdProducto == id)
                {
                    obj.CantidadEnOrden = obj.CantidadEnOrden + 1;
                    break;
                }
            }
        }
        public void reduceProduct(int id)
        {
            foreach (RespListaProductos obj in listaProductos)
            {
                if (obj.IdProducto == id)
                {
                    if (obj.CantidadEnOrden > 0)
                    {
                        obj.CantidadEnOrden = obj.CantidadEnOrden - 1;
                    }                    
                    break;
                }
            }
        }

        //public CrearOrdenesVM(List<RespListaProductos> listaProductos1)
        //{
        //    listaProductos = listaProductos1;
        //    APIModel API = new APIModel();
        //    API.Method = "GET";
        //    API.MYURL = BaseURL + "/Mesa";
        //    API.Accept = "*/*";
        //    API.APICall(ref API);

        //    if (API.Exceptions.IsError == false)
        //    {
        //        var jsonData = JsonConvert.DeserializeObject<dynamic>(API.Exceptions.ResponseText);
        //        foreach (var data in jsonData)
        //        {
        //            RespListaMesas mesa = new RespListaMesas();
        //            mesa.IdMesa = data.idMesa;
        //            mesa.NombreMesa = data.nombreMesa;
        //            listaMesas.Add(mesa);
        //        }
        //    }
        //}

        public CrearOrdenesVM()
        {
            APIModel API = new APIModel();
            API.Method = "GET";
            API.MYURL = BaseURL + "/Mesa";
            API.Accept = "*/*";
            API.APICall(ref API);

            if (API.Exceptions.IsError == false)
            {
                var jsonData = JsonConvert.DeserializeObject<dynamic>(API.Exceptions.ResponseText);
                if (jsonData.result == true)
                {
                    foreach (var data in jsonData.listaTodasMesas)
                    {
                        RespListaMesas mesa = new RespListaMesas();
                        mesa.IdMesa = data.idMesa;
                        mesa.NombreMesa = data.nombreMesa;
                        listaMesas.Add(mesa);
                    }
                
                }
                
            }

            API.Method = "GET";
            API.MYURL = BaseURL + "/producto";
            API.Accept = "*/*";
            API.APICall(ref API);

            if (API.Exceptions.IsError == false)
            {
                var jsonData = JsonConvert.DeserializeObject<dynamic>(API.Exceptions.ResponseText);
                if (jsonData.result == true)
                {
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