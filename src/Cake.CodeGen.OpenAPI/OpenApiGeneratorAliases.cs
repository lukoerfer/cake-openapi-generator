using System;

using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.CodeGen.OpenApi
{
    /// <summary>
    /// Provides the functionality of the OpenAPI generator in Cake
    /// </summary>
    [CakeAliasCategory("OpenAPI")]
    public static class OpenApiGeneratorAliases
    {
        /// <summary>
        /// Provides an OpenAPI generator of the latest version
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [CakePropertyAlias(Cache = true)]
        public static OpenApiGenerator OpenApiGenerator(this ICakeContext context)
        {
            return new OpenApiGenerator(context);
        }

        /// <summary>
        /// Provides an OpenAPI generator for a specific version
        /// </summary>
        /// <param name="context">The Cake context</param>
        /// <param name="version">A version supported by the OpenAPI generator</param>
        /// <returns></returns>
        [CakeMethodAlias]
        public static OpenApiGenerator OpenApiGeneratorForVersion(this ICakeContext context, string version)
        {
            return new OpenApiGenerator(context, version);
        }

    }
}
