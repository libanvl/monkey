using libanvl.monkey.Model;
using libanvl.monkey.theme;
using libanvl.monkey.theme.parts;

namespace libanvl.monkey.site;

public class MonkeyActionsBlock : MonkeyComponentBase, IMonkeyActionsBlock
{
    public MonkeyActionsBlock(IThemedSiteBuilder siteBuilder)
        : base(siteBuilder, CommonPartKey.ActionsBlock)
    {
    }

    public bool Stacked { get; set; }

    public bool Fit { get; set; }

    public bool Special { get; set; }

    public bool Pagination { get; set; }

    public ActionInfo[] Children { get; set; } = Array.Empty<ActionInfo>();
}
