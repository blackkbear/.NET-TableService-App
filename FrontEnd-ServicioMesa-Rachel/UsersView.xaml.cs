using Newtonsoft.Json;
using ProyectoProgramacion5.APIConnection;
using ProyectoProgramacion5.Entities;
using ProyectoProgramacion5.ViewModel;
namespace ProyectoProgramacion5;

public partial class UsersView : ContentPage
{
    string BaseURL = "https://apimesaservicioproyecto.azurewebsites.net/api";
    public UsersView()
	{
		this.BindingContext = new RespListaUsuariosVM();
		InitializeComponent();
	}

    private async void SwipeItem_Clicked(object sender, EventArgs e)
    {
        SwipeItem item = sender as SwipeItem;
        var MyUserInfo = item.BindingContext as RespListaUsuarios;

        bool answer = await DisplayAlert("Eliminar usuario", "Desea eliminar el usuario " + MyUserInfo.NombrePersona + " " + MyUserInfo.Apellido + "?", "SI", "No");

        if (answer == true)
        {
            APIModel API = new APIModel();
            API.MYURL = BaseURL + @"/Usuario/" + MyUserInfo.IdUsuario.ToString(); ;
            API.Method = "DELETE";      
            API.Accept = "*/*";
            API.APICall(ref API);
            if (API.Exceptions.IsError)
            {
                await DisplayAlert("Error", API.Exceptions.ExceptionMessage, "OK");
            }
            else
            {
                RespUserRegister jsonData = JsonConvert.DeserializeObject<RespUserRegister>(API.Exceptions.ResponseText);
                if (jsonData.result == true)
                {
                    await DisplayAlert("Eliminar usuario", "El usuario fue eliminado", "OK");
                    this.BindingContext = new RespListaUsuariosVM();
                    
                }
                else {
                    String errores = "";
                    foreach (string error in jsonData.listaMensajesOErrores)
                    {
                        errores = errores + error + "\n";
                    }
                    await DisplayAlert("Error!", errores, "OK");
                }
            }
        }


    }

    private async void btnRegister_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new UserRegisterView());
    }

    private async void btnCancel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    private async void SwipeItem_Clicked_1(object sender, EventArgs e)
    {
        SwipeItem item = sender as SwipeItem;
        var MyUserInfo = item.BindingContext as RespListaUsuarios;

        await Navigation.PushModalAsync(new UserEditView(MyUserInfo.IdUsuario));
    }

}