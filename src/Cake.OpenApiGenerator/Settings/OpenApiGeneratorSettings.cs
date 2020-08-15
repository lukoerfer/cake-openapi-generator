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
        public MavenCoordinates ToolPackage { get; set; }

        /// <summary>
        /// Gets or sets the package file used to run this command
        /// </summary>
        public FilePath ToolPackageFile { get; set; }

        internal virtual ProcessArgumentBuilder AsArguments()
        {
            if (ToolPackageFile == null)
                throw new ArgumentNullException(nameof(ToolPackageFile));

            return new ProcessArgumentBuilder()
                .Append("-jar")
                .Append(ToolPackageFile.FullPath);
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
