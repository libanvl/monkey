using System.Text.Json;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace libanvl.monkey.meta;

/// <summary>
/// Represents the core implementation of the tool.
/// </summary>
public class Runner
{
    /// <summary>
    /// Runs the core implementation of the tool.
    /// </summary>
    /// <param name="args">The command-line arguments.</param>
    /// <returns>The tool return code.</returns>
	public async ValueTask<int> RunAsync(string[] args)
    {
        await Console.Out.WriteLineAsync("libanvl monkey meta generator");

        string? baseDir = args?.ElementAtOrDefault(0);

        if (baseDir is null)
        {
            return -1;
        }

        if (!Directory.Exists(baseDir))
        {
            return -2;
        }

        string pageDir = Path.Join(baseDir, "page");

        if (!Directory.Exists(pageDir))
        {
            return -2;
        }

        var pagePaths = Directory.GetFiles(pageDir, "*.md", new EnumerationOptions()
        {
            RecurseSubdirectories = true,
            IgnoreInaccessible = true,
            MatchType = MatchType.Win32
        });

        if (!pagePaths.Any())
        {
            return -3;
        }

        var yamlDeserializer = new DeserializerBuilder()
            .WithNamingConvention(UnderscoredNamingConvention.Instance)
            .Build();

        var pageList = new List<PageEntry>();

        foreach (var filePath in pagePaths)
        {
            using var input = new StreamReader(filePath);
            var parser = new Parser(input);
            parser.Consume<StreamStart>();
            parser.Consume<DocumentStart>();
            var pageMatter = yamlDeserializer.Deserialize<PageMatter>(parser);
            parser.Consume<DocumentEnd>();
            pageList.Add(new PageEntry(pageMatter, Path.GetRelativePath(baseDir, filePath)));
        }

        await Console.Out.WriteLineAsync(JsonSerializer.Serialize(pageList, new JsonSerializerOptions
        {
            WriteIndented = true,
        }));

        return 0;
    }
}
