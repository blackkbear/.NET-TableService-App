using Newtonsoft.Json;
using ProyectoProgramacion5.APIConnection;
using ProyectoProgramacion5.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacion5.ViewModel
{
    internal class RespListaUsuariosVM
    {
         string BaseURL = "https://apimesaservicioproyecto.azurewebsites.net/api";
        public List<RespListaUsuarios> listaUsuarios { get; set; } = new List<RespListaUsuarios>();

        public RespListaUsuariosVM()
        {
            RespListaUsuarios obj = new RespListaUsuarios();

            APIModel API = new APIModel();
            API.Method = "GET";
            API.MYURL = BaseURL + "/usuario";
            API.Accept = "*/*";
            API.APICall(ref API);

            if (API.Exceptions.IsError == false)
            {
                var jsonData = JsonConvert.DeserializeObject<dynamic>(API.Exceptions.ResponseText);
                if(jsonData.result == true)
                {
                    foreach (var data in jsonData.listaTodosUsuarios)
                    {
                        RespListaUsuarios Usuario = new RespListaUsuarios();
                        Usuario.IdUsuario = data.idUsuario;
                        Usuario.Correo = data.correo;
                        Usuario.PersonaID = data.Persona_ID;
                        Usuario.NombrePersona = data.NombrePersona;
                        Usuario.Apellido = data.Apellido;
                        Usuario.TipoRoll = data.TipoUsuario;
                        listaUsuarios.Add(Usuario);
                    }
                }
                

            }
        }

    }
}
