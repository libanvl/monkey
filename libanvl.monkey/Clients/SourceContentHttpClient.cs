using Markdig;
using Markdig.Extensions.Yaml;
using Markdig.Renderers;
using Markdig.Syntax;
using Microsoft.AspNetCore.Components;
using YamlDotNet.Serialization;

namespace libanvl.monkey.Clients;

public class SourceContentHttpClient
{
    private readonly HttpClient _http;
    private readonly MarkdownPipeline _pipeline;
    private readonly HtmlRenderer _renderer;
    private readonly IDeserializer _deserializer;

    public SourceContentHttpClient(
        HttpClient http,
        MarkdownPipeline pipeline,
        HtmlRenderer renderer,
        IDeserializer deserializer)
    {
        _http = http;
        _pipeline = pipeline;
        _renderer = renderer;
        _deserializer = deserializer;
    }

    public async Task<(TFrontMatter Matter, MarkupString Markup)> GetPageAsync<TFrontMatter>(string route, CancellationToken cancellationToken = default) where TFrontMatter : new()
    {
        try
        {
            var content = await _http.GetStringAsync($"page/{route}.md", cancellationToken);

            _pipeline.Setup(_renderer);
            var document = Markdown.Parse(content, _pipeline);

            // extract the front matter from markdown document
            var yamlBlock = document.Descendants<YamlFrontMatterBlock>().FirstOrDefault();

            TFrontMatter matter = yamlBlock is not null
                ? _deserializer.Deserialize<TFrontMatter>(yamlBlock.Lines.ToString())
                : new();

            // render the markdown content as html
            _renderer.Render(document);
            await _renderer.Writer.FlushAsync();

            return (matter, new MarkupString(_renderer.Writer.ToString() ?? string.Empty));

        }
        catch
        {
            return (new(), new());
        }
    }
}
