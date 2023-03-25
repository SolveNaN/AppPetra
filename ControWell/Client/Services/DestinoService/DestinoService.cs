using ControWell.Shared;
using Microsoft.AspNetCore.Components;

namespace ControWell.Client.Services.DestinoService
{
    public class DestinoService : IDestinoService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public DestinoService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<Destino> Destinos { get; set; } = new List<Destino>();

        public async Task CreateDestino(Destino Destino)
        {
            var result = await _http.PostAsJsonAsync("api/Destino", Destino);
            await SetDestino(result);
        }

        private async Task SetDestino(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Destino>>();
            Destinos = response;
            _navigationManager.NavigateTo("Destinolist");
        }

        public async Task<Destino> GetSingleDestino(int id)
        {
            var result = await _http.GetFromJsonAsync<Destino>($"api/Destino/{id}");
            if (result != null)
                return result;
            throw new Exception("Destino no encontrado");
        }


        public async Task DeleteDestino(int id)
        {
            var result = await _http.DeleteAsync($"api/Destino/{id}");

            await SetDestino(result);
        }

        public async Task UpdateDestino(Destino Destino)
        {
            var result = await _http.PutAsJsonAsync($"api/Destino/{Destino.Id}", Destino);
            await SetDestino(result);
        }
    }
}
