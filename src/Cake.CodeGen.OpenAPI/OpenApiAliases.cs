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
        private static OpenApiGeneratorSettings Settings;

        private static OpenApiGenerator Runner;

        /// <summary>
        /// Defines the settings for the OpenAPI generator
        /// </summary>
        /// <param name="context"></param>
        /// <param name="tool"></param>
        /// <param name="version"></param>
        /// <param name="endpoint"></param>
        [CakeMethodAlias]
        public static void SetupOpenApiGenerator(this ICakeContext context, string tool = null, string version = null, string endpoint = null)
        {
            OpenApiGeneratorSettings settings = new OpenApiGeneratorSettings()
            {
                Tool = tool,
                Version = version,
                Endpoint = string.IsNullOrWhiteSpace(endpoint) ? null : new Uri(endpoint)
            };
            context.SetupOpenApiGenerator(settings);
        }

        /// <summary>
        /// Defines the settings for the OpenAPI generator
        /// </summary>
        /// <param name="context"></param>
        /// <param name="handler"></param>
        [CakeMethodAlias]
        public static void SetupOpenApiGenerator(this ICakeContext context, Action<OpenApiGeneratorSettings> handler)
        {
            OpenApiGeneratorSettings settings = new OpenApiGeneratorSettings();
            handler.Invoke(settings);
            context.SetupOpenApiGenerator(settings);
        }

        /// <summary>
        /// Defines the settings for the OpenAPI generator
        /// </summary>
        /// <param name="context"></param>
        /// <param name="settings"></param>
        [CakeMethodAlias]
        public static void SetupOpenApiGenerator(this ICakeContext context, OpenApiGeneratorSettings settings)
        {
            if (Settings == null)
            {
                Settings = settings ?? new OpenApiGeneratorSettings();
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
        public static OpenApiGenerator OpenApiGenerator(this ICakeContext context)
        {
            if (Runner == null)
            {
                OpenApiGeneratorSettings settings = Settings ?? new OpenApiGeneratorSettings();
                context.ApplyEnvironmentSettings(settings);
                Runner = new OpenApiGenerator(context, settings);
            }
            return Runner;
        }

    }
}
