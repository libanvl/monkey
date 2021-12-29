using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace libanvl.monkey.components.Shared;

public partial class SourceMarkdown : IAsyncDisposable
{
    [Parameter]
    public string? PagePath { get; set; }

    [Parameter]
    public string CodeTheme { get; set; } = "https://cdnjs.cloudflare.com/ajax/libs/highlight.js/11.3.1/styles/tomorrow-night-blue.min.css";

    [Parameter]
    public EventCallback OnSourceFailed { get; set; }

    [Inject]
    private SourceContentHttpClient? SourceClient { get; set; }

    [Inject]
    private IJSRuntime? JS { get; set; }

    [Inject]
    private MarkdownParser? Markdown { get; set; }

    private PageMatter? meta;

    private MarkupString markup;

    private IJSObjectReference? highlight;

    protected override async Task OnParametersSetAsync()
    {
        if (PagePath is null)
        {
            return;
        }

        ArgumentNullException.ThrowIfNull(SourceClient);
        ArgumentNullException.ThrowIfNull(Markdown);

        try
        {
            var content = await SourceClient.GetMarkdownPageAsync(PagePath);

            (meta, markup) = await Markdown.ParseAsync<PageMatter>(content);

            if (string.IsNullOrEmpty(markup.Value))
            {
                await OnSourceFailed.InvokeAsync();
            }
        }
        catch
        {
            await OnSourceFailed.InvokeAsync();
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            ArgumentNullException.ThrowIfNull(JS);
            highlight = await JS.InvokeAsync<IJSObjectReference>("import", "./_content/libanvl.monkey.components/Shared/SourceMarkdown.razor.js");
        }

        if (highlight is not null)
        {
            await highlight.InvokeVoidAsync("registerLanguage", "go");
            await highlight.InvokeVoidAsync("highlightAll");
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (highlight is not null)
        {
            await highlight.DisposeAsync();
        }
    }
}
