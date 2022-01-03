namespace libanvl.monkey.theme.Model;

/// <summary>
/// Data for a featured image.
/// </summary>
public record Image
{
    /// <summary>
    /// The src for the image.
    /// </summary>
    public string Src { get; set; } = string.Empty;

    /// <summary>
    /// The alt text for the image.
    /// </summary>
    public string Alt { get; set; } = string.Empty;
}

/// <summary>
/// Metadata about a Page.
/// </summary>
public record PageMeta
{
    /// <summary>
    /// The title.
    /// </summary>
    public string Title { get; set; } = "Mauris neque quam";

    /// <summary>
    /// An optional subtitle.
    /// </summary>
    public string? SubTitle { get; set; }

    /// <summary>
    /// Whether the page has been published.
    /// </summary>
    public bool Published { get; set; } = false;

    /// <summary>
    /// A list of tags.
    /// </summary>
    public IEnumerable<string> Tags { get; set; } = Enumerable.Empty<string>();

    /// <summary>
    /// An optional featured image.
    /// </summary>
    public Image? FeaturedImage { get; set; }
}

/// <summary>
/// Data about an Author.
/// </summary>
public record AuthorInfo
{
    /// <summary>
    /// The author's name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// An optional url to an avatar image.
    /// </summary>
    public string? AvatarUrl { get; set; }
}

/// <summary>
/// Metadate about a Post.
/// </summary>
public record PostMeta : PageMeta
{
    /// <summary>
    /// The post author.
    /// </summary>
    public AuthorInfo Author { get; set; } = new AuthorInfo();

    /// <summary>
    /// The date of the post.
    /// </summary>
    public DateTime Date { get; set; }
}
