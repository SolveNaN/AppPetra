﻿using ControWell.Shared;
using Microsoft.AspNetCore.Components;

namespace ControWell.Client.Services.OperarioService
{
    public class OperarioService : IOperarioService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public OperarioService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<Operario> Operarios { get; set; } = new List<Operario>();

        public async Task CreateOperario(Operario Operario)
        {
            var result = await _http.PostAsJsonAsync("api/Operario", Operario);
            await SetOperario(result);
        }

        private async Task SetOperario(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Operario>>();
            Operarios = response;
            _navigationManager.NavigateTo("Operariolist");
        }

        public async Task<Operario> GetSingleOperario(int id)
        {
            var result = await _http.GetFromJsonAsync<Operario>($"api/Operario/{id}");
            if (result != null)
                return result;
            throw new Exception("Operario no encontrado");
        }


        public async Task DeleteOperario(int id)
        {
            var result = await _http.DeleteAsync($"api/Operario/{id}");

            await SetOperario(result);
        }

        public async Task UpdateOperario(Operario Operario)
        {
            var result = await _http.PutAsJsonAsync($"api/Operario/{Operario.Id}", Operario);
            await SetOperario(result);
        }
    }
}
