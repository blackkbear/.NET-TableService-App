using Newtonsoft.Json;
using ProyectoProgramacion5.APIConnection;
using ProyectoProgramacion5.Entities;

namespace ProyectoProgramacion5;

public partial class UserRegisterView : ContentPage
{
    string BaseURL = "https://apimesaservicioproyecto.azurewebsites.net/api";
    public UserRegisterView()
	{
        InitializeComponent();
	}

    private async void btnSave_Clicked(object sender, EventArgs e)
    {
        if (txtNombre.Text == "" || txtNombre.Text == null)
        {
            await DisplayAlert("Error", "Debe ingresar un nombre para el usuario", "OK");
            return;
        }

        if (txtApellido.Text == "" || txtApellido.Text == null)
        {
            await DisplayAlert("Error", "Debe ingresar un apellido para el usuario", "OK");
            return;
        }

        if (txtCorreo.Text == "" || txtCorreo.Text == null)
        {
            await DisplayAlert("Error", "Debe ingresar un correo para el usuario", "OK");
            return;
        }

        if (txtTelefono.Text == "" || txtTelefono.Text == null)
        {
            await DisplayAlert("Error", "Debe ingresar un teléfono para el usuario", "OK");
            return;
        }

        if (txtCedula.Text == "" || txtCedula.Text == null)
        {
            await DisplayAlert("Error", "Debe ingresar una cédula para el usuario", "OK");
            return;
        }

        if (txtPassWord.Text == "" || txtPassWord.Text == null)
        {
            await DisplayAlert("Error", "Debe ingresar una contraseña para el usuario", "OK");
            return;
        }

        elUsuarioRegistro usuario = new elUsuarioRegistro();

        usuario.elUsuario.NombrePersona = txtNombre.Text;
        usuario.elUsuario.Apellido = txtApellido.Text;
        usuario.elUsuario.Correo = txtCorreo.Text;
        usuario.elUsuario.Telefono = int .Parse(txtTelefono.Text);
        usuario.elUsuario.Cedula = int.Parse(txtCedula.Text);
        usuario.elUsuario.Contrasena = txtPassWord.Text;
        if (rbAdmin.IsChecked)
        {
            usuario.elUsuario.IdTipoUsuario = 1;
        }
        else if (rbMeseroCajero.IsChecked)
        {
            usuario.elUsuario.IdTipoUsuario = 2;
        }

        string myBody = JsonConvert.SerializeObject(usuario);

        APIModel API = new APIModel();
        API.Method = "POST";
        API.MYURL = BaseURL + @"/Usuario";
        API.Body = myBody;
        API.ContentType = "application/json";
        API.Accept = "text/plain";
        API.APICall(ref API);

        if (API.Exceptions.IsError)
        {
            await DisplayAlert("Error", API.Exceptions.ExceptionMessage, "OK");
        }
        else
        {
            await DisplayAlert("Error!", "Credenciales no validas", "OK");
            RespUserRegister jsonData = JsonConvert.DeserializeObject<RespUserRegister>(API.Exceptions.ResponseText);
            if (jsonData.result == false)
            {
                string errores = "";
                foreach (string error in jsonData.listaMensajesOErrores)
                {
                    errores = errores + error + "\n";
                }
                await DisplayAlert("Error!", errores, "OK");
            }
            else
            {
                await DisplayAlert("Registro", "Usuario creado con éxito", "OK");
                Clean();
                await Navigation.PopModalAsync();
            }            
        }

    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private void Clean()
    {
        txtNombre.Text = string.Empty;
        txtApellido.Text = string.Empty;
        txtCorreo.Text = string.Empty;
        txtTelefono.Text = string.Empty;
        txtCedula.Text = string.Empty;
        txtPassWord.Text = string.Empty;
        rbAdmin.IsChecked = true;
        rbMeseroCajero.IsChecked = false;
    }
}