using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

using System;

namespace Cake.OpenApiGenerator.Settings
{
    /// <summary>
    /// Stores settings for the OpenAPI generator command <c>batch</c>
    /// </summary>
    public class OpenApiBatchSettings : OpenApiSettings
    {

        /// <summary>
        /// Gets or sets the configuration files used for batch processing
        /// </summary>
        /// <remarks>
        /// At least one file is required.
        /// </remarks>
        public FilePathCollection ConfigurationFiles { get; set; } = new FilePathCollection();

        /// <summary>
        /// Gets or sets whether the batch command should fail on the first error
        /// </summary>
        public bool FailFast { get; set; }

        /// <summary>
        /// Gets or sets the base directory for includes
        /// </summary>
        public DirectoryPath IncludesBaseDirectory { get; set; }

        /// <summary>
        /// Gets or sets the number of threads to use
        /// </summary>
        public int? ThreadCount { get; set; }

        /// <summary>
        /// Gets or sets the root directory for output and includes
        /// </summary>
        /// <remarks>
        /// The root directory for includes may be overridden using <see cref="IncludesBaseDirectory"/>.
        /// </remarks>
        public DirectoryPath RootDirectory { get; set; }

        /// <summary>
        /// Gets or sets a timeout evaluated by the OpenAPI generator
        /// </summary>
        /// <remarks>
        /// The duration will be rounded to full minutes.
        /// Do not confuse with <see cref="ToolSettings.ToolTimeout"/> evaluated by Cake.
        /// </remarks>
        public TimeSpan? Timeout { get; set; }

        /// <summary>
        /// Gets or sets whether all log messages should be printed
        /// </summary>
        public bool Verbose { get; set; }

        public override ProcessArgumentBuilder AsArguments()
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
                int minutes = (int)Timeout.Value.TotalMinutes;
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
