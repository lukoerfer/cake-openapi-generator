using System;
using Cake.Common;
using Cake.Core;

namespace Cake.OpenApi.Internal
{
    internal static class EnvironmentSettings
    {
        private const string ENVIRONMENT_VARIABLE_PREFIX = "CAKE_";

        public static void ApplyEnvironmentSettings(this ICakeContext context, OpenApiSettings settings)
        {
            string tool = context.GetEnvironmentSetting("OPENAPI_TOOL");
            if (tool != null)
            {
                settings.Tool = tool;
            }
            string version = context.GetEnvironmentSetting("OPENAPI_VERSION");
            if (version != null)
            {
                settings.Version = version;
            }
            string endpoint = context.GetEnvironmentSetting("OPENAPI_ENDPOINT");
            if (endpoint != null)
            {
                settings.Endpoint = new Uri(endpoint, UriKind.Absolute);
            }
        }

        private static string GetEnvironmentSetting(this ICakeContext context, string name, string defaultValue = null)
        {
            return context.Argument<string>(name, null) ?? context.EnvironmentVariable(ENVIRONMENT_VARIABLE_PREFIX + name) ?? defaultValue;
        }

    }
}
