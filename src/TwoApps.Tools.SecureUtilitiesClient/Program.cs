using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using TwoApps.Tools.SecureUtilitiesClient;
using TwoApps.Tools.SecureUtilitiesClient.Features;
using TwoApps.Tools.SecureUtilitiesClient.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<EncodeViewModel>();
builder.Services.AddScoped<ClipboardService>();

await builder.Build().RunAsync();
