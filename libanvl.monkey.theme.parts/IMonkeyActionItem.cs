using Microsoft.AspNetCore.Components;

namespace libanvl.monkey.theme.parts;

public interface IMonkeyActionItem
{
    [Parameter]
    RenderFragment? ChildContent { get; set; }
}
