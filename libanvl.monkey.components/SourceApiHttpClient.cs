using Microsoft.AspNetCore.Components.WebAssembly.Http;
using System.Net.Http.Json;

namespace libanvl.monkey.components;

public class SourceApiHttpClient
{
    private readonly HttpClient _http;

    public SourceApiHttpClient(HttpClient http)
    {
        _http = http;
    }

    public async Task<RateLimits> GetRateLimitsAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("GET"),
                RequestUri = new Uri("rate_limit", UriKind.Relative)
            };

            requestMessage.SetBrowserRequestCache(BrowserRequestCache.NoCache);

            var result = await _http.SendAsync(requestMessage, cancellationToken);
            return await result.Content.ReadFromJsonAsync<RateLimits>(cancellationToken: cancellationToken);
        }
        catch
        {
            return new RateLimits();
        }
    }
}
