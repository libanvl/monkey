using Microsoft.AspNetCore.Components;

namespace libanvl.monkey.theme.parts;

public interface IMonkeyNavButton : IMonkeyButton
{
    [Parameter]
    string? Href { get; set; }
}
