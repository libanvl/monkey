using System.Net;
using Xunit;

namespace libanvl.monkey.github.test;

public class GitHubApiHttpClientTests
{
    [Theory]
    [InlineData(HttpStatusCode.BadRequest)]
    [InlineData(HttpStatusCode.TooManyRequests)]
    [InlineData(HttpStatusCode.InternalServerError)]
    public async Task StatusCode_ReturnsEmptyResult(HttpStatusCode statusCode)
    {
        var httpClient = new HttpClient(new MockHttpMessageHandler(statusCode));
        var x = new GitHubApiHttpClient(httpClient);
        var result = await x.GetRateLimitsAsync();

        var values = new List<int>();
        
        var (resource, rate) = result;
        var (l, rem, res, u, _) = rate;
        values.AddRange(new[] { l, rem, res, u });
        var (c, _, _, _) = resource;
        (l, rem, res, u, _) = c;
        values.AddRange(new[] { l, rem, res, u });
        Assert.All(values, v => Assert.Equal(0, v));
    }
}