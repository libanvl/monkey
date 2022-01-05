using libanvl.monkey.site;
using libanvl.monkey.theme;
using libanvl.monkey.theme.parts;
using Microsoft.Extensions.Configuration;

namespace libanvl.monkey;

public class MonkeyMainLayout : MonkeyLayoutBase, IMonkeyLayout
{
    public MonkeyMainLayout(IThemedSiteBuilder siteBuilder, IConfiguration configuration)
        : base(siteBuilder, configuration, CommonPartKey.MainLayout)
    {
    }
}
