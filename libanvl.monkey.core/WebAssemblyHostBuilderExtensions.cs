using libanvl.monkey.core.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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
    public static void AddThemedSiteBuilder(this WebAssemblyHostBuilder builder)
    {
        var themeBase = builder.Configuration.GetRequiredSection("Monkey")["Theme"];
        ArgumentNullException.ThrowIfNull(themeBase);

        var themeAssembly = Assembly.Load(themeBase);
        ArgumentNullException.ThrowIfNull(themeAssembly);

        var siteFactoryType = themeAssembly.GetImplementers<IThemedSiteFactory>().Single();
        IThemedSiteFactory? siteFactory = Activator.CreateInstance(siteFactoryType) as IThemedSiteFactory;
        ArgumentNullException.ThrowIfNull(siteFactory);

        builder.Services.AddScoped(sp => siteFactory.Initialize(sp));

        builder.Services.AddScoped<MonkeyInterop>();
    }
}
