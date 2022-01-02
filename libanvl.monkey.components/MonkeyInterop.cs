using Microsoft.JSInterop;

namespace libanvl.monkey.components;

public class MonkeyInterop
{
    private readonly IJSRuntime _runtime;
    private readonly Task<IJSObjectReference> _module;

    public MonkeyInterop(IJSRuntime runtime)
    {
        _runtime = runtime;
        _module = InitializedAsync();
    }

    public async Task RemoveElementsByClass(string className)
    {
        var module = await _module;
        await module.InvokeVoidAsync("removeElementsByClass", className);
    }

    private async Task<IJSObjectReference> InitializedAsync()
    {
        return await _runtime.InvokeAsync<IJSObjectReference>(
            "import",
            "./_content/libanvl.monkey.components/_monkey/main.js");
    }
}
