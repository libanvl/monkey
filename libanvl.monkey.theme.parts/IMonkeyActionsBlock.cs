using Microsoft.AspNetCore.Components;

namespace libanvl.monkey.theme.parts;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public interface IMonkeyActionsBlock
{
    [Parameter] bool Stacked { get; set; }

    [Parameter] bool Fit { get; set; }

    [Parameter] bool Special { get; set; }

    [Parameter] bool Pagination { get; set; }

    [Parameter] RenderFragment? ChildContent { get; set; }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
