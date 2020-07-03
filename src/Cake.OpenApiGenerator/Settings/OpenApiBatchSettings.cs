using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

using System;

namespace Cake.OpenApiGenerator.Settings
{
    /// <summary>
    /// Stores settings for the OpenAPI generator command <c>batch</c>
    /// </summary>
    public class OpenApiBatchSettings : OpenApiBaseSettings
    {
        public override string Command => "batch";

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
        /// The base directory for includes may be overridden using <see cref="IncludesBaseDirectory"/>.
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

        protected override void ApplyParameters(ProcessArgumentBuilder args)
        {
            if (ConfigurationFiles == null)
                throw new ArgumentNullException(nameof(ConfigurationFiles));
            if (ConfigurationFiles.Count < 1)
                throw new ArgumentException(null, nameof(ConfigurationFiles));

            if (FailFast)
            {
                args.Append("--fail-fast");
            }
            if (IncludesBaseDirectory != null)
            {
                args.Append("--includes-base-dir", IncludesBaseDirectory.FullPath);
            }
            if (ThreadCount.HasValue)
            {
                args.Append("-r").Append(ThreadCount.ToString());
            }
            if (RootDirectory != null)
            {
                args.Append("--root-dir").Append(RootDirectory.FullPath);
            }
            if (Timeout.HasValue)
            {
                int minutes = (int)Timeout.Value.TotalMinutes;
                args.Append("--timeout").Append(minutes.ToString());
            }
            if (Verbose)
            {
                args.Append("--verbose");
            }

            foreach (var configurationFile in ConfigurationFiles)
            {
                args.Append(configurationFile.FullPath);
            }
        }
    }
}
