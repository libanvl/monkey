using Microsoft.AspNetCore.Components;

namespace libanvl.monkey.components.Model;

public record FeaturedImage
{
    public string Src { get; set; } = string.Empty;

    public string Alt { get; set; } = string.Empty;
}

public record PageMatter
{
    public string Title { get; set; } = "Mauris neque quam";

    public string? SubTitle { get; set; }

    public bool Published { get; set; } = false;

    public IEnumerable<string> Tags { get; set; } = Enumerable.Empty<string>();

    public FeaturedImage? FeaturedImage { get; set; }
}

public record AuthorInfo
{
    public string Name { get; set; } = string.Empty;

    public string? AvatarUrl { get; set; }
}

public record PostMatter : PageMatter
{
    public AuthorInfo Author { get; set; } = new AuthorInfo();

    public DateOnly Date { get; set; }
}

public record PageEntry(PageMatter Matter, string Path);

public record MarkdownTemplateContext(PageMatter Meta, MarkupString Markup);
