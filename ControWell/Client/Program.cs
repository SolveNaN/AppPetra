global using ControWell.Shared;
global using System.Net.Http.Json;
global using ControWell.Client.Services.PozoService;
global using ControWell.Client.Services.UsuarioService;
global using ControWell.Client.Services.SuperHeroService;
global using ControWell.Client.Services.AlarmaService;
global using ControWell.Client.Services.TanqueService;
using ControWell.Client;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ControWell.Client.Services.SuperHeroService;
using ControWell.Client.Services.VariableProcesoService;
using ControWell.Client.Services.AlarmaService;
using ControWell.Client.Services.RegistroService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IPozoService, PozoService>();
builder.Services.AddScoped<ISuperHeroService, SuperHeroService>();
builder.Services.AddScoped<IVariableProcesoService, VariableProcesoService>();
builder.Services.AddScoped<IAlarmaService, AlarmaService>();
builder.Services.AddScoped<IRegistroService, RegistroService>();
builder.Services.AddScoped<ITanqueService, TanqueService>();

//Agregado para ver excel


await builder.Build().RunAsync();
