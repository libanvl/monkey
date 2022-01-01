using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.Extensions.Configuration;

namespace libanvl.monkey.components.Shared;

public class ThemeStyle : ComponentBase
{
    [Inject]
    private IConfiguration? Configuration { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(Configuration);

        var themeBase = Configuration
            .GetRequiredSection("Monkey")
            .GetValue<string>("Theme");

        var styles = Configuration
            .GetSection("ThemeSettings")
            .GetSection("styles")
            .AsEnumerable()
            .OrderBy(kvp => kvp.Key);

        if (styles is null)
        {
            return;
        }

        int seq = 0;

        foreach (var pair in styles)
        {
            var styleSrc = pair.Value;

            if (string.IsNullOrWhiteSpace(styleSrc))
            {
                continue;
            }

            var styleKey = pair.Key;

            builder.OpenElement(seq++, "link");
            builder.AddAttribute(seq++, "href", $"_content/{themeBase}/_theme/{styleSrc}");
            builder.AddAttribute(seq++, "rel", "stylesheet");
            builder.AddAttribute(seq++, "id", styleKey);
            builder.CloseElement();
        }
    }
}
