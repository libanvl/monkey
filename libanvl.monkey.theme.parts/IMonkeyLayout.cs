using libanvl.monkey.Model;
using Microsoft.AspNetCore.Components;

namespace libanvl.monkey.theme.parts;

/// <summary>
/// A Monkey Templated Layout
/// </summary>
public interface IMonkeyLayout
{
    /// <summary>
    /// The layout child component.
    /// </summary>
    [Parameter] RenderFragment? Body { get; set; }

    /// <summary>
    /// The site info for the running site.
    /// </summary>
    [Parameter] SiteInfo SiteInfo { get; set; }
}