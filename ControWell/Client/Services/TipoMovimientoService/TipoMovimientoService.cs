using Microsoft.AspNetCore.Components;

namespace ControWell.Client.Services.TipoMovimientoService
{
    public class TipoMovimientoService:ITipoMovimientoService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public TipoMovimientoService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<TipoMovimiento> TipoMovimientos { get; set; } = new List<TipoMovimiento>();

        public async Task CreateTipoMovimiento(TipoMovimiento movimiento)
        {
            var result = await _http.PostAsJsonAsync("api/TipoMovimiento", movimiento);
            await SetTipoMovimiento(result);
        }

        private async Task SetTipoMovimiento(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<TipoMovimiento>>();
            TipoMovimientos = response;
            _navigationManager.NavigateTo("TipoMovimientolist");
        }

        public async Task<TipoMovimiento> GetSingleTipoMovimiento(int id)
        {
            var result = await _http.GetFromJsonAsync<TipoMovimiento>($"api/TipoMovimiento/{id}");
            if (result != null)
                return result;
            throw new Exception("TipoMovimiento no encontrado");
        }


        public async Task DeleteTipoMovimiento(int id)
        {
            var result = await _http.DeleteAsync($"api/TipoMovimiento/{id}");

            await SetTipoMovimiento(result);
        }

        public async Task UpdateTipoMovimiento(TipoMovimiento movimiento)
        {
            var result = await _http.PutAsJsonAsync($"api/TipoMovimiento/{movimiento.Id}", movimiento);
            await SetTipoMovimiento(result);
        }
    }
}
