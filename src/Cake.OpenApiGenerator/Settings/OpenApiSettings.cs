using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.OpenApiGenerator.Maven;

using System;

namespace Cake.OpenApiGenerator.Settings
{
    /// <summary>
    /// Base for classes that store settings for OpenAPI generator commands
    /// </summary>
    public abstract class OpenApiSettings : ToolSettings
    {
        /// <summary>
        /// 
        /// </summary>
        public MavenPackage Package { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public FilePath PackageFile { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual ProcessArgumentBuilder AsArguments()
        {
            if (PackageFile == null)
                throw new ArgumentNullException(nameof(PackageFile));

            return new ProcessArgumentBuilder()
                .Append("-jar")
                .Append(PackageFile.FullPath);
        }

        public static T From<T>(Action<T> configuration) where T : OpenApiSettings, new()
        {
            T settings = new T();
            configuration.Invoke(settings);
            return settings;
        }
    }
}
