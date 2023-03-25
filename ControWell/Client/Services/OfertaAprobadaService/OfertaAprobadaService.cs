using Microsoft.AspNetCore.Components;

namespace ControWell.Client.Services.OfertaDiariaService
{
    public class OfertaDiariaService : IOfertaDiariaService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public OfertaDiariaService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<OfertaDiaria> OfertaDiariaProgramacionCarrotanques { get; set; } = new List<OfertaDiaria>();

        public async Task CreateOfertaDiaria(OfertaDiaria ofertaDiaria)
        {
            var result = await _http.PostAsJsonAsync("api/ofertaDiaria", ofertaDiaria);
            await SetOfertaDiaria(result);
        }

        private async Task SetOfertaDiaria(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<OfertaDiaria>>();
            OfertaDiariaProgramacionCarrotanques = response;
            _navigationManager.NavigateTo("ofertaDiarialist");
        }

        public async Task<OfertaDiaria> GetSingleOfertaDiaria(int id)
        {
            var result = await _http.GetFromJsonAsync<OfertaDiaria>($"api/ofertaDiaria/{id}");
            if (result != null)
                return result;
            throw new Exception("ofertaDiaria no encontrado");
        }    
        public async Task<OfertaDiaria> GetByPlacaOfertaDiaria(string placa)
        {
            var result = await _http.GetFromJsonAsync<OfertaDiaria>($"api/ofertaDiariaPlaca/{placa}");
            if (result != null)
                return result;
            throw new Exception("placa no encontrada");
        }

        public async Task DeleteOfertaDiaria(int id)
        {
            var result = await _http.DeleteAsync($"api/ofertaDiaria/{id}");

            await SetOfertaDiaria(result);
        }

        public async Task UpdateOfertaDiaria(OfertaDiaria ofertaDiaria)
        {
            var result = await _http.PutAsJsonAsync($"api/ofertaDiaria/{ofertaDiaria.Id}", ofertaDiaria);
            await SetOfertaDiaria(result);
        }
    }
}
