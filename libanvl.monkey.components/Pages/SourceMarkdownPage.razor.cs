using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace libanvl.monkey.components.Pages;

public partial class SourceMarkdownPage : IAsyncDisposable
{
    [Parameter]
    public string? PagePath { get; set; }

    [Parameter]
    public EventCallback OnFetchFailed { get; set; }

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

        var content = await SourceClient.GetMarkdownPageAsync(PagePath);

        (meta, markup) = await Markdown.ParseAsync<PageMatter>(content);

        if (string.IsNullOrEmpty(markup.Value))
        {
            await OnFetchFailed.InvokeAsync();
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            ArgumentNullException.ThrowIfNull(JS);

            highlight = await JS.InvokeAsync<IJSObjectReference>("import", "./_content/libanvl.monkey.components/Pages/SourceMarkdownPage.razor.js");
        }

        if (highlight is not null)
        {
            await highlight.InvokeVoidAsync("highlightAll", "csharp");
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
