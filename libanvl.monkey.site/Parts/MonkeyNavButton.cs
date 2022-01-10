using libanvl.monkey.theme;
using libanvl.monkey.theme.parts;

namespace libanvl.monkey;

public class MonkeyNavButton : MonkeyButton, IMonkeyNavButton
{
    public MonkeyNavButton(IThemedSiteBuilder siteBuilder)
        : base(siteBuilder, CommonPartKey.NavButton)
    {
    }

    public string? Href { get; set; }
}
