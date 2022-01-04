using libanvl.monkey.core.Services;
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
    }
}
