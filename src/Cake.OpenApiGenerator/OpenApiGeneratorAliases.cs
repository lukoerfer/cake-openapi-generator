using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Cake.OpenApiGenerator.Maven;

using System;

namespace Cake.OpenApiGenerator
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
            var mavenCentral = new DefaultWebClient()
            {
                BaseAddress = "https://repo1.maven.org/maven2/"
            };
            var profile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var mavenLocal = new DirectoryPath(profile).Combine(".m2/repository");

            var mavenClient = new MavenClient(context.FileSystem, mavenLocal, mavenCentral);
            return new OpenApiGenerator(context, mavenClient)
            {
                Package = new MavenPackage("", "")
            };
        }

    }
}
