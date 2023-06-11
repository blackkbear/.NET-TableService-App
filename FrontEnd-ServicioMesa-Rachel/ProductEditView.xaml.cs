using Newtonsoft.Json;
using ProyectoProgramacion5.APIConnection;
using ProyectoProgramacion5.Entities;
using ProyectoProgramacion5.ViewModel;

namespace ProyectoProgramacion5;

public partial class ProductEditView : ContentPage
{
    string BaseURL = "https://apimesaservicioproyecto.azurewebsites.net/api";
    public ProductEditView(int idProducto)
	{
        this.BindingContext = new RespListaCategoriasVM();
        InitializeComponent();

        APIModel API = new APIModel();
        API.MYURL = BaseURL + @"/Producto/" + idProducto.ToString(); 
        API.Method = "GET";
        API.Accept = "text/plain";
        API.APICall(ref API);
        if (API.Exceptions.IsError)
        {
            DisplayAlert("Error", API.Exceptions.ExceptionMessage, "OK");
        }

        RespListaProductoCompleted producto = JsonConvert.DeserializeObject<RespListaProductoCompleted>(API.Exceptions.ResponseText);
        if (producto.result == true)
        {
            txtIDProducto.Text = producto.elProducto.IdProducto.ToString();
            txtNombre.Text = producto.elProducto.Nombre;
            txtPrecio.Text = producto.elProducto.Precio.ToString();
            cbCategoria.SelectedItem = producto.elProducto.IdCategoria;
        }
        else
        {
            DisplayAlert("Error", producto.listaMensajesOErrores, "OK");
        }
          

    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private void btnSave_Clicked(object sender, EventArgs e)
    {
        elProductoActualizar producto = new elProductoActualizar();

        RespListaCategorias SelectedCat = cbCategoria.SelectedItem as RespListaCategorias;

        if (txtNombre.Text == "")
        {
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

        producto.elProducto.IdProducto = int.Parse(txtIDProducto.Text);
        producto.elProducto.Nombre = txtNombre.Text;
        producto.elProducto.Precio = float.Parse(txtPrecio.Text);
        producto.elProducto.IdCategoria = int.Parse(SelectedCat.IdCategoria.ToString());

        string myBody = JsonConvert.SerializeObject(producto);

        APIModel API = new APIModel();
        API.Method = "PUT";
        API.MYURL = BaseURL + @"/Producto";
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
            RespActualizarProducto jsonData = JsonConvert.DeserializeObject<RespActualizarProducto>(API.Exceptions.ResponseText);

            if (jsonData.result == true)
            {
                DisplayAlert("Producto", "Producto actualizado con éxito", "OK");
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
                DisplayAlert("Error!", errores, "OK");
            }  
        }
    }
}