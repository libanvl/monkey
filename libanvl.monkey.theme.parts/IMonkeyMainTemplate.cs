using Microsoft.AspNetCore.Components;

namespace libanvl.monkey.theme.parts;

public interface IMonkeyMainTemplate
{
    [Parameter] public RenderFragment? Content { get; set; }

    [Parameter] public RenderFragment? Sidebar { get; set; }
}
