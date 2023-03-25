global using ControWell.Shared;
global using System.Net.Http.Json;
global using ControWell.Client.Services.PozoService;
global using ControWell.Client.Services.AlarmaService;
global using ControWell.Client.Services.TanqueService;
global using ControWell.Client.Services.AforoService;
global using ControWell.Client.Services.TipoMovimientoService;
global using ControWell.Client.Services.BalanceService;
global using ControWell.Client.Services.GuiaService;
global using ControWell.Client.Services.SelloService;
global using ControWell.Client.Services.OfertaDiariaService;
global using ControWell.Client.Services.CarroTanqueService;
using ControWell.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ControWell.Client.Services.VariableProcesoService;
using ControWell.Client.Services.AlarmaService;
using ControWell.Client.Services.RegistroService;
using CurrieTechnologies.Razor.SweetAlert2;
using MatBlazor;
using static Org.BouncyCastle.Math.EC.ECCurve;
using ControWell.Client.Services.FormatoCargaService;

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
builder.Services.AddScoped<IGuiaService, GuiaService>();
builder.Services.AddScoped<ISelloService, SelloService>();
builder.Services.AddScoped<IFormatoCargaService, FormatoCargaService>();
builder.Services.AddScoped<IOfertaDiariaService, OfertaDiariaService>();
builder.Services.AddScoped<ICarroTanqueService,CarroTanqueService>();
builder.Services.AddSweetAlert2();
builder.Services.AddMatBlazor();


builder.Services.AddMatToaster(config =>
{
    config.Position = MatToastPosition.TopRight;
    config.PreventDuplicates = true;
    config.NewestOnTop = true;
    config.ShowCloseButton = true;
    config.MaximumOpacity = 95;
    config.VisibleStateDuration = 500;
});

//Agregado para ver excel


await builder.Build().RunAsync();
