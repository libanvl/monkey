using libanvl.monkey.site;
using libanvl.monkey.theme;
using libanvl.monkey.theme.parts;
using Microsoft.AspNetCore.Components;

namespace libanvl.monkey;

public class MonkeyButton : MonkeyComponentBase, IMonkeyButton
{
    public MonkeyButton(IThemedSiteBuilder siteBuilder)
        : this(siteBuilder, CommonPartKey.Button)
    {
    }

    protected MonkeyButton(IThemedSiteBuilder siteBuilder, string partKey)
        : base(siteBuilder, partKey)
    {
    }

    public ButtonKind Kind { get; set; }

    public ButtonSize Size { get; set; }
    
    public bool Fit { get; set; }
    
    public bool Disabled { get; set; }
    
    public RenderFragment? ChildContent { get; set; }
}
