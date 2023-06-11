using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoProgramacion5;
using System.Threading.Tasks;

namespace ProyectoProgramacion5
{
    public class ApiService
    {
        private const string BaseUrl = "https://apimesaservicioproyecto.azurewebsites.net/api/";

        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Usuario>> GetUsuarios()
        {
            var response = await _httpClient.GetAsync("https://apimesaservicioproyecto.azurewebsites.net/api/Usuario");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error getting usuarios");
            }

            var content = await response.Content.ReadAsStringAsync();
            var usuarios = JsonConvert.DeserializeObject<List<Usuario>>(content);

            return usuarios;
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            var response = await _httpClient.GetAsync($"https://apimesaservicioproyecto.azurewebsites.net/api/Usuario/{id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error getting usuario");
            }

            var content = await response.Content.ReadAsStringAsync();
            var usuario = JsonConvert.DeserializeObject<Usuario>(content);

            return usuario;
        }
    }
}

