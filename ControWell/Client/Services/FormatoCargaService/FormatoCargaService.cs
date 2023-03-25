using ControWell.Shared;
using Microsoft.AspNetCore.Components;

namespace ControWell.Client.Services.FormatoCargaService
{
    public class FormatoCargaService : IFormatoCargaService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public FormatoCargaService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<FormatoCarga> FormatoCarroTanquesCargados { get; set; } = new List<FormatoCarga>();

        public async Task CreateFormatoCarga(FormatoCarga formatoCarga)
        {
            var result = await _http.PostAsJsonAsync("api/formatocarga", formatoCarga);
            await SetFormatoCarga(result);
        }

        private async Task SetFormatoCarga(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<FormatoCarga>>();
            FormatoCarroTanquesCargados = response;
            _navigationManager.NavigateTo("formatocargalist");
        }

        public async Task<FormatoCarga> GetSingleFormatoCarga(int id)
        {
            var result = await _http.GetFromJsonAsync<FormatoCarga>($"api/formatocarga/{id}");
            if (result != null)
                return result;
            throw new Exception("formatoCarga no encontrado");
        }


        public async Task DeleteFormatoCarga(int id)
        {
            var result = await _http.DeleteAsync($"api/formatocarga/{id}");

            await SetFormatoCarga(result);
        }

        public async Task UpdateFormatoCarga(FormatoCarga formatoCarga)
        {
            var result = await _http.PutAsJsonAsync($"api/formatocarga/{formatoCarga.Id}", formatoCarga);
            await SetFormatoCarga(result);
        }
    }
}
