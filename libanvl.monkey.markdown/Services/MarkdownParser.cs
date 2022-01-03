using Markdig;
using Markdig.Extensions.Yaml;
using Markdig.Renderers;
using Markdig.Syntax;
using Microsoft.AspNetCore.Components;
using YamlDotNet.Serialization;

namespace libanvl.monkey.Services;

/// <summary>
/// A factory for creating <see cref="HtmlRenderer"/> instances.
/// </summary>
public delegate HtmlRenderer HtmlRendererFactory();

/// <summary>
/// Parses markdown.
/// </summary>
public class MarkdownParser
{
    private readonly MarkdownPipeline _pipeline;
    private readonly HtmlRendererFactory _rendererFactory;
    private readonly IDeserializer _deserializer;

    /// <summary>
    /// Initializes an instance of <see cref="MarkdownParser"/>.
    /// </summary>
    /// <param name="pipeline"></param>
    /// <param name="renderer"></param>
    /// <param name="deserializer">Yaml Front Matter Deserializer</param>
    public MarkdownParser(MarkdownPipeline pipeline, HtmlRendererFactory renderer, IDeserializer deserializer)
    {
        ArgumentNullException.ThrowIfNull(pipeline);
        ArgumentNullException.ThrowIfNull(renderer);
        ArgumentNullException.ThrowIfNull(deserializer);

        _pipeline = pipeline;
        _rendererFactory = renderer;
        _deserializer = deserializer;
    }

    /// <summary>
    /// Parses a string of markdown with optional yaml front matter of type <typeparamref name="TMeta"/>.
    /// </summary>
    /// <typeparam name="TMeta">The type to deserialize the yaml into.</typeparam>
    public async Task<MarkdownParserResult<TMeta>> ParseAsync<TMeta>(string content) where TMeta : new()
    {
        var renderer = _rendererFactory();
        _pipeline.Setup(renderer);

        var document = Markdown.Parse(content, _pipeline);

        // extract the front matter from markdown document
        var yamlBlock = document.Descendants<YamlFrontMatterBlock>().FirstOrDefault();

        TMeta meta = yamlBlock is not null
            ? _deserializer.Deserialize<TMeta>(yamlBlock.Lines.ToString())
            : new();

        // render the markdown content as html
        renderer.Render(document);
        await renderer.Writer.FlushAsync();

        return new MarkdownParserResult<TMeta>(meta, new MarkupString(renderer.Writer.ToString() ?? string.Empty));
    }
}

/// <summary>
/// The result of a <see cref="MarkdownParser.ParseAsync{TMeta}(string)" />.
/// </summary>
/// <typeparam name="TMeta">The metadata type.</typeparam>
/// <param name="Meta"></param>
/// <param name="Markup">The rendered markdown.</param>
public record struct MarkdownParserResult<TMeta>(TMeta Meta, MarkupString Markup) where TMeta : new();
