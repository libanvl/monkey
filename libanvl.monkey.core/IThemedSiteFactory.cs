using System.Reflection;

namespace libanvl.monkey;

/// <summary>
/// Monkey Themes must implement this interface to be included in the main site.
/// </summary>
public interface IThemedSiteFactory
{
    /// <summary>
    /// Initializes the theme.
    /// </summary>
    IThemedSiteFactory Initialize(IServiceProvider serviceProvider);

    /// <summary>
    /// Gets the theme assemblies.
    /// </summary>
    /// <returns></returns>
    IEnumerable<Assembly> GetAssemblies();

    /// <summary>
    /// Gets the type of the default layout.
    /// </summary>
    Type FoundDefaultLayoutType { get; }

    /// <summary>
    /// Gets the type of the not found layout.
    /// </summary>
    Type NotFoundLayoutType { get; }

    /// <summary>
    /// Gets the selector for the FocusOnNavigate component.
    /// </summary>
    string FocusOnNavigateSelector { get; }
}
