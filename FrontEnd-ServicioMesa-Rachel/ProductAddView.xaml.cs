using Newtonsoft.Json;
using ProyectoProgramacion5.APIConnection;
using ProyectoProgramacion5.Entities;
using ProyectoProgramacion5.ViewModel;

namespace ProyectoProgramacion5;

public partial class ProductAddView : ContentPage
{
    string BaseURL = "https://apimesaservicioproyecto.azurewebsites.net/api";
    public ProductAddView()
	{
		this.BindingContext = new RespListaCategoriasVM();
		InitializeComponent();
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private void btnSave_Clicked(object sender, EventArgs e)
    {
        elProductoRegistro producto = new elProductoRegistro();

        RespListaCategorias SelectedCat = cbCategoria.SelectedItem as RespListaCategorias;

        if (txtNombre.Text == "") {
            DisplayAlert("Error", "Debe ingresar el nombre del producto", "OK");
            return;
        }
        if (txtPrecio.Text == "")
        {
            DisplayAlert("Error", "Debe ingresar el precio del producto", "OK");
            return;
        }
        if (cbCategoria.SelectedIndex < 0)
        {
            DisplayAlert("Error", "Debe seleccionar una categoría", "OK");
            return;
        }

        producto.elProducto.Nombre = txtNombre.Text;
        producto.elProducto.Precio = float.Parse(txtPrecio.Text);
        producto.elProducto.IdCategoria = int.Parse(SelectedCat.IdCategoria.ToString());


        string myBody = JsonConvert.SerializeObject(producto);

        APIModel API = new APIModel();
        API.Method = "POST";
        API.MYURL = BaseURL + @"/producto";
        API.Body = myBody;
        API.ContentType = "application/json";
        API.Accept = "text/plain";
        API.APICall(ref API);

        if (API.Exceptions.IsError)
        {
            DisplayAlert("Error", API.Exceptions.ExceptionMessage, "OK");
        }
        else
        {
            RespCrearProducto jsonData = JsonConvert.DeserializeObject<RespCrearProducto>(API.Exceptions.ResponseText);

            if (jsonData.result)
            {
                DisplayAlert("Registro", "Producto creado con éxito", "OK");
                txtNombre.Text = "";
                txtPrecio.Text = "";
                Navigation.PopModalAsync();
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
    }
}