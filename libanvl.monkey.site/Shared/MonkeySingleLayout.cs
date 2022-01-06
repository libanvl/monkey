using libanvl.monkey.site;
using libanvl.monkey.theme;
using libanvl.monkey.theme.parts;
using Microsoft.Extensions.Configuration;

namespace libanvl.monkey;

/// <summary>
/// A Monkey Templated Single Layout
/// </summary>
public class MonkeySingleLayout : MonkeyLayoutBase, IMonkeyLayout
{
    /// <summary>
    /// Initializes an instance of <see cref="MonkeySingleLayout"/>.
    /// </summary>
    /// <param name="siteBuilder"></param>
    /// <param name="configuration"></param>
    public MonkeySingleLayout(IThemedSiteBuilder siteBuilder, IConfiguration configuration)
        : base(siteBuilder, configuration, CommonPartKey.SingleLayout)
    {
    }
}
