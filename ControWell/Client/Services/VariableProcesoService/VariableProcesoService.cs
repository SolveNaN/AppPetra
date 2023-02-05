using Microsoft.AspNetCore.Components;
using static System.Net.WebRequestMethods;

namespace ControWell.Client.Services.VariableProcesoService
{
    public class VariableProcesoService : IVariableProcesoService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public VariableProcesoService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<VariableProceso> Variables { get; set; } = new List<VariableProceso>();
        
        public async Task CreateVariableProceso(VariableProceso variable)
        {
            var result = await _http.PostAsJsonAsync("api/VariableProceso", variable);
            await SetVariable(result);
        }

        private async Task SetVariable(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<VariableProceso>>();
            Variables = response;
            _navigationManager.NavigateTo("variableprocesolist");
        }

        public async Task<VariableProceso> GetSingleVariableProceso(int id)
        {
            var result = await _http.GetFromJsonAsync<VariableProceso>($"api/VariableProceso/{id}");
            if (result != null)
                return result;
            throw new Exception("Variable no encontrada");
        }


        public async Task DeleteVariableProceso(int id)
        {
            var result = await _http.DeleteAsync($"api/VariableProceso/{id}");

            await SetVariable(result);
        }

        public async Task UpdateVariableProceso(VariableProceso variable)
        {
            var result = await _http.PutAsJsonAsync($"api/VariableProceso/{variable.Id}", variable);
            await SetVariable(result);
        }


    }
}
