using libanvl.monkey.Model;
using libanvl.monkey.site;
using libanvl.monkey.theme;
using libanvl.monkey.theme.parts;
using Microsoft.AspNetCore.Components;

namespace libanvl.monkey;

public class MonkeyMainTemplate : MonkeyComponentBase, IMonkeyMainTemplate
{
    public MonkeyMainTemplate(IThemedSiteBuilder siteBuilder)
        : base(siteBuilder, CommonPartKey.MainTemplate)
    {
    }

    [Parameter]
    public RenderFragment? Content { get; set; }

    [Parameter]
    public RenderFragment? Sidebar { get; set; }
}
