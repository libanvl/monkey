using Microsoft.JSInterop;

namespace libanvl.monkey.Services;

/// <summary>
/// Wrapper around the Monkey JS module.
/// </summary>
public class MonkeyInterop
{
    private readonly IJSRuntime _runtime;
    private readonly Task<IJSObjectReference> _module;

    /// <summary>
    /// Initializes an instance of <see cref="MonkeyInterop"/>.
    /// </summary>
    /// <param name="runtime"></param>
    public MonkeyInterop(IJSRuntime runtime)
    {
        _runtime = runtime;
        _module = InitializedAsync();
    }

    /// <summary>
    /// Remove all elements with the given <paramref name="className"/>.
    /// </summary>
    /// <param name="className">The class name.</param>
    public async Task RemoveElementsByClass(string className)
    {
        var module = await _module;
        await module.InvokeVoidAsync("removeElementsByClass", className);
    }

    private async Task<IJSObjectReference> InitializedAsync()
    {
        return await _runtime.InvokeAsync<IJSObjectReference>(
            "import",
            "./_content/libanvl.monkey.core/_monkey/main.js");
    }
}
