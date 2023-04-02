using ControWell.Shared;
using Microsoft.AspNetCore.Components;

namespace ControWell.Client.Services.GuiaService
{
    public class GuiaService : IGuiaService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public GuiaService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<Guia> Guias { get; set; } = new List<Guia>();

        public async Task CreateGuia(Guia guia)
        {
            var result = await _http.PostAsJsonAsync("api/guia", guia);
            //await SetGuia(result);
        }

        private async Task SetGuia(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Guia>>();
            Guias = response;
            _navigationManager.NavigateTo("guialist");
        }

        public async Task<Guia> GetSingleGuia(string guia)
        {
            var result = await _http.GetFromJsonAsync<Guia>($"api/guia/{guia}");
            if (result != null)
                return result;
            throw new Exception("guia no encontrado");
        }

        public async Task DeleteGuia(int id)
        {
            var result = await _http.DeleteAsync($"api/guia/{id}");
            await SetGuia(result);
        }

        public async Task UpdateGuia(Guia guia)
        {
            var result = await _http.PutAsJsonAsync($"api/guia/{guia.Id}", guia);
            await SetGuia(result);
        }
    }
}
