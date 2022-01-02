using System.Reflection;

namespace libanvl.monkey;

/// <summary>
/// Helper extensions for Assembly
/// </summary>
public static class AssemblyExtensions
{
    /// <summary>
    /// Gets types that implement <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to search for.</typeparam>
    /// <returns>A list of types that implement <typeparamref name="T"/>.</returns>
    public static IEnumerable<Type> GetImplementers<T>(this Assembly assembly)
    {
        return assembly
            .GetExportedTypes()
            .Where(type => typeof(T).IsAssignableFrom(type) && !type.IsInterface);
    }
}
