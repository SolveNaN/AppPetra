using Microsoft.AspNetCore.Components;

namespace ControWell.Client.Services.AforoService
{
    public class AforoService:IAforoService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public AforoService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }



        public List<AforoTK> Aforos { get; set; } = new List<AforoTK>();
        public List<Tanque> Tanques { get; set; } = new List<Tanque>();
       


        public async Task CreateAforo(AforoTK aforo)
        {
            var result = await _http.PostAsJsonAsync("api/Aforo", aforo);
            await SetAforo(result);
        }

        private async Task SetAforo(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<AforoTK>>();
            Aforos = response;
            
        }

        public async Task<AforoTK> GetSingleAforo(int id)
        {
            var result = await _http.GetFromJsonAsync<AforoTK>($"api/Aforo/{id}");
            if (result != null)
                return result;
            throw new Exception("El aforo no se encuentra");
        }


        public async Task DeleteAforo(int id)
        {
            var result = await _http.DeleteAsync($"api/Aforo/{id}");

            await SetAforo(result);
        }

        public async Task UpdateAforo(AforoTK aforo)
        {
            var result = await _http.PutAsJsonAsync($"api/Aforo/{aforo.Id}", aforo);
            await SetAforo(result);
        }

    }
}
