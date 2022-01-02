using System.Reflection;

namespace libanvl.monkey;

public interface IThemedSiteFactory
{
    IThemedSiteFactory Initialize(IServiceProvider serviceProvider);

    IEnumerable<Assembly> GetAssemblies();

    Type FoundDefaultLayoutType { get; }

    Type NotFoundLayoutType { get; }

    string FocusOnNavigateSelector { get; }
}
