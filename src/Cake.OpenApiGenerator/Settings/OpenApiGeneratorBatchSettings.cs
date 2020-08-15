using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

using System;

namespace Cake.OpenApiGenerator.Settings
{
    /// <summary>
    /// Stores settings for the OpenAPI generator command <c>batch</c>
    /// </summary>
    public class OpenApiGeneratorBatchSettings : OpenApiGeneratorSettings
    {

        /// <summary>
        /// Gets or sets the generator configuration files
        /// </summary>
        /// <remarks>
        /// At least one file is required.
        /// </remarks>
        public FilePathCollection ConfigurationFiles { get; set; } = new FilePathCollection();

        /// <summary>
        /// Gets or sets whether to fail fast on any errors
        /// </summary>
        public bool FailFast { get; set; }

        /// <summary>
        /// Gets or sets the base directory used for includes
        /// </summary>
        public DirectoryPath IncludesBaseDirectory { get; set; }

        /// <summary>
        /// Gets or sets the number of threads to use
        /// </summary>
        public int? ThreadCount { get; set; }

        /// <summary>
        /// Gets or sets the root directory used for output and includes
        /// </summary>
        /// <remarks>
        /// The root directory for includes may be overridden using <see cref="IncludesBaseDirectory"/>.
        /// </remarks>
        public DirectoryPath RootDirectory { get; set; }

        /// <summary>
        /// Gets or sets a execution timeout evaluated by the OpenAPI generator
        /// </summary>
        /// <remarks>
        /// The duration will be rounded to full minutes.
        /// Do not confuse with <see cref="ToolSettings.ToolTimeout"/>, which provides the same functionality but is evaluated by Cake.
        /// </remarks>
        public TimeSpan? Timeout { get; set; }

        /// <summary>
        /// Gets or sets whether verbose mode should be enabled
        /// </summary>
        public bool Verbose { get; set; }

        internal override ProcessArgumentBuilder AsArguments()
        {
            var arguments = base.AsArguments();

            if (ConfigurationFiles == null)
                throw new ArgumentNullException(nameof(ConfigurationFiles));
            if (ConfigurationFiles.Count < 1)
                throw new ArgumentException(null, nameof(ConfigurationFiles));

            arguments.Append("batch");

            if (FailFast)
            {
                arguments.Append("--fail-fast");
            }
            if (IncludesBaseDirectory != null)
            {
                arguments.Append("--includes-base-dir", IncludesBaseDirectory.FullPath);
            }
            if (ThreadCount.HasValue)
            {
                arguments.Append("-r").Append(ThreadCount.ToString());
            }
            if (RootDirectory != null)
            {
                arguments.Append("--root-dir").Append(RootDirectory.FullPath);
            }
            if (Timeout.HasValue)
            {
                int minutes = (int) Timeout.Value.TotalMinutes;
                arguments.Append("--timeout").Append(minutes.ToString());
            }
            if (Verbose)
            {
                arguments.Append("--verbose");
            }

            foreach (var configurationFile in ConfigurationFiles)
            {
                arguments.Append(configurationFile.FullPath);
            }

            return arguments;
        }
    }
}
