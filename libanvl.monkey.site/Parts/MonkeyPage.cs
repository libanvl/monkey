using libanvl.monkey.Model;
using libanvl.monkey.site;
using libanvl.monkey.theme;
using libanvl.monkey.theme.parts;
using Microsoft.AspNetCore.Components;

namespace libanvl.monkey;

/// <summary>
/// A Monkey Templated Page
/// </summary>
public class MonkeyPage : MonkeyComponentBase, IMonkeyPage
{
    /// <summary>
    /// Initializes an instance of <see cref="MonkeyPage"/>.
    /// </summary>
    /// <param name="siteBuilder"></param>
    public MonkeyPage(IThemedSiteBuilder siteBuilder)
        :base(siteBuilder, CommonPartKey.Page)
    {
    }

    /// <inheritdoc />
    [Parameter]
    public string? TitleHref { get; set; }

    /// <inheritdoc />
    [Parameter]
    public bool EnableActions { get; set; } = true;

    /// <inheritdoc />
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <inheritdoc />
    [Parameter]
    public PageMeta? Meta { get; set; }
}
