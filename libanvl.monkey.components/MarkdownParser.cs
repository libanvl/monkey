using Markdig;
using Markdig.Extensions.Yaml;
using Markdig.Renderers;
using Markdig.Syntax;
using Microsoft.AspNetCore.Components;
using YamlDotNet.Serialization;

namespace libanvl.monkey.components;

public delegate HtmlRenderer HtmlRendererFactory();

public class MarkdownParser
{
    private readonly MarkdownPipeline _pipeline;
    private readonly HtmlRendererFactory _rendererFactory;
    private readonly IDeserializer _deserializer;

    public MarkdownParser(MarkdownPipeline pipeline, HtmlRendererFactory renderer, IDeserializer deserializer)
    {
        ArgumentNullException.ThrowIfNull(pipeline);
        ArgumentNullException.ThrowIfNull(renderer);
        ArgumentNullException.ThrowIfNull(deserializer);

        _pipeline = pipeline;
        _rendererFactory = renderer;
        _deserializer = deserializer;
    }

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

public record struct MarkdownParserResult<TMeta>(TMeta Meta, MarkupString Markup) where TMeta : new();
