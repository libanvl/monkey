using libanvl.monkey.theme;
using Microsoft.AspNetCore.Components;

namespace libanvl.monkey.site;

public abstract class MonkeyComponentBase : IComponent
{
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
    protected virtual IComponent TemplateComponent { get; }

    public virtual void Attach(RenderHandle renderHandle)
    {
        TemplateComponent.Attach(renderHandle);
    }

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