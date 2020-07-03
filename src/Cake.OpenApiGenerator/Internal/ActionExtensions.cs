using System;

namespace Cake.OpenApiGenerator
{
    internal static class ActionExtensions
    {
        public static T Evaluate<T>(this Action<T> configurator) where T : new()
        {
            T settings = new T();
            configurator?.Invoke(settings);
            return settings;
        }
    }
}
