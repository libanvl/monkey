using libanvl.monkey.site;
using libanvl.monkey.theme;
using libanvl.monkey.theme.parts;
using Microsoft.AspNetCore.Components;

namespace libanvl.monkey;

public class MonkeyActionItem : MonkeyComponentBase, IMonkeyActionItem
{
    public MonkeyActionItem(IThemedSiteBuilder siteBuilder)
        : base(siteBuilder, CommonPartKey.ActionItem)
    {
    }

    public RenderFragment? ChildContent { get; set; }
}
