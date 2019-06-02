using Cake.ArgumentHelpers;
using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.OpenApi
{
    /// <summary>
    /// 
    /// </summary>
    [CakeAliasCategory("OpenAPI")]
    public static class OpenApiAliases
    {
        private static OpenApiSettings _settings;

        private static OpenApiAddin _addin;

        /// <summary>
        /// 
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
        /// 
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
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="settings"></param>
        [CakeMethodAlias]
        public static void SetupOpenAPI(this ICakeContext context, OpenApiSettings settings)
        {
            _settings = settings;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [CakePropertyAlias]
        public static OpenApiAddin OpenAPI(this ICakeContext context)
        {
            if (_addin == null)
            {
                _settings = _settings ?? new OpenApiSettings();
                ApplyEnvironmentSettings(context);
                _addin = new OpenApiAddin(context, _settings);
            }
            return _addin;
        }

        private static void ApplyEnvironmentSettings(ICakeContext context)
        {
            string tool = context.ArgumentOrEnvironmentVariable("OPENAPI_TOOL", "CAKE_", null);
            if (tool != null)
            {
                _settings.Tool = tool;
            }
            string version = context.ArgumentOrEnvironmentVariable("OPENAPI_VERSION", "CAKE_", null);
            if (version != null)
            {
                _settings.Version = version;
            }
            string endpoint = context.ArgumentOrEnvironmentVariable("OPENAPI_ENDPOINT", "CAKE_", null);
            if (endpoint != null)
            {
                _settings.Endpoint = new Uri(endpoint);
            }
        }
    }
}
