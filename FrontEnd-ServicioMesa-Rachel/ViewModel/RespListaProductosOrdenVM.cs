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
    internal class RespListaProductosOrdenVM
    {
        string BaseURL = "https://apimesaservicioproyecto.azurewebsites.net/api";

        public List<RespListaProductosOrden> listaProductos { get; set; } = new List<RespListaProductosOrden>();

        public RespListaProductosOrdenVM(int OrdenID)
        {
            RespListaProductosOrden obj = new RespListaProductosOrden();

            APIModel API = new APIModel();
            API.Method = "GET";
            API.MYURL = BaseURL + "/ProductosOrden?idOrden=" + OrdenID.ToString();
            API.Accept = "*/*";
            API.APICall(ref API);

            if (API.Exceptions.IsError == false)
            {
                var jsonData = JsonConvert.DeserializeObject<dynamic>(API.Exceptions.ResponseText);
                if (jsonData.result == true)
                {
                    if(jsonData.listaTodosProductosOrden != null) {
                        foreach (var data in jsonData.listaTodosProductosOrden)
                        {
                            bool flag = false;
                            RespListaProductosOrden producto = new RespListaProductosOrden();
                            producto.IdProducto = data.idProducto;
                            producto.Nombre = data.nombre;
                            producto.Precio = data.precio;
                            producto.IdCategoria = data.idCategoria;
                            producto.CantidadEnOrden = data.cantidad;
                            foreach (RespListaProductosOrden prod in listaProductos)
                            {
                                if (prod.IdProducto == producto.IdProducto)
                                {
                                    flag = true;
                                }
                            }
                            if (flag == false)
                            {
                                listaProductos.Add(producto);
                            }
                        }
                    }
                    
                }
                else
                {
                    String errores = "";
                    foreach (string error in jsonData.listaMensajesOErrores)
                    {
                        errores = errores + error + "\n";
                    }
                }
            }


            API.MYURL = BaseURL + "/producto";
            API.APICall(ref API);

            if (API.Exceptions.IsError == false)
            {
                var jsonData = JsonConvert.DeserializeObject<dynamic>(API.Exceptions.ResponseText);

                if (jsonData.result == true)
                {
                    foreach (var data in jsonData.listaTodosProductos)
                    {
                        RespListaProductosOrden producto = new RespListaProductosOrden();
                        producto.IdProducto = data.idProducto;
                        producto.Nombre = data.nombre;
                        producto.Precio = data.precio;
                        producto.IdCategoria = data.idCategoria;
                        listaProductos.Add(producto);
                    }
                }
            }
        }
        public void addProduct(int id)
        {
            foreach (RespListaProductosOrden obj in listaProductos)
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
            foreach (RespListaProductosOrden obj in listaProductos)
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
    }
}
