using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;

namespace libanvl.monkey.site;

internal class MonkeyComponentActivator : IComponentActivator
{
    private readonly IServiceProvider _serviceProvider;

    public MonkeyComponentActivator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    public IComponent CreateInstance(
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type componentType)
    {
        // Attempt to get a component from the ServiceProvider
        var spInstance = _serviceProvider.GetService(componentType);
        if (spInstance is IComponent spComponent)
        {
            return spComponent;
        }

        // Attempt to create it the original Blazor way
        var instance = Activator.CreateInstance(componentType);
        if (instance is IComponent component)
        {
            return component;
        }

        // That's not a known component!
        throw new ArgumentException($"The type {componentType.FullName} does not implement {nameof(IComponent)}.", nameof(componentType));

    }
}
