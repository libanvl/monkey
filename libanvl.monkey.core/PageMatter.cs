namespace libanvl.monkey;

public record PageMatter
{
    public string Title { get; set; } = string.Empty;

    public string SubTitle { get; set; } = string.Empty;

    public bool Published { get; set; } = false;

    public IEnumerable<string> Tags { get; set; } = Enumerable.Empty<string>();
}

public record PageEntry(PageMatter Matter, string Path);
