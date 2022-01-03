using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace libanvl.monkey;

/// <summary>
/// Fetches content using the named HttpClient and passes it to a child component.
/// </summary>
public class Fetch : ComponentBase
{
    private string? _result;
    private bool _fetched = false;

    [Inject]
    private IHttpClientFactory? ClientFactory { get; set; }

    [Inject]
    private NavigationManager? NavigationManager { get; set; }

    /// <summary>
    /// The name of the <see cref="HttpClient"/> to use.
    /// </summary>
    [Parameter]
    public string? ClientName { get; set; }

    /// <summary>
    /// The path of the content to fetch, relative to the base uri of the <see cref="HttpClient"/>.
    /// </summary>
    [Parameter]
    public string? Path { get; set; }

    /// <summary>
    /// The fragment to render if the content is fetched.
    /// </summary>
    [Parameter]
    public RenderFragment<string>? Found { get; set; }

    /// <summary>
    /// The fragment to render if the content is not fetched. If <c>null</c>
    /// a failed fetch will redirect to 404.
    /// </summary>
    [Parameter]
    public RenderFragment? NotFound { get; set; }

    /// <summary>
    /// The fragment to render while fetching the content.
    /// </summary>
    [Parameter] 
    public RenderFragment? Loading { get; set; }


    /// <inheritdoc />
    protected override async Task OnParametersSetAsync()
    {
        ArgumentNullException.ThrowIfNull(ClientFactory);
        ArgumentNullException.ThrowIfNull(ClientName);

        try
        {
            var client = ClientFactory.CreateClient(ClientName);
            _result = await client.GetStringAsync(Path);
            _fetched = true;
        }
        catch
        {
            _result = null;
            _fetched = true;
        }
    }

    /// <inheritdoc />
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        if (!_fetched)
        {
            if (Loading is not null)
            {
                Loading(builder);
                return;
            }
        }

        if (_result is null)
        {
            if (NotFound is not null)
            {
                NotFound(builder);
                return;
            }

            ArgumentNullException.ThrowIfNull(NavigationManager);
            NavigationManager.NavigateTo("404");
            return;
        }

        if (Found is not null)
        {
            Found(_result)(builder);
        }
    }
}
