using Microsoft.Maui.Primitives;
using Newtonsoft.Json;
using ProyectoProgramacion5.APIConnection;
using ProyectoProgramacion5.Entities;
using ProyectoProgramacion5.ViewModel;

namespace ProyectoProgramacion5;

public partial class EditOrdernView : ContentPage
{
    int MYorderID = 0;
    string BaseURL = "https://apimesaservicioproyecto.azurewebsites.net/api";
    RespListaProductosOrdenVM OrderList1;    
    public EditOrdernView(RespLogin login, int orderID)
	{
        MYorderID = orderID;
        RespListaProductosOrdenVM OrderList = new RespListaProductosOrdenVM(orderID);
        OrderList1 = OrderList;
        this.BindingContext = OrderList;
        //itializeComponent();
    }
    private void btnMinus_Clicked(object sender, EventArgs e)
    {
        SwipeItem item = sender as SwipeItem;
        var MyProductInfo = item.BindingContext as RespListaProductosOrden;

        foreach (RespListaProductosOrden obj in OrderList1.listaProductos)
        {
            if (obj.IdProducto == MyProductInfo.IdProducto)
            {
                if (obj.CantidadEnOrden > 0)
                {
                    obj.CantidadEnOrden = obj.CantidadEnOrden - 1;
                }
            }
        }
        BindingContext = OrderList1;
       //nitializeComponent();
    }

    private void btnPlus_Clicked(object sender, EventArgs e)
    {
        SwipeItem item = sender as SwipeItem;
        var MyProductInfo = item.BindingContext as RespListaProductosOrden;
        foreach (RespListaProductosOrden obj in OrderList1.listaProductos)
        {
            if (obj.IdProducto == MyProductInfo.IdProducto)
            {
                obj.CantidadEnOrden = obj.CantidadEnOrden + 1;
            }
        }
        BindingContext = OrderList1;
        //InitializeComponent();
    }

    private void btnActualizarOrden_Clicked(object sender, EventArgs e)
    {
        string myBody = "";
        APIModel API = new APIModel();

        List<reqDetalleActLaOrden> detalleOrdenLista = new List<reqDetalleActLaOrden>();

        foreach (RespListaProductosOrden obj in OrderList1.listaProductos)
        {
            reqDetalleActLaOrden detalle = new reqDetalleActLaOrden();
            detalle.actualizarDetalleDeOrden.IdOrden = MYorderID;
            detalle.actualizarDetalleDeOrden.Cantidad = obj.CantidadEnOrden;
            detalle.actualizarDetalleDeOrden.idProducto = obj.IdProducto;
            if (detalle.actualizarDetalleDeOrden.Cantidad > 0)
            {
                detalleOrdenLista.Add(detalle);
            }
        }

        foreach (reqDetalleActLaOrden obj in detalleOrdenLista)
        {
            API.Method = "PUT";
            API.MYURL = BaseURL + "/OrdenDetalle";
            API.Accept = "*/*";
            API.ContentType = "application/json";
            myBody = JsonConvert.SerializeObject(obj);
            API.Body = myBody;
            API.APICall(ref API);
            if (API.Exceptions.IsError)
            {
                DisplayAlert("Error", API.Exceptions.ExceptionMessage, "OK");
            }
        }

        if (API.Exceptions.IsError == false)
        {
            var jsonData = JsonConvert.DeserializeObject<dynamic>(API.Exceptions.ResponseText);

            if (jsonData.result == true)
            {
                DisplayAlert("Ordenes", "Orden Actualizada con éxito", "OK");
                Navigation.PopModalAsync();
            }
            else
            {
                String errores = "";
                foreach (string error in jsonData.listaMensajesOErrores)
                {
                    errores = errores + error + "\n";
                }
                DisplayAlert("Error", errores, "OK");
            }
        }
        else
        {
            DisplayAlert("Error", API.Exceptions.ExceptionMessage, "OK");
        }
    }
}