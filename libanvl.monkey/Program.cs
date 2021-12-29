using libanvl.monkey;
using libanvl.monkey.Clients;
using libanvl.monkey.components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddMonkeyServices(builder.Configuration.GetRequiredSection("GitHub"));

builder.Services.AddHttpClient<SourceApiHttpClient>(client => client.BaseAddress = new Uri("https://api.github.com/"));

await builder.Build().RunAsync();
