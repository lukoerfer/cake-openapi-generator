using Cake.Core;
using Cake.Core.IO;

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
            return base.AsArguments()
                .Append("batch")
                .AppendOptionalSwitch("--fail-fast", FailFast)
                .AppendOptionalSwitch("--includes-base-dir", IncludesBaseDirectory)
                .AppendOptionalSwitch("-r", ThreadCount)
                .AppendOptionalSwitch("--root-dir", RootDirectory)
                .AppendOptionalSwitch("--timeout", Timeout,
                    converter: value => Convert.ToInt32(value.TotalMinutes).ToString())
                .AppendOptionalSwitch("-v", Verbose)
                .AppendRange(ConfigurationFiles);
        }
    }
}
