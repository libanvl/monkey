using Microsoft.AspNetCore.Components;

namespace libanvl.monkey.theme.parts;

public enum ButtonKind
{
    Button = 0,
    InputButton = 1,
    InputReset = 2,
    InputSubmit = 4,
    Anchor = 8,
}

public enum ButtonSize
{
    Default = 0,
    Small = 1,
    Large = 2,
}

public interface IMonkeyButton
{
    [Parameter]
    ButtonKind Kind { get; set; }

    [Parameter]
    ButtonSize Size { get; set; }

    [Parameter]
    bool Fit { get; set; }

    [Parameter]
    bool Disabled { get; set; }

    [Parameter]
    RenderFragment? ChildContent {get; set;}
}
