using System.Reflection;

namespace libanvl.monkey.theme;

/// <summary>
/// Monkey Themes must implement this interface to be included in the main site.
/// </summary>
public interface IThemedSiteBuilder
{
    /// <summary>
    /// Initializes the theme.
    /// </summary>
    IThemedSiteBuilder Initialize(IServiceProvider serviceProvider);

    /// <summary>
    /// Gets the theme assemblies.
    /// </summary>
    /// <returns></returns>
    IEnumerable<Assembly> GetAssemblies();

    /// <summary>
    /// Gets the selector for the FocusOnNavigate component.
    /// </summary>
    string FocusOnNavigateSelector { get; }

    /// <summary>
    /// Gets the type for a given theme part.
    /// </summary>
    Type? GetPartType(string partKey);
}

public static class CommonPartKey
{
    public const string MainLayout = "mainlayout";
    public const string SingleLayout = "singlelayout";
    public const string ActionsBlock = "actionsblock";
    public const string Footer = "footer";
    public const string Header = "header";
    public const string Post = "post";
    public const string Page = "page";
}
