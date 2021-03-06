using libanvl.monkey.theme;
using Microsoft.AspNetCore.Components;

namespace libanvl.monkey.site;

/// <summary>
/// Base class for Monkey Themed Component proxies
/// </summary>
public abstract class MonkeyComponentBase : IComponent
{
    /// <summary>
    /// Initializes an instance of <see cref="MonkeyComponentBase"/>.
    /// </summary>
    /// <param name="siteBuilder"></param>
    /// <param name="partKey"></param>
    /// <exception cref="InvalidOperationException"></exception>
    protected MonkeyComponentBase(IThemedSiteBuilder siteBuilder, string partKey)
    {
        var templateType = siteBuilder.GetPartType(partKey);

        if (templateType is null)
        {
            throw new InvalidOperationException($"The template does not support the part {partKey}");
        }

        if (Activator.CreateInstance(templateType) is IComponent component)
        {
            TemplateComponent = component;
        }
        else
        {
            throw new InvalidOperationException($"The template part could not be initialized {partKey}");
        }
    }

    /// <summary>
    /// The activated component from the template.
    /// </summary>
    protected virtual IComponent TemplateComponent { get; }

    /// <inheritdoc />
    public virtual void Attach(RenderHandle renderHandle)
    {
        TemplateComponent.Attach(renderHandle);
    }

    /// <inheritdoc />
    public virtual Task SetParametersAsync(ParameterView parameters)
    {
#if DEBUG
        foreach (var p in parameters)
        {
            Console.WriteLine($"{p.Name} => {p.Value}");
        }
#endif

        return TemplateComponent.SetParametersAsync(parameters);
    }
}