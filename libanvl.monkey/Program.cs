using libanvl.monkey.components;
using libanvl.monkey.components.Shared;
using libanvl.monkey.theme;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<ThemedApp>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.RootComponents.Add<ThemeStyle>("head::after");
builder.RootComponents.Add<ThemeScript>("body::after");

var themeBase = builder.Configuration.GetRequiredSection("Monkey").GetValue<string>("Theme");

var themeAssembly = Assembly.Load(themeBase);
var themeSettingsName = themeAssembly
    .GetManifestResourceNames()
    .SingleOrDefault(n => n.EndsWith("themesettings.json"));

if (themeSettingsName is not null)
{
    var themeSettingsStream = themeAssembly.GetManifestResourceStream(themeSettingsName);
    builder.Configuration.AddJsonStream(themeSettingsStream);
}

#if DEBUG
    Console.WriteLine(builder.Configuration.GetDebugView());
#endif

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMonkeyServices(builder.Configuration.GetRequiredSection("GitHub"));

await builder.Build().RunAsync();
