using Markdig;
using Markdig.Renderers;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace libanvl.monkey.components;

/// <summary>
/// Helper extensions for the <see cref="WebAssemblyHostBuilder"/>.
/// </summary>
public static class WebAssemblyHostExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    public static void AddThemedSiteFactory(this WebAssemblyHostBuilder builder)
    {
        var themeBase = builder.Configuration.GetRequiredSection("Monkey")["Theme"];
        ArgumentNullException.ThrowIfNull(themeBase);

        var themeAssembly = Assembly.Load(themeBase);
        ArgumentNullException.ThrowIfNull(themeAssembly);

        var siteFactoryType = themeAssembly.GetImplementers<IThemedSiteFactory>().Single();
        IThemedSiteFactory? siteFactory = Activator.CreateInstance(siteFactoryType) as IThemedSiteFactory;
        ArgumentNullException.ThrowIfNull(siteFactory);

        builder.Services.AddScoped(sp => siteFactory.Initialize(sp));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    public static void AddRoutedMarkdown(this WebAssemblyHostBuilder builder)
    {
        var sourceBaseUri = builder.Configuration.GetRequiredSection("Monkey")["SourceBaseUri"];
        ArgumentNullException.ThrowIfNull(sourceBaseUri);

        builder.Services.AddScoped(_ => new MarkdownPipelineBuilder()
            .UseAdvancedExtensions()
            .UseYamlFrontMatter()
            .DisableHtml()
            .Build());

        builder.Services.AddScoped(_ => new DeserializerBuilder()
            .WithNamingConvention(UnderscoredNamingConvention.Instance)
            .Build());

        builder.Services.AddScoped<HtmlRendererFactory>(sp =>
        {
            return () => new HtmlRenderer(new StringWriter());
        });

        builder.Services.AddScoped<MarkdownParser>();

        builder.Services.AddHttpClient<SourceContentHttpClient>(
            client => client.BaseAddress = new Uri(sourceBaseUri, UriKind.Absolute));

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    public static void AddGitHubApiClient(this IServiceCollection services)
    {
        services.AddHttpClient<SourceApiHttpClient>(client => client.BaseAddress = new Uri("https://api.github.com/"));
    }
}
