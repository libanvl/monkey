using libanvl.monkey.metal.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace libanvl.monkey.metal;

/// <summary>
/// A Component that renders markdown to html
/// </summary>
/// <typeparam name="TMeta"></typeparam>
public class RenderedMarkdown<TMeta> : ComponentBase where TMeta : new()
{
    private RenderedMarkdownContext<TMeta>? _context;

    [Inject]
    private MarkdownParser Parser { get; set; } = default!;

    /// <summary>
    /// The child content.
    /// </summary>
    [Parameter]
    public RenderFragment<RenderedMarkdownContext<TMeta>>? ChildContent { get; set; }

    /// <summary>
    /// The markdown string.
    /// </summary>
    [Parameter]
    public string? Markdown { get; set; }

    /// <inheritdoc />
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

    /// <inheritdoc />
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        if (_context is not null && ChildContent is not null)
        {
            ChildContent(_context)(builder);
        }
    }

    /// <summary>
    /// The context passed to the child of <see cref="RenderedMarkdown{TMeta}"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="Meta"></param>
    /// <param name="Markup"></param>
    public record RenderedMarkdownContext<T>(T Meta, MarkupString Markup) where T : new();
}
