using System.Net;

namespace libanvl.monkey.github.test;

internal class MockHttpMessageHandler : HttpMessageHandler
{
    private readonly HttpStatusCode _responseCode;

    public MockHttpMessageHandler(HttpStatusCode responseCode)
    {
        _responseCode = responseCode;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new HttpResponseMessage(_responseCode));
    }
}
