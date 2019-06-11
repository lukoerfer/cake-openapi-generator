using System;

using Cake.Core;
using Cake.Core.Annotations;
using Cake.OpenApi.Internal;

namespace Cake.OpenApi
{
    /// <summary>
    /// Provides a wrapper to invoke the OpenAPI generator
    /// </summary>
    [CakeAliasCategory("OpenAPI")]
    public static class OpenApiAliases
    {
        private static OpenApiSettings Settings;

        private static OpenApiRunner Runner;

        /// <summary>
        /// Defines the settings for the OpenAPI generator
        /// </summary>
        /// <param name="context"></param>
        /// <param name="tool"></param>
        /// <param name="version"></param>
        /// <param name="endpoint"></param>
        [CakeMethodAlias]
        public static void SetupOpenAPI(this ICakeContext context, string tool = null, string version = null, string endpoint = null)
        {
            OpenApiSettings settings = new OpenApiSettings()
            {
                Tool = tool,
                Version = version,
                Endpoint = string.IsNullOrWhiteSpace(endpoint) ? null : new Uri(endpoint)
            };
            context.SetupOpenAPI(settings);
        }

        /// <summary>
        /// Defines the settings for the OpenAPI generator
        /// </summary>
        /// <param name="context"></param>
        /// <param name="handler"></param>
        [CakeMethodAlias]
        public static void SetupOpenAPI(this ICakeContext context, Action<OpenApiSettings> handler)
        {
            OpenApiSettings settings = new OpenApiSettings();
            handler.Invoke(settings);
            context.SetupOpenAPI(settings);
        }

        /// <summary>
        /// Defines the settings for the OpenAPI generator
        /// </summary>
        /// <param name="context"></param>
        /// <param name="settings"></param>
        [CakeMethodAlias]
        public static void SetupOpenAPI(this ICakeContext context, OpenApiSettings settings)
        {
            if (Settings == null)
            {
                Settings = settings ?? new OpenApiSettings();
            }
            else
            {
                throw new InvalidOperationException("Multiple calls to SetupOpenAPI are not allowed");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [CakePropertyAlias]
        public static OpenApiRunner OpenAPI(this ICakeContext context)
        {
            if (Runner == null)
            {
                OpenApiSettings settings = Settings ?? new OpenApiSettings();
                context.ApplyEnvironmentSettings(settings);
                Runner = new OpenApiRunner(context, settings);
            }
            return Runner;
        }

    }
}
