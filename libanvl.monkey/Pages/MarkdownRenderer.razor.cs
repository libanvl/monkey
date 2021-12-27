using libanvl.monkey.Clients;
using Microsoft.AspNetCore.Components;

namespace libanvl.monkey.Pages;

public partial class MarkdownRenderer
{
    [Inject]
    public SourceContentHttpClient? Content { get; set; }

    [Parameter]
    public string? PageRoute { get; set; }

    private PageMatter? pageMatter;

    private MarkupString pageContent;

    protected override async Task OnInitializedAsync()
    {
        ArgumentNullException.ThrowIfNull(Content);

        if (PageRoute is not null)
        {
            (pageMatter, pageContent) = await Content.GetPageAsync<PageMatter>(PageRoute);
        }
    }
}
