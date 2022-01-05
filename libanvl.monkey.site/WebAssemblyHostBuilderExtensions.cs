using libanvl.monkey.Services;
using libanvl.monkey.site;
using libanvl.monkey.theme;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace libanvl.monkey;

/// <summary>
/// Helper extensions for the <see cref="WebAssemblyHostBuilder"/>.
/// </summary>
public static class WebAssemblyHostBuilderExtensions
{
    /// <summary>
    /// Adds the services to bind to a Monkey Theme Package.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="site">the theme site factory instance</param>
    public static void AddThemedSiteBuilder(this WebAssemblyHostBuilder builder, IThemedSiteBuilder site)
    {
        builder.Services.AddScoped(sp => site.Initialize(sp));
        builder.Services.AddScoped<MonkeyInterop>();
        builder.Services.AddScoped<IComponentActivator, MonkeyComponentActivator>();

        builder.Services.AddTransient<MonkeyMainLayout>();
        builder.Services.AddTransient<MonkeySingleLayout>();
        builder.Services.AddTransient<MonkeyPage>();
        builder.Services.AddTransient<MonkeyActionsBlock>();
    }

}
