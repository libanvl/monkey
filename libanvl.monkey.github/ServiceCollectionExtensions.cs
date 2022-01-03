using libanvl.monkey.github;
using Microsoft.Extensions.DependencyInjection;

namespace libanvl.monkey;

/// <summary>
/// Helper extensions.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add <see cref="GitHubApiHttpClient"/> to <paramref name="services"/>.
    /// </summary>
    /// <param name="services">The app's service collection.</param>
    public static void AddGitHubApiClient(this IServiceCollection services)
    {
        services.AddHttpClient<GitHubApiHttpClient>(client => client.BaseAddress = new Uri("https://api.github.com/"));
    }
}
