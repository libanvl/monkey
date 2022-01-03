using libanvl.monkey.github.Model;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using System.Net.Http.Json;

namespace libanvl.monkey.github;

/// <summary>
/// Operations for the GitHub API.
/// </summary>
public class GitHubApiHttpClient
{
    private readonly HttpClient _http;

    /// <summary>
    /// Initializes an instance of <see cref="GitHubApiHttpClient"/>.
    /// </summary>
    /// <param name="http"></param>
    public GitHubApiHttpClient(HttpClient http) => _http = http;

    /// <summary>
    /// Get the current rate limit status.
    /// </summary>
    /// <param name="cancellationToken"></param>
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
