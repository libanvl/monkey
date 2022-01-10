using libanvl.monkey.Model;
using libanvl.monkey.site;
using libanvl.monkey.theme;
using libanvl.monkey.theme.parts;
using Microsoft.AspNetCore.Components;

namespace libanvl.monkey;
public class MonkeySidebar : MonkeyComponentBase, IMonkeySidebar
{
    public MonkeySidebar(IThemedSiteBuilder siteBuilder)
        : base(siteBuilder, CommonPartKey.Sidebar)
    {
    }

    [Parameter]
    public IEnumerable<PostMeta>? Posts { get; set; }
}
