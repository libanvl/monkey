using libanvl.monkey.Model;
using libanvl.monkey.theme;
using libanvl.monkey.theme.parts;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;

namespace libanvl.monkey.site;

public abstract class MonkeyLayoutBase : MonkeyComponentBase, IMonkeyLayout
{
    protected MonkeyLayoutBase(IThemedSiteBuilder siteBuilder, IConfiguration configuration, string partKey)
        : base(siteBuilder, partKey)
    {
        if (SiteInfo == default)
        {
            SiteInfo = configuration.GetRequiredSection("SiteInfo").Get<SiteInfo>();
        }
    }

    public override Task SetParametersAsync(ParameterView parameters)
    {
        var updatedView = new Dictionary<string, object>(parameters.ToDictionary())
        {
            { nameof(SiteInfo), SiteInfo }
        };

        return base.SetParametersAsync(ParameterView.FromDictionary(updatedView!));
    }

    public RenderFragment? Body { get; set; }

    public SiteInfo SiteInfo { get; set; }
}