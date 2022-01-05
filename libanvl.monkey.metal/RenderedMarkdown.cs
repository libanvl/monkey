using libanvl.monkey.metal.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace libanvl.monkey.metal;

public class RenderedMarkdown<TMeta> : ComponentBase where TMeta : new()
{
    private RenderedMarkdownContext<TMeta>? _context;

    [Inject]
    private MarkdownParser Parser { get; set; } = default!;

    [Parameter]
    public RenderFragment<RenderedMarkdownContext<TMeta>>? ChildContent { get; set; }

    [Parameter]
    public string? Markdown { get; set; }

    public override async Task SetParametersAsync(ParameterView parameters)
    {
        foreach (var param in parameters)
        {
            switch (param.Name)
            {
                case nameof(ChildContent):
                    ChildContent = (RenderFragment<RenderedMarkdownContext<TMeta>>?)param.Value;
                    break;
                case nameof(Markdown):
                    Markdown = (string?)param.Value;
                    break;
                default:
                    throw new ArgumentException($"Unknown parameter: {param.Name}");
            }
        }

        if (Markdown is not null)
        {
            var (meta, content) = await Parser.ParseAsync<TMeta>(Markdown);
            _context = new(meta, content);
        }

        await base.SetParametersAsync(ParameterView.Empty);
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        if (_context is not null && ChildContent is not null)
        {
            ChildContent(_context)(builder);
        }
    }

    public record RenderedMarkdownContext<T>(T Meta, MarkupString Markup) where T : new();
}
