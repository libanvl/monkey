using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.Extensions.Configuration;

namespace libanvl.monkey.components.Shared;

public class ThemeScript : ComponentBase
{
    [Inject]
    private IConfiguration? Configuration { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(Configuration);

        var themeBase = Configuration
            .GetRequiredSection("Monkey")
            .GetValue<string>("Theme");

        var scripts = Configuration
            .GetSection("ThemeSettings")
            .GetSection("scripts")
            .AsEnumerable()
            .OrderBy(kvp => kvp.Key);

        if (scripts is null)
        {
            return;
        }

        int seq = 0;

        foreach (var pair in scripts)
        {
            var scriptSrc = pair.Value;

            if (string.IsNullOrWhiteSpace(scriptSrc))
            {
                continue;
            }

            var scriptKey = pair.Key;

            builder.OpenElement(seq++, "script");
            builder.AddAttribute(seq++, "src", $"_content/{themeBase}/_theme/{scriptSrc}");
            builder.AddAttribute(seq++, "class", "monkey-theme-script");
            builder.AddAttribute(seq++, "id", scriptKey);
            builder.CloseElement();
        }
    }
}
