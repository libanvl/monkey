using libanvl.monkey.Model;
using libanvl.monkey.theme;
using libanvl.monkey.theme.parts;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;

namespace libanvl.monkey.site;

/// <summary>
/// Base class for Monkey Template Layout proxies.
/// </summary>
public abstract class MonkeyLayoutBase : MonkeyComponentBase, IMonkeyLayout
{
    /// <summary>
    /// Initializes an instance of <see cref="MonkeyLayoutBase"/>.
    /// </summary>
    /// <param name="siteBuilder"></param>
    /// <param name="configuration"></param>
    /// <param name="partKey"></param>
    protected MonkeyLayoutBase(IThemedSiteBuilder siteBuilder, IConfiguration configuration, string partKey)
        : base(siteBuilder, partKey)
    {
        if (SiteInfo == default)
        {
            SiteInfo = configuration.GetRequiredSection("SiteInfo").Get<SiteInfo>();
        }
    }

    /// <inheritdoc />
    public override Task SetParametersAsync(ParameterView parameters)
    {
        var updatedView = new Dictionary<string, object>(parameters.ToDictionary())
        {
            { nameof(SiteInfo), SiteInfo }
        };

        return base.SetParametersAsync(ParameterView.FromDictionary(updatedView!));
    }

    /// <inheritdoc />
    public RenderFragment? Body { get; set; }

    /// <inheritdoc />
    public SiteInfo SiteInfo { get; set; }
}