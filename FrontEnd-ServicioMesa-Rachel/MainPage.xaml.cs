using ProyectoProgramacion5.Entities;
using ProyectoProgramacion5.ViewModel;

namespace ProyectoProgramacion5;


public partial class MainPage : FlyoutPage
{
    int IdUsuario;
    RespLogin MyLogin;

    public MainPage(RespLogin login)
	{
        MyLogin = login;
        this.BindingContext = new RespListaOrdenesVM();
        InitializeComponent();
        IdUsuario = login.IdUsuario;
        lblActiveUser.Text = login.NombrePersona + " " + login.Apellido;
        if(login.IdTipoUsuario == 2 )
        {
            btnUsuarios.IsEnabled = false;
            btnProductos.IsEnabled = false;
        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new UsersView());
    }

    private async void btnProductos_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new ProductsView());
    }

    private async void btnNuevaOrden_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new CreateOrderView(MyLogin));
    }

    private void btnPagar_Clicked(object sender, EventArgs e)
    {
        SwipeItem item = sender as SwipeItem;
        var MyOrderInfo = item.BindingContext as RespListaOrdenes;
        Navigation.PushModalAsync(new PagarOrdenView(MyLogin, MyOrderInfo.IdOrden));
    }

    private void btnEdit_Clicked(object sender, EventArgs e)
    {
        SwipeItem item = sender as SwipeItem;
        var MyOrderInfo = item.BindingContext as RespListaOrdenes;
        Navigation.PushModalAsync(new EditOrdernView(MyLogin, MyOrderInfo.IdOrden));
    }

    private void btnAbout_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Programación 5 - ULatina - Abril 2023", "Vilma Chavarría Colindres/Rachel Montero Branford /Emanuel Quesada Campos", "OK");
    }
}

