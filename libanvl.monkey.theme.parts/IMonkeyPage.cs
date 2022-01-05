using libanvl.monkey.Model;

namespace libanvl.monkey.theme.parts;

public interface IMonkeyPage : IMetaComponent<PageMeta>
{
    bool EnableActions { get; set; }

    string? TitleHref { get; set; }
}