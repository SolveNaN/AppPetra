using ControWell.Shared;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Components;

namespace ControWell.Client.Services.AlarmaService
{
    public class AlarmaService : IAlarmaService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public AlarmaService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }



        public List<Alarma> Alarmas { get; set; } = new List<Alarma>();
        public List<VariableProceso> VariableProcesos { get ; set; }= new List<VariableProceso>();
        public List<Pozo> Pozos { get; set; }=new List<Pozo>();


        public async Task CreateAlarma(Alarma alarma)
        {
            var result = await _http.PostAsJsonAsync("api/Alarma", alarma);
            await SetAlarma(result);
        }

        private async Task SetAlarma(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Alarma>>();
            Alarmas = response;
            _navigationManager.NavigateTo("alarmalist");
        }

        public async Task<Alarma> GetSingleAlarma(int id)
        {
            var result = await _http.GetFromJsonAsync<Alarma>($"api/Alarma/{id}");
            if (result != null)
                return result;
            throw new Exception("La Alarma no encontrada");
        }


        public async Task DeleteAlarma(int id)
        {
            var result = await _http.DeleteAsync($"api/Alarma/{id}");

            await SetAlarma(result);
        }

        public async Task UpdateAlarma(Alarma alarma)
        {
            var result = await _http.PutAsJsonAsync($"api/Alarma/{alarma.Id}", alarma);
            await SetAlarma(result);
        }



    }
}
