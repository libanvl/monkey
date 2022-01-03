namespace libanvl.monkey.github.Model;

/// <summary>
/// GitHub API Rate Limits.
/// </summary>
/// <param name="Resources"></param>
/// <param name="Rate"></param>
public record struct RateLimits(Resources Resources, Rate Rate);

/// <summary>
/// The Rate Limit Resource Collection.
/// </summary>
/// <param name="Core"></param>
/// <param name="Graphql"></param>
/// <param name="Integration_Manifest"></param>
/// <param name="Search"></param>
public record struct Resources(Rate Core, Rate Graphql, Rate Integration_Manifest, Rate Search);

/// <summary>
/// Rate Limit Values.
/// </summary>
/// <param name="Limit"></param>
/// <param name="Remaining"></param>
/// <param name="Reset"></param>
/// <param name="Used"></param>
/// <param name="Resource"></param>
public record struct Rate(int Limit, int Remaining, int Reset, int Used, string Resource);
