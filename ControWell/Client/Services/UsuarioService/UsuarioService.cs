using ControWell.Client.Services.UsuarioService;
using ControWell.Shared;
using Microsoft.AspNetCore.Components;
using static System.Net.WebRequestMethods;

namespace ControWell.Client.Services.PozoService
{
    public class UsuarioService : IUsuarioService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public UsuarioService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();

        public Task<Usuario> GetSigleUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public async Task GetUsuarios()
        {
            var resultado = await _http.GetFromJsonAsync<List<Usuario>>("api/Usuario");
            if (resultado != null) 
                Usuarios= resultado;
        }
    }
}