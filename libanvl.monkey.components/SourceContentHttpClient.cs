namespace libanvl.monkey.components;

public class SourceContentHttpClient
{
    private readonly HttpClient _http;
    public SourceContentHttpClient(HttpClient http)
    {
        _http = http;
    }

    public async Task<string> GetMarkdownPageAsync(string route, CancellationToken cancellationToken = default)
    {
        try
        {
            return  await _http.GetStringAsync($"page/{route}.md", cancellationToken);
        }
        catch
        {
            return string.Empty;
        }
    }
}
