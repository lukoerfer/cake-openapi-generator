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
        /// Provides a wrapper around the OpenAPI generator
        /// </summary>
        /// <param name="context">The Cake context</param>
        /// <returns>A wrapper around the OpenAPI generator</returns>
        [CakePropertyAlias(Cache = true)]
        public static OpenApiGenerator OpenApiGenerator(this ICakeContext context)
        {
            return new OpenApiGenerator(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
        }

    }
}
