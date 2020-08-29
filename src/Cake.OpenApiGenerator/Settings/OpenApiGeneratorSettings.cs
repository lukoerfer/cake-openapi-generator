using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.OpenApiGenerator.Extensions;
using Cake.OpenApiGenerator.Maven;

using System;
using System.Collections.Generic;
using System.Linq;

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
        /// Gets or sets the path to the package file used to run this command
        /// </summary>
        public FilePath ToolPackagePath { get; set; }

        internal virtual ProcessArgumentBuilder AsArguments()
        {
            return new ProcessArgumentBuilder()
                .AppendOptionalSwitch("-jar", ToolPackagePath);
        }

        internal static T ConfiguredBy<T>(Action<T> configuration)
            where T : OpenApiGeneratorSettings, new()
        {
            T settings = new T();
            configuration.Invoke(settings);
            return settings;
        }

        internal static string AsArguments<T>(List<T> values) => string.Join(",", values);

        internal static string AsArguments<T1, T2>(Dictionary<T1, T2> values) => string.Join(",", values.Select(kvp => kvp.Key + "=" + kvp.Value));
    }
}
