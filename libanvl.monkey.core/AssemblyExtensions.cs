using System.Reflection;

namespace libanvl.monkey;

public static class AssemblyExtensions
{
    public static IEnumerable<Type> GetImplementers<T>(this Assembly assembly)
    {
        return assembly
            .GetExportedTypes()
            .Where(type => typeof(T).IsAssignableFrom(type) && !type.IsInterface);
    }
}
