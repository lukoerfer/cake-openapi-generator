using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Cake.OpenApiGenerator.Maven;

using System;

namespace Cake.OpenApiGenerator
{
    /// <summary>
    /// Provides a wrapper of the OpenAPI generator to Cake
    /// </summary>
    [CakeAliasCategory("OpenAPI")]
    [CakeNamespaceImport("Cake.OpenApiGenerator.Settings")]
    public static class OpenApiGeneratorAliases
    {
        /// <summary>
        /// Provides a wrapper around the OpenAPI generator tool
        /// </summary>
        /// <param name="context">The Cake context</param>
        /// <returns>A wrapper around the OpenAPI generator</returns>
        [CakePropertyAlias(Cache = true)]
        public static OpenApiGenerator OpenApiGenerator(this ICakeContext context)
        {
            var userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var mavenLocal = new DirectoryPath(userProfile).Combine(".m2/repository");
            var mavenCentral = new DefaultWebClient()
            {
                BaseAddress = "https://jcenter.bintray.com/"
            };

            var mavenClient = new MavenClient(context.FileSystem, mavenLocal, mavenCentral);
            return new OpenApiGenerator(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, mavenClient)
            {
                ToolPackage = new MavenPackage("org.openapitools", "openapi-generator-cli")
            };
        }

    }
}
