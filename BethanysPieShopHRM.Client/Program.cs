using BethanysPieShopHRM.Client;
using BethanysPieShopHRM.Client.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<IEmployeeDataService, ClientEmployeeDataService>();
await builder.Build().RunAsync();
