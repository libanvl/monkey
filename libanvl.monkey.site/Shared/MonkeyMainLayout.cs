using libanvl.monkey.site;
using libanvl.monkey.theme;
using libanvl.monkey.theme.parts;
using Microsoft.Extensions.Configuration;

namespace libanvl.monkey;

/// <summary>
/// Monkey Templates Main Layout.
/// </summary>
public class MonkeyMainLayout : MonkeyLayoutBase, IMonkeyLayout
{
    /// <summary>
    /// Initializes an instance of <see cref="MonkeyMainLayout"/>.
    /// </summary>
    /// <param name="siteBuilder"></param>
    /// <param name="configuration"></param>
    public MonkeyMainLayout(IThemedSiteBuilder siteBuilder, IConfiguration configuration)
        : base(siteBuilder, configuration, CommonPartKey.MainLayout)
    {
    }
}
