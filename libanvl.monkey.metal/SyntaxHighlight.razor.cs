using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace libanvl.monkey.metal;

/// <summary>
/// Syntax Highlighting Component.
/// </summary>
public partial class SyntaxHighlight : IAsyncDisposable
{
    /// <summary>
    /// Gets or sets the path to a stylesheet for the syntax highlighting.
    /// </summary>
    [Parameter]
    public string? CodeThemeHref { get; set; } = "https://unpkg.com/@highlightjs/cdn-assets@11.3.1/styles/tomorrow-night-blue.min.css";

    /// <summary>
    /// Gets or sets an array of string identifiers for additional languages to load.
    /// </summary>
    [Parameter]
    public string[] AdditionalLanguages { get; set; } = Array.Empty<string>();

    /// <summary>
    /// Gets or sets a class for the div container.
    /// </summary>
    [Parameter]
    public string? ContainerClass { get; set; }

    /// <summary>
    /// Gets or sets an id for the div container.
    /// </summary>
    [Parameter]
    public string? ContainerId { get; set; }

    /// <summary>
    /// Gets or sets the content to highlight.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Inject]
    private IJSRuntime? JS { get; set; }

    private ElementReference markupContainer;

    private IJSObjectReference? highlight;

    /// <inheritdoc />
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            ArgumentNullException.ThrowIfNull(JS);
            highlight = await JS.InvokeAsync<IJSObjectReference>("import", "./_content/libanvl.monkey.metal/SyntaxHighlight.razor.js");

            foreach (string lang in AdditionalLanguages)
            {
                await highlight.InvokeVoidAsync("registerLanguage", lang);
            }
        }

        if (highlight is not null)
        {
            await highlight.InvokeVoidAsync("highlightContainer", markupContainer);
        }
    }

    /// <inheritdoc />
    public async ValueTask DisposeAsync()
    {
        if (highlight is not null)
        {
            await highlight.DisposeAsync();
        }

        GC.SuppressFinalize(this);
    }
}