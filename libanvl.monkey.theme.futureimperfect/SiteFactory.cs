using libanvl.monkey.theme.futureimperfect.Shared;
using System.Reflection;

namespace libanvl.monkey.theme;

/// <summary>
/// Themed site factory for Future Imperfect
/// </summary>
public class SiteFactory : IThemedSiteFactory
{
    /// <inheritdoc />
    public Type FoundDefaultLayoutType => typeof(MainLayout);

    /// <inheritdoc />
    public Type NotFoundLayoutType => typeof(SingleLayout);

    /// <inheritdoc />
    public string FocusOnNavigateSelector => ".title";

    /// <inheritdoc />
    public IThemedSiteFactory Initialize(IServiceProvider services)
    {
        return this;
    }

    /// <inheritdoc />
    public IEnumerable<Assembly> GetAssemblies()
    {
        yield return typeof(SiteFactory).Assembly;
    }
}
