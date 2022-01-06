using libanvl.monkey.Model;
using libanvl.monkey.theme;
using libanvl.monkey.theme.parts;

namespace libanvl.monkey.site;

/// <summary>
/// Renders a block of <see cref="ActionInfo"/>.
/// </summary>
public class MonkeyActionsBlock : MonkeyComponentBase, IMonkeyActionsBlock
{
    /// <summary>
    /// Initializes an instance of <see cref="MonkeyActionsBlock"/>.
    /// </summary>
    /// <param name="siteBuilder"></param>
    public MonkeyActionsBlock(IThemedSiteBuilder siteBuilder)
        : base(siteBuilder, CommonPartKey.ActionsBlock)
    {
    }

    /// <inheritdoc />
    public bool Stacked { get; set; }

    /// <inheritdoc />
    public bool Fit { get; set; }

    /// <inheritdoc />
    public bool Special { get; set; }

    /// <inheritdoc />
    public bool Pagination { get; set; }

    /// <inheritdoc />
    public ActionInfo[] Children { get; set; } = Array.Empty<ActionInfo>();
}
