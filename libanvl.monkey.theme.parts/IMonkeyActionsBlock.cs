using libanvl.monkey.Model;
using Microsoft.AspNetCore.Components;

namespace libanvl.monkey.theme.parts;

public interface IMonkeyActionsBlock
{
    [Parameter] bool Stacked { get; set; }

    [Parameter] bool Fit { get; set; }

    [Parameter] bool Special { get; set; }

    [Parameter] bool Pagination { get; set; }

    [Parameter] ActionInfo[] Children { get; set; }

}
