using Microsoft.AspNetCore.Components;

namespace libanvl.monkey.theme.parts;

public interface IMetaComponent<TMeta> : IComponent
{
    RenderFragment? ChildContent { get; set; }

    TMeta? Meta { get; set; }
}