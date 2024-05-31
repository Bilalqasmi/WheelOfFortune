using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorApp.Client;
using BlazorApp.Client.Services.Contracts;
using BlazorApp.Client.Services.Implementations;
using BlazorApp.Client.Helpers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("SystemApiClient", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["API_Prefix"]
    ?? builder.HostEnvironment.BaseAddress);
});

builder.Services.AddScoped<GetHttpClient>();
builder.Services.AddScoped<ICodeValidationService, CodeValidationService>();

await builder.Build().RunAsync();
