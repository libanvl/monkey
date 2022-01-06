using Microsoft.AspNetCore.Components;

namespace libanvl.monkey.theme.parts;

/// <summary>
/// A Monkey Templated Component with a single Child and Metadata.
/// </summary>
/// <typeparam name="TMeta"></typeparam>
public interface IMetaComponent<TMeta> : IComponent
{
    /// <summary>
    /// The child content.
    /// </summary>
    RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// The metadata.
    /// </summary>
    TMeta? Meta { get; set; }
}