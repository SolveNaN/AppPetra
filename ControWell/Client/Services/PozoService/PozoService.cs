using ControWell.Shared;
using Microsoft.AspNetCore.Components;

namespace ControWell.Client.Services.PozoService
{
    public class PozoService : IPozoService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public PozoService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<Pozo> Pozos { get; set; } = new List<Pozo>();

        public async Task CreatePozo(Pozo pozo)
        {
            var result = await _http.PostAsJsonAsync("api/Pozo", pozo);
            await SetPozo(result);
        }

        private async Task SetPozo(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Pozo>>();
            Pozos = response;
            _navigationManager.NavigateTo("Pozolist");
        }

        public async Task<Pozo> GetSinglePozo(int id)
        {
            var result = await _http.GetFromJsonAsync<Pozo>($"api/Pozo/{id}");
            if (result != null)
                return result;
            throw new Exception("pozo no encontrado");
        }


        public async Task DeletePozo(int id)
        {
            var result = await _http.DeleteAsync($"api/Pozo/{id}");

            await SetPozo(result);
        }

        public async Task UpdatePozo(Pozo pozo)
        {
            var result = await _http.PutAsJsonAsync($"api/Pozo/{pozo.Id}", pozo);
            await SetPozo(result);
        }
    }
}
