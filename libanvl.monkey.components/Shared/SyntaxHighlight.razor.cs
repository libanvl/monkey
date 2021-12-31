using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace libanvl.monkey.components.Shared;

public partial class SyntaxHighlight : IAsyncDisposable
{
    [Parameter]
    public string CodeTheme { get; set; } = "https://cdnjs.cloudflare.com/ajax/libs/highlight.js/11.3.1/styles/tomorrow-night-blue.min.css";

    [Parameter]
    public string[] AdditionalLanguages { get; set; } = Array.Empty<string>();

    [Parameter]
    public string? ContainerClass { get; set; }

    [Parameter]
    public string? ContainerId { get; set; }

    [Parameter]
    public  RenderFragment? ChildContent { get; set; }

    [Inject]
    private IJSRuntime? JS { get; set; }

    private ElementReference markupContainer;

    private IJSObjectReference? highlight;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            ArgumentNullException.ThrowIfNull(JS);
            highlight = await JS.InvokeAsync<IJSObjectReference>("import", "./_content/libanvl.monkey.components/Shared/SyntaxHighlight.razor.js");
            
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

    public async ValueTask DisposeAsync()
    {
        if (highlight is not null)
        {
            await highlight.DisposeAsync();
        }
    }
}