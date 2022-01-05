namespace libanvl.monkey.Model;

/// <summary>
/// Data for an Action component.
/// </summary>
/// <param name="Title"></param>
/// <param name="Href"></param>
/// <param name="Classes"></param>
public record ActionInfo(string Title, string Href, string Classes);

/// <summary>
/// Data for a large button Action.
/// </summary>
/// <param name="Title"></param>
/// <param name="Href"></param>
/// <param name="AdditionalClasses"></param>
public record LargeButtonAction(string Title, string Href, params string[] AdditionalClasses)
    : ActionInfo(Title, Href, string.Join(' ', AdditionalClasses) + " button large");
