using ControWell.Shared;
using Microsoft.AspNetCore.Components;

namespace ControWell.Client.Services.CarroTanqueService
{
    public class CarroTanqueService : ICarroTanqueService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public CarroTanqueService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<CarroTanque> CarroTanques { get; set; } = new List<CarroTanque>();

        public async Task CreateCarroTanque(CarroTanque carroTanque)
        {
            var result = await _http.PostAsJsonAsync("api/carrotanque", carroTanque);
            await SetCarroTanque(result);
        }

        private async Task SetCarroTanque(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<CarroTanque>>();
            CarroTanques = response;
            _navigationManager.NavigateTo("carrotanquelist");
        }

        public async Task<CarroTanque> GetSingleCarroTanque(int id)
        {
            var result = await _http.GetFromJsonAsync<CarroTanque>($"api/carrotanque/{id}");
            if (result != null)
                return result;
            throw new Exception("carroTanque no encontrado");
        }


        public async Task DeleteCarroTanque(int id)
        {
            var result = await _http.DeleteAsync($"api/carrotanque/{id}");

            await SetCarroTanque(result);
        }

        public async Task UpdateCarroTanque(CarroTanque carroTanque)
        {
            var result = await _http.PutAsJsonAsync($"api/carrotanque/{carroTanque.Id}", carroTanque);
            await SetCarroTanque(result);
        }
    }
}
