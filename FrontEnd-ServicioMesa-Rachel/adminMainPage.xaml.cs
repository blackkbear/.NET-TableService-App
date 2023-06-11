using ProyectoProgramacion5.adminViewModel;
using ProyectoProgramacion5.Entities;
using ProyectoProgramacion5.ViewModel;
namespace ProyectoProgramacion5;

public partial class adminMainPage : ContentPage
{
    int IdUsuario;
    RespLogin MyLogin;

    private RespLogin _loggedInUser;

    public string LoggedInUserName => _loggedInUser == null ? string.Empty : $"{_loggedInUser.NombrePersona} {_loggedInUser.Apellido}";


    public adminMainPage(RespLogin loggedInUser)
    {
        MyLogin = loggedInUser ;
        InitializeComponent();
        _loggedInUser = loggedInUser;
        this.BindingContext = this;
        IdUsuario = loggedInUser.IdUsuario;
        lblActiveAdmin.Text = loggedInUser.NombrePersona + " " + loggedInUser.Apellido;
    }

    private async void OnUsuariosClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new UsersView());
    }

    private async void OnProductosClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new ProductsView());
    }
    //falta
    private async void OnCategoriasClicked(object sender, EventArgs e)
    {
        //await Navigation.PushModalAsync(new CategoriaView());
    }

    private async void OnOrdenesClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new CreateOrderView(MyLogin));
    }

    //falta
    private async void OnMesasClicked(object sender, EventArgs e)
    {
        //await Navigation.PushModalAsync(new MesasView());
    }

    //falta
    private async void OnFacturasClicked(object sender, EventArgs e)
    {
        //await Navigation.PushModalAsync(new FacturaView());
    }
    
    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        MyLogin = null;
        _loggedInUser = null;
        IdUsuario = 0;

        // Navigate back to the LoginView
        await Navigation.PushModalAsync(new LoginView());
        await DisplayAlert("Has cerrado sesión", "Inicie sesión de nuevo para empezar", "OK");
    }

    private async void OnInicioClicked(object sender, EventArgs e)
    {
        // Navigate back to the admin main page
        await Navigation.PopAsync();
    }
}