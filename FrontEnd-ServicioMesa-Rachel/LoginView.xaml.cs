using Newtonsoft.Json;
using ProyectoProgramacion5.APIConnection;
using ProyectoProgramacion5.Entities;

namespace ProyectoProgramacion5;

public partial class LoginView : ContentPage
{
    string BaseURL = "https://apimesaservicioproyecto.azurewebsites.net/api";
    public LoginView()
	{
		InitializeComponent();
	}

    private async void btnLogin_Clicked(object sender, EventArgs e)
    {
        if(txtUserName.Text == "" || txtUserName.Text == null)
        {
            await DisplayAlert("Error", "El nombre de usuario es requerido", "OK");
            return;
        }

        if (txtPassWord.Text == "" || txtPassWord.Text == null)
        {
            await DisplayAlert("Error", "La contraseña es requerida", "OK");
            return;
        }

        ReqElUserLogin login = new ReqElUserLogin();
        login.elUserLogin.Correo = txtUserName.Text;
        login.elUserLogin.Contrasena =  txtPassWord.Text;

        string myBody = JsonConvert.SerializeObject(login);

        APIModel API = new APIModel();
        API.Method = "POST";
        API.MYURL = BaseURL + "/Login";
        API.Accept = "*/*";
        API.ContentType = "application/json";
        API.Body = myBody;
        API.APICall(ref API);

        if (API.Exceptions.IsError)
        {
            await DisplayAlert("Error", API.Exceptions.ExceptionMessage, "OK");
        }
        else
        {
            RespLogin Response = JsonConvert.DeserializeObject<RespLogin>(API.Exceptions.ResponseText);
            if (Response.Result == true)
            {
                await DisplayAlert("Bienvenido!", "Ha ingresado exitosamente!", "OK");
                if (Response.EsAdmin)
                {
                    await Navigation.PushModalAsync(new adminMainPage(Response));
                }
                else
                {
                    await Navigation.PushModalAsync(new MainPage(Response));
                }
            }
            else
            {
                await DisplayAlert("Error!", "Credenciales no validas", "OK");
                String errores = "";
                foreach (string error in Response.ListaMensajesOErrores)
                {
                    errores = errores + error + "\n";
                }
                await DisplayAlert("Error!", errores, "OK");
            }
        }

        
    }
}