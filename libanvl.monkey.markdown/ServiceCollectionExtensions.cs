using libanvl.monkey.Services;
using Markdig;
using Markdig.Renderers;
using Microsoft.Extensions.DependencyInjection;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace libanvl.monkey;

/// <summary>
/// Helper extensions for the <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add the services required for the <see cref="RenderedMarkdown{TMeta}"/> component.
    /// </summary>
    /// <param name="services">The app's service collection.</param>
    public static void AddRenderedMarkdownServices(this IServiceCollection services)
    {
        services.AddScoped(_ => new MarkdownPipelineBuilder()
            .UseAdvancedExtensions()
            .UseYamlFrontMatter()
            .DisableHtml()
            .Build());

        services.AddScoped(_ => new DeserializerBuilder()
            .WithNamingConvention(UnderscoredNamingConvention.Instance)
            .Build());

        services.AddScoped<HtmlRendererFactory>(sp =>
        {
            return () => new HtmlRenderer(new StringWriter());
        });

        services.AddScoped<MarkdownParser>();
    }
}
