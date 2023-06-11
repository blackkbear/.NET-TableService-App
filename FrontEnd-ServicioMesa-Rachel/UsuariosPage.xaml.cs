using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using ProyectoProgramacion5.Entities;

namespace ProyectoProgramacion5.adminViewModel;

public partial class UsuariosPage : ContentPage
{
    private readonly HttpClient _httpClient;
    public List<RespListaUsuario> Usuarios { get; set; }

    public UsuariosPage()
    {
        //InitializeComponent();
        _httpClient = new HttpClient();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var response = await _httpClient.GetAsync("https://apimesaservicioproyecto.azurewebsites.net/api/Usuario");
        response.EnsureSuccessStatusCode();
        var responseStream = await response.Content.ReadAsStreamAsync();
        Usuarios = await JsonSerializer.DeserializeAsync<List<RespListaUsuario>>(responseStream);
        BindingContext = this;
    }
}