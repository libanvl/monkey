using libanvl.monkey.Model;
using libanvl.monkey.site;
using libanvl.monkey.theme;
using libanvl.monkey.theme.parts;
using Microsoft.AspNetCore.Components;

namespace libanvl.monkey;

public class MonkeyPage : MonkeyComponentBase, IMonkeyPage
{
    public MonkeyPage(IThemedSiteBuilder siteBuilder)
        :base(siteBuilder, CommonPartKey.Page)
    {
    }

    [Parameter]
    public string? TitleHref { get; set; }

    [Parameter]
    public bool EnableActions { get; set; } = true;

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public PageMeta? Meta { get; set; }
}
