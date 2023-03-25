using ControWell.Shared;
using Microsoft.AspNetCore.Components;

namespace ControWell.Client.Services.SelloService
{
    public class SelloService : ISelloService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public SelloService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<Sello> Sellos { get; set; } = new List<Sello>();

        public async Task CreateSello(Sello sello)
        {
            var result = await _http.PostAsJsonAsync("api/sello", sello);
            //await SetGuia(result);
        }

        private async Task SetSello(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Sello>>();
            Sellos = response;
            _navigationManager.NavigateTo("sellolist");
        }

        public async Task<Sello> GetSingleSello(string sello)
        {
            var result = await _http.GetFromJsonAsync<Sello>($"api/sello/{sello}");
            if (result != null)
                return result;
            throw new Exception("Sello no encontrado");
        }

        public async Task DeleteSello(int id)
        {
            var result = await _http.DeleteAsync($"api/sello/{id}");

            //await SetSello(result);
        }

        public async Task UpdateSello(Sello sello)
        {
            var result = await _http.PutAsJsonAsync($"api/sello/{sello.Id}", sello);
            await SetSello(result);
        }
    }
}
