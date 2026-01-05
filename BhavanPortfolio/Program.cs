using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BhavanPortfolio;
using BhavanPortfolio.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Register services as Singleton (per architecture decision)
builder.Services.AddSingleton<IThemeService, ThemeService>();
builder.Services.AddSingleton<IScrollService, ScrollService>();

await builder.Build().RunAsync();
