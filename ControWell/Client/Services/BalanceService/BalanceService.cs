using Microsoft.AspNetCore.Components;

namespace ControWell.Client.Services.BalanceService
{
    public class BalanceService:IBalanceService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public BalanceService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }



        public List<Balance> Balances { get; set; } = new List<Balance>();
        public List<Tanque> Tanques { get; set; } = new List<Tanque>();
        public List<Pozo> Pozos { get; set; } = new List<Pozo>();
        public List<TipoMovimiento> TipoMovimientos { get; set; } = new List<TipoMovimiento>();


        public async Task CreateBalance(Balance miBalance)
        {
            var result = await _http.PostAsJsonAsync("api/Balance", miBalance);
            await SetBalance(result);
        }

        private async Task SetBalance(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Balance>>();
            Balances = response;
            _navigationManager.NavigateTo("/");
        }

        public async Task<Balance> GetSingleBalance(int id)
        {
            var result = await _http.GetFromJsonAsync<Balance>($"api/Balance/{id}");
            if (result != null)
                return result;
            throw new Exception("El Balance fue encontrado :/");
        }


        public async Task DeleteBalance(int id)
        {
            var result = await _http.DeleteAsync($"api/Balance/{id}");

            await SetBalance(result);
        }

        public async Task UpdateBalance(Balance miBalance)
        {
            var result = await _http.PutAsJsonAsync($"api/Balance/{miBalance.Id}", miBalance);
            await SetBalance(result);
        }


    }
}
