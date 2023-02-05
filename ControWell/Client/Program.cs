global using ControWell.Shared;
global using System.Net.Http.Json;
global using ControWell.Client.Services.PozoService;
global using ControWell.Client.Services.AlarmaService;
global using ControWell.Client.Services.TanqueService;
global using ControWell.Client.Services.AforoService;
global using ControWell.Client.Services.TipoMovimientoService;
global using ControWell.Client.Services.BalanceService;
using ControWell.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ControWell.Client.Services.VariableProcesoService;
using ControWell.Client.Services.AlarmaService;
using ControWell.Client.Services.RegistroService;
using CurrieTechnologies.Razor.SweetAlert2;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IPozoService, PozoService>();
builder.Services.AddScoped<IVariableProcesoService, VariableProcesoService>();
builder.Services.AddScoped<IAlarmaService, AlarmaService>();
builder.Services.AddScoped<IRegistroService, RegistroService>();
builder.Services.AddScoped<ITanqueService, TanqueService>();
builder.Services.AddScoped<IAforoService, AforoService>();
builder.Services.AddScoped<ITipoMovimientoService, TipoMovimientoService>();
builder.Services.AddScoped<IBalanceService, BalanceService>();
builder.Services.AddSweetAlert2();

//Agregado para ver excel


await builder.Build().RunAsync();
