using Newtonsoft.Json;
using ProyectoProgramacion5.APIConnection;
using ProyectoProgramacion5.Entities;
using ProyectoProgramacion5.ViewModel;

namespace ProyectoProgramacion5;

public partial class ProductsView : ContentPage
{
    string BaseURL = "https://apimesaservicioproyecto.azurewebsites.net/api/Producto";
    public ProductsView()
	{
        this.BindingContext = new RespListaProductosVM();
		InitializeComponent();

    }

    private async void btnEdit_Clicked(object sender, EventArgs e)
    {
        SwipeItem item = sender as SwipeItem;
        var MyProductInfo = item.BindingContext as RespListaProductos;
        int ProdId = MyProductInfo.IdProducto;
        await Navigation.PushModalAsync(new ProductEditView(ProdId));
    }

    private async void btnDelete_Clicked(object sender, EventArgs e)
    {
        SwipeItem item = sender as SwipeItem;
        var MyProductInfo = item.BindingContext as RespListaProductos;

        bool answer = await DisplayAlert("Eliminar Producto", "Desea eliminar el Producto " + MyProductInfo.Nombre + "?", "SI", "No");

        if (answer == true)
        {
            APIModel API = new APIModel();
            API.MYURL = BaseURL + @"/Producto";
            API.Method = "DELETE";
            API.Key = "idProducto";
            API.Value = MyProductInfo.IdProducto.ToString();
            API.AddParameter(API);
            API.Accept = "*/*";
            API.APICall(ref API);
            if (API.Exceptions.IsError)
            {
                await DisplayAlert("Error", API.Exceptions.ExceptionMessage, "OK");
            }
            else
            {
                RespCrearProducto jsonData = JsonConvert.DeserializeObject<RespCrearProducto>(API.Exceptions.ResponseText);
                if (jsonData.result == true)
                {
                    await DisplayAlert("Eliminar producto", "El producto fue eliminado", "OK");
                    this.BindingContext = new RespListaProductosVM();
                    InitializeComponent();
                }
                else
                {
                    String errores = "";
                    foreach (string error in jsonData.listaMensajesOErrores)
                    {
                        errores = errores + error + "\n";
                    }
                    await DisplayAlert("Eliminar producto", errores, "OK");
                }
            }
        }
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private void btnRegister_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new ProductAddView());
    }
}