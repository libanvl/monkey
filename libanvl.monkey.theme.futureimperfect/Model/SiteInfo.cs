using Microsoft.AspNetCore.Components;

namespace libanvl.monkey.theme.Model;

public record struct SiteInfo(
    string Title,
    string Description,
    PageImage? Logo,
    PageLink[]? Links
);

public record struct PageLink(
    string Title,
    string Href,
    string? Description
);

public record struct PageImage(
    string Src,
    string Alt
);
