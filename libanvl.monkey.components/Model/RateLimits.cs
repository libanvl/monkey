namespace libanvl.monkey.components.Model;

public record struct RateLimits(Resources Resources, Rate Rate);

public record struct Resources(Rate Core, Rate Graphql, Rate Integration_Manifest, Rate Search);

public record struct Rate(int Limit, int Remaining, int Reset, int Used, string Resource);
