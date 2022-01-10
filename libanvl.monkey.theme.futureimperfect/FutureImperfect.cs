using libanvl.monkey.theme.futureimperfect.Shared;
using System.Reflection;

namespace libanvl.monkey.theme.futureimperfect;

/// <summary>
/// Themed site factory for Future Imperfect
/// </summary>
public class FutureImperfect : IThemedSiteBuilder
{
    /// <inheritdoc />
    public string FocusOnNavigateSelector => ".title h2";

    /// <inheritdoc />
    public IEnumerable<string> StylesheetHrefs { get; } = new List<string>
    {
        "_content/libanvl.monkey.theme.futureimperfect/_theme/main.css"
    };

    /// <inheritdoc />
    public IThemedSiteBuilder Initialize(IServiceProvider services)
    {
        return this;
    }

    /// <inheritdoc />
    public IEnumerable<Assembly> GetAssemblies()
    {
        yield return typeof(FutureImperfect).Assembly;
    }

    /// <inheritdoc />
    public Type? GetPartType(string partKey)
    {
        return partKey switch
        {
            CommonPartKey.MainLayout => typeof(MainLayout),
            CommonPartKey.MainTemplate => typeof(MainTemplate),
            CommonPartKey.SingleLayout => typeof(SingleLayout),
            CommonPartKey.Sidebar => typeof(MainSidebar),
            CommonPartKey.Page => typeof(Parts.Post),
            CommonPartKey.ActionsBlock => typeof(Parts.ActionsBlock),
            CommonPartKey.ActionItem => typeof(Parts.ActionItem),
            CommonPartKey.Button => typeof(Parts.Button),
            CommonPartKey.NavButton => typeof(Parts.NavButton),
            _ => null
        };
    }
}
