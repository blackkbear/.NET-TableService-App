using Newtonsoft.Json;
using ProyectoProgramacion5.APIConnection;
using ProyectoProgramacion5.Entities;
using ProyectoProgramacion5.ViewModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectoProgramacion5;

public partial class CreateOrderView : ContentPage
{
    RespListaMesas Mesa;
    string errores;
    RespLogin MyLogin;
    int UsuarioID = 0;
    string BaseURL = "https://apimesaservicioproyecto.azurewebsites.net/api";
    CrearOrdenesVM OrderList = new CrearOrdenesVM();
    RespListaMesas mesa = new RespListaMesas();
    public CreateOrderView(RespLogin login)
	{
        MyLogin = login;
        UsuarioID = login.IdUsuario;
        BindingContext = OrderList;
        InitializeComponent();
        cvListaProd.IsEnabled = false;
    }

    private async void btnCrearOrden_Clicked(object sender, EventArgs e)
    {

        string myBody = "";

        RespCrearOrden NewOrden = new RespCrearOrden();
        ReqCrearLaOrden Orden = new ReqCrearLaOrden();
        APIModel API = new APIModel();
        API.Method = "POST";
        API.MYURL = BaseURL + "/Orden";
        API.Accept = "*/*";
        API.ContentType = "application/json";

        Orden.laOrden.IdMesa = int.Parse(OrderList.MesaSeleccionada.IdMesa.ToString()); ;
        Orden.laOrden.IdUsuario = UsuarioID;

        myBody = JsonConvert.SerializeObject(Orden);
        API.Body = myBody;
        API.APICall(ref API);
        if (API.Exceptions.IsError == false)
        {
            NewOrden = JsonConvert.DeserializeObject<RespCrearOrden>(API.Exceptions.ResponseText); 
            if(NewOrden.result == false)
            {
                string errores = "";
                foreach (string error in NewOrden.listaMensajesOErrores)
                {
                    errores = errores + error + "\n";
                }
                await DisplayAlert("Error", errores, "OK");
                return;
            }
        }
        else
        {
            if (NewOrden.result == false)
            {
                errores = "";
                foreach (string error in NewOrden.listaMensajesOErrores)
                {
                    errores = errores + error + "\n";
                }
                await DisplayAlert("Error", errores, "OK");
            }
        }

        
        List<reqDetalleLaOrden> detalleOrdenLista = new List<reqDetalleLaOrden>();

        foreach (RespListaProductos obj in OrderList.listaProductos)
        {
            reqDetalleLaOrden detalle = new reqDetalleLaOrden();
            detalle.crearDetalleDeOrden.IdOrden = NewOrden.orderID;
            detalle.crearDetalleDeOrden.Cantidad = obj.CantidadEnOrden;
            detalle.crearDetalleDeOrden.idProducto = obj.IdProducto;
            if (detalle.crearDetalleDeOrden.Cantidad > 0)
            {
                detalleOrdenLista.Add(detalle);
            }
        }

        foreach (reqDetalleLaOrden obj in detalleOrdenLista)
        {
            API.Method = "POST";
            API.MYURL = BaseURL + "/OrdenDetalle";
            API.Accept = "*/*";
            API.ContentType = "application/json";
            myBody = JsonConvert.SerializeObject(obj);
            API.Body = myBody;
            API.APICall(ref API);
            if (API.Exceptions.IsError)
            {
                await DisplayAlert("Error", API.Exceptions.ExceptionMessage, "OK");
            }
        }

        if (API.Exceptions.IsError == false)
        {

            RespCrearDetalleOrden repCDeta = JsonConvert.DeserializeObject<RespCrearDetalleOrden>(API.Exceptions.ResponseText);

            if (repCDeta.result == false)                
            {
                errores = "";
                foreach (string error in repCDeta.listaMensajesOErrores)
                {
                    errores = errores + error + "\n";
                }

                await DisplayAlert("Error", errores, "OK");
            }
            else
            {
                await DisplayAlert("Orden", "Orden Creada con éxito", "OK");
            }
        }
        else
        {

            await DisplayAlert("Error", API.Exceptions.ExceptionMessage, "OK");
        }


        await Navigation.PopModalAsync();

    }

    private void btnMinus_Clicked(object sender, EventArgs e)
    {
        SwipeItem item = sender as SwipeItem;
        var MyProductInfo = item.BindingContext as RespListaProductos;
        OrderList.reduceProduct(MyProductInfo.IdProducto);
        BindingContext = OrderList;
        InitializeComponent();
    }

    private void btnPlus_Clicked(object sender, EventArgs e)
    {
        SwipeItem item = sender as SwipeItem;
        var MyProductInfo = item.BindingContext as RespListaProductos;        
        OrderList.addProduct(MyProductInfo.IdProducto);
        BindingContext = OrderList;
        InitializeComponent();
    }

    private void picker_SelectedIndexChanged(object sender, EventArgs e)
    {

        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        if(selectedIndex >= 0)
        {
            mesa = picker.ItemsSource[selectedIndex] as RespListaMesas;
            OrderList.MesaSeleccionada = mesa;
            cvListaProd.IsEnabled = true;
            picker.IsEnabled = false;
            BindingContext = OrderList;
            InitializeComponent();
        }
        
    }
}