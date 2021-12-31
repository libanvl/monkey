using Microsoft.AspNetCore.Components;

namespace libanvl.monkey.theme.Model;

public record struct PageLink(string Title, string Href, string? Description);

public record struct PageImage(string Src, string Alt);

public record struct SiteInfo(string Title, MarkupString Description, PageImage? Logo, PageLink[]? Links);

public record ActionInfo(string Title, string Href, string Classes);

public record LargeButtonAction(string Title, string Href, params string[] AdditionalClasses) : ActionInfo(Title, Href, string.Join(' ', AdditionalClasses) + " button large");
