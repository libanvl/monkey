using libanvl.monkey.Model;
using Microsoft.AspNetCore.Components;

namespace libanvl.monkey.theme.parts;

/// <summary>
/// A Monkey Templated Page
/// </summary>
public interface IMonkeyPage : IMetaComponent<PageMeta>
{
    /// <summary>
    /// Whether to enable the Actions block.
    /// </summary>
    [Parameter]
    bool EnableActions { get; set; }

    /// <summary>
    /// The href for the Title anchor.
    /// </summary>
    string? TitleHref { get; set; }
}