using Microsoft.AspNetCore.Components;

namespace libanvl.monkey.theme.Model;

/// <summary>
/// Sitewide Infomation.
/// </summary>
/// <param name="Title"></param>
/// <param name="Description"></param>
/// <param name="Logo"></param>
/// <param name="Links"></param>
public record struct SiteInfo(
    string Title,
    string Description,
    SiteLogo? Logo,
    PageLink[]? Links
);

/// <summary>
/// Describes a link for the nav menu.
/// </summary>
/// <param name="Title"></param>
/// <param name="Href"></param>
/// <param name="Description"></param>
public record struct PageLink(
    string Title,
    string Href,
    string? Description
);

/// <summary>
/// Describes a site logo.
/// </summary>
/// <param name="Src"></param>
/// <param name="Alt"></param>
public record struct SiteLogo(
    string Src,
    string Alt
);
