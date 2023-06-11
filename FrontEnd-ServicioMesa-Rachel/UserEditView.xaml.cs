using Newtonsoft.Json;
using ProyectoProgramacion5.APIConnection;
using ProyectoProgramacion5.Entities;
using ProyectoProgramacion5.ViewModel;

namespace ProyectoProgramacion5;

public partial class UserEditView : ContentPage
{
    string BaseURL = "https://apimesaservicioproyecto.azurewebsites.net/api";
    public UserEditView(int UserID)
	{
		InitializeComponent();

        APIModel API = new APIModel();
        API.MYURL = BaseURL + @"/usuario/" + UserID;
        API.Method = "GET";
        API.Accept = "text/plain";
        API.APICall(ref API);
        if (API.Exceptions.IsError)
        {
            DisplayAlert("Error", API.Exceptions.ExceptionMessage, "OK");
        }

        RespListaUsuarioCompleted Response = JsonConvert.DeserializeObject<RespListaUsuarioCompleted>(API.Exceptions.ResponseText);
        if (Response.result == true)
        {
            txtUserID.Text = Response.elusuario.IdUsuario.ToString();
            txtNombre.Text = Response.elusuario.NombrePersona;
            txtApellido.Text = Response.elusuario.Apellido;
            txtCorreo.Text = Response.elusuario.Correo;
            txtTelefono.Text = Response.elusuario.Telefono;
            txtCedula.Text = Response.elusuario.Cedula;
            txtPassWord.Text = "";
            if (Response.elusuario.IdTipoUsuario == 1)
            {
                rbAdmin.IsChecked = true;
            }
            else
            {
                rbMeseroCajero.IsChecked = true;
            }
        }
        else
        {
            DisplayAlert("Error", Response.listaMensajesOErrores, "OK");
        }
        
    }

    private async void btnSave_Clicked(object sender, EventArgs e)
    {
        if (txtNombre.Text == "" || txtNombre.Text == null)
        {
            await DisplayAlert("Error", "Debe ingresar el nombre de usuario", "OK");
            return;
        }

        if (txtApellido.Text == "" || txtApellido.Text == null)
        {
            await DisplayAlert("Error", "Debe ingresar el apellido del usuario", "OK");
            return;
        }

        if (txtCorreo.Text == "" || txtCorreo.Text == null)
        {
            await DisplayAlert("Error", "Debe ingresar el correo del usuario", "OK");
            return;
        }

        if (txtTelefono.Text == "" || txtTelefono.Text == null)
        {
            await DisplayAlert("Error", "Debe ingresar el teléfono del usuario", "OK");
            return;
        }

        if (txtCedula.Text == "" || txtCedula.Text == null)
        {
            await DisplayAlert("Error", "Debe ingresar la cédula del usuario", "OK");
            return;
        }

        if (txtPassWord.Text == "" || txtPassWord.Text == null)
        {
            await DisplayAlert("Error", "Debe ingresar la contraseña del usuario", "OK");
            return;
        }

        elUsuarioActualizar usuario = new elUsuarioActualizar();

        usuario.elUsuario.IdUsuario = int.Parse(txtUserID.Text);
        usuario.elUsuario.NombrePersona = txtNombre.Text;
        usuario.elUsuario.Apellido = txtApellido.Text;
        usuario.elUsuario.Correo = txtCorreo.Text;
        usuario.elUsuario.Telefono = int.Parse(txtTelefono.Text);
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
        API.Method = "PUT";
        API.MYURL = BaseURL + @"/Usuario";
        API.Body = myBody;
        API.ContentType = "application/json";
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
                await DisplayAlert("Actualizar Usuario", "Usuario actualizado con éxito", "OK");
                await Navigation.PopModalAsync(true);
            }
            else
            {
                
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