namespace libanvl.monkey.theme.Model;

public record ActionInfo(string Title, string Href, string Classes);

public record LargeButtonAction(string Title, string Href, params string[] AdditionalClasses)
    : ActionInfo(Title, Href, string.Join(' ', AdditionalClasses) + " button large");
