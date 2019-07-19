using System;

using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.CodeGen.OpenApi
{
    /// <summary>
    /// Provides a wrapper to invoke the OpenAPI generator
    /// </summary>
    [CakeAliasCategory("OpenAPI")]
    public static class OpenApiGeneratorAliases
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [CakePropertyAlias(Cache = true)]
        public static OpenApiGenerator OpenApiGenerator(this ICakeContext context)
        {
            return new OpenApiGenerator(context);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        [CakeMethodAlias]
        public static OpenApiGenerator OpenApiGeneratorWithVersion(this ICakeContext context, string version)
        {
            return new OpenApiGenerator(context, version);
        }

    }
}
