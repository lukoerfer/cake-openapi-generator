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
    public abstract class OpenApiBaseSettings : ToolSettings
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual ProcessArgumentBuilder GetArguments()
        {
            if (PackageFile == null)
                throw new ArgumentNullException(nameof(PackageFile));

            return new ProcessArgumentBuilder()
                .Append("-jar")
                .Append(PackageFile.FullPath);
        }

        /// <summary>
        /// Creates settings from a configuration action
        /// </summary>
        /// <typeparam name="T">A specific OpenAPI generator settings class</typeparam>
        /// <param name="configuration">An action that configures the settings</param>
        /// <returns>The settings configured by the action</returns>
        public static T From<T>(Action<T> configuration)
            where T : OpenApiBaseSettings, new()
        {
            T settings = new T();
            configuration.Invoke(settings);
            return settings;
        }
    }
}
