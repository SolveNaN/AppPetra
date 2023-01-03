using Microsoft.AspNetCore.Components;

namespace ControWell.Client.Services.TanqueService
{
    public class TanqueService:ITanqueService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public TanqueService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<Tanque> Tanques { get; set; } = new List<Tanque>();

        public async Task CreateTanque(Tanque tanque)
        {
            var result = await _http.PostAsJsonAsync("api/Tanque", tanque);
            await SetTanque(result);
        }

        private async Task SetTanque(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Tanque>>();
            Tanques = response;
            _navigationManager.NavigateTo("Tanquelist");
        }

        public async Task<Tanque> GetSingleTanque(int id)
        {
            var result = await _http.GetFromJsonAsync<Tanque>($"api/Tanque/{id}");
            if (result != null)
                return result;
            throw new Exception("Tanque no encontrado");
        }


        public async Task DeleteTanque(int id)
        {
            var result = await _http.DeleteAsync($"api/Tanque/{id}");

            await SetTanque(result);
        }

        public async Task UpdateTanque(Tanque tanque)
        {
            var result = await _http.PutAsJsonAsync($"api/Tanque/{tanque.Id}", tanque);
            await SetTanque(result);
        }
    }
}
