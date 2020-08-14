using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.OpenApiGenerator.Maven;

using System;

namespace Cake.OpenApiGenerator.Settings
{
    /// <summary>
    /// Stores settings common to all OpenAPI generator commands
    /// </summary>
    public abstract class OpenApiGeneratorSettings : ToolSettings
    {
        /// <summary>
        /// Gets or sets the Maven package used to run this command
        /// </summary>
        /// 
        public MavenPackage Package { get; set; }

        /// <summary>
        /// Gets or sets the package file used to run this command
        /// </summary>
        /// <remarks></remarks>
        public FilePath PackageFile { get; set; }

        internal virtual ProcessArgumentBuilder AsArguments()
        {
            if (PackageFile == null)
                throw new ArgumentNullException(nameof(PackageFile));

            return new ProcessArgumentBuilder()
                .Append("-jar")
                .Append(PackageFile.FullPath);
        }

        internal static T From<T>(Action<T> configuration)
            where T : OpenApiGeneratorSettings, new()
        {
            T settings = new T();
            configuration.Invoke(settings);
            return settings;
        }
    }
}
