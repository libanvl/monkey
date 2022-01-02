using libanvl.monkey.theme.Shared;
using System.Reflection;

namespace libanvl.monkey.theme;

public class SiteFactory : IThemedSiteFactory
{
    public Type FoundDefaultLayoutType => typeof(MainLayout);

    public Type NotFoundLayoutType => typeof(SingleLayout);

    public string FocusOnNavigateSelector => ".title";

    public IThemedSiteFactory Initialize(IServiceProvider services)
    {
        return this;
    }

    public IEnumerable<Assembly> GetAssemblies()
    {
        yield return typeof(SiteFactory).Assembly;
    }
}
