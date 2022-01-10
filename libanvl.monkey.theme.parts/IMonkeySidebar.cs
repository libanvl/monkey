using libanvl.monkey.Model;
using Microsoft.AspNetCore.Components;

namespace libanvl.monkey.theme.parts;

public interface IMonkeySidebar
{
    [Parameter] public IEnumerable<PostMeta>? Posts { get; set; }
}
