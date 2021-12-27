using libanvl.monkey;
using libanvl.monkey.Clients;
using Markdig;
using Markdig.Prism;
using Markdig.Renderers;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(_ => new MarkdownPipelineBuilder()
    .UseAdvancedExtensions()
    .UseYamlFrontMatter()
    .UsePrism()
    .DisableHtml()
    .Build());
builder.Services.AddScoped(_ => new DeserializerBuilder().WithNamingConvention(UnderscoredNamingConvention.Instance).Build());
builder.Services.AddTransient(sp =>
{
    return new HtmlRenderer(new StringWriter());
});

var rawContentUri = string.Format(
    "https://raw.githubusercontent.com/{0}/{1}/{2}/",
    builder.Configuration["GitHub:Owner"],
    builder.Configuration["GitHub:Repo"],
    builder.Configuration["GitHub:Branch"]);

builder.Services.AddHttpClient<SourceContentHttpClient>(client => client.BaseAddress = new Uri(rawContentUri));
builder.Services.AddHttpClient<SourceApiHttpClient>(client => client.BaseAddress = new Uri("https://api.github.com/"));

await builder.Build().RunAsync();
