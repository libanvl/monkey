using libanvl.monkey.Model;
using Microsoft.AspNetCore.Components;

namespace libanvl.monkey.theme.parts;

public interface IMonkeyLayout
{
    [Parameter]
    RenderFragment? Body { get; set; }

    [Parameter]
    SiteInfo SiteInfo { get; set; }
}