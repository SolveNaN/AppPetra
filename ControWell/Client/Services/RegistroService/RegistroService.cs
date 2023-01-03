using Microsoft.AspNetCore.Components;

namespace ControWell.Client.Services.RegistroService
{
    public class RegistroService: IRegistroService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public RegistroService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }



        public List<Registro> Registros { get; set; } = new List<Registro>();
        public List<VariableProceso> VariableProcesos { get; set; } = new List<VariableProceso>();
        public List<Pozo> Pozos { get; set; } = new List<Pozo>();


        public async Task CreateRegistro(Registro registro)
        {
            var result = await _http.PostAsJsonAsync("api/Registro", registro);
            await SetRegistro(result);
        }

        private async Task SetRegistro(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Registro>>();
            Registros = response;
            _navigationManager.NavigateTo("registrolist");
        }

        public async Task<Registro> GetSingleRegistro(int id)
        {
            var result = await _http.GetFromJsonAsync<Registro>($"api/Registro/{id}");
            if (result != null)
                return result;
            throw new Exception("El Registro fue encontrado :/");
        }


        public async Task DeleteRegistro(int id)
        {
            var result = await _http.DeleteAsync($"api/Registro/{id}");

            await SetRegistro(result);
        }

        public async Task UpdateRegistro(Registro registro)
        {
            var result = await _http.PutAsJsonAsync($"api/Registro/{registro.Id}", registro);
            await SetRegistro(result);
        }

        public async Task CreateOrUpdateRegistro(Registro registro)
        {
            var result = await _http.PutAsJsonAsync($"api/Registro/{registro.Id}", registro);
            await SetRegistro(result);
        }
    }
}
