using libanvl.monkey.theme;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace libanvl.monkey.site;

internal class MonkeyRootComponent : IComponent
{
    private readonly IEnumerable<string> _stylesheetHrefs;
    private RenderHandle _renderHandle;

    public MonkeyRootComponent(IThemedSiteBuilder siteBuilder)
    {
        _stylesheetHrefs = siteBuilder.StylesheetHrefs;
    }

    void IComponent.Attach(RenderHandle renderHandle)
    {
        _renderHandle = renderHandle;
    }

    Task IComponent.SetParametersAsync(ParameterView parameters)
    {
        _renderHandle.Render(RenderDelegate);
        return Task.CompletedTask;
    }

    private void RenderDelegate(RenderTreeBuilder builder)
    {
        foreach (var href in _stylesheetHrefs)
        {
            builder.AddMarkupContent(0, $"<link href=\"{href}\" rel=\"stylesheet\" class=\"monkey-injected\" />");
        }
    }
}
