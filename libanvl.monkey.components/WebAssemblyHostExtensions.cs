using Markdig;
using Markdig.Prism;
using Markdig.Renderers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace libanvl.monkey.components;

public static class WebAssemblyHostExtensions
{
    public static void AddMonkeyServices(this IServiceCollection services, IConfigurationSection configuration)
    {
        services.AddScoped(_ => new MarkdownPipelineBuilder()
            .UseAdvancedExtensions()
            .UseYamlFrontMatter()
            .UsePrism()
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

        var rawContentUri = string.Format(
            "https://raw.githubusercontent.com/{0}/{1}/{2}/",
            configuration["Owner"],
            configuration["Repo"],
            configuration["Branch"]);

        services.AddHttpClient<SourceContentHttpClient>(client => client.BaseAddress = new Uri(rawContentUri));
    }
}
