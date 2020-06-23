using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

using System;

namespace Cake.OpenApiGenerator.Settings
{
    /// <summary>
    /// 
    /// </summary>
    public class OpenApiBatchSettings : OpenApiBaseSettings
    {
        public override string Command => "batch";

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>At least one file is required.</remarks>
        public FilePathCollection ConfigurationFiles { get; set; } = new FilePathCollection();

        public bool FailFast { get; set; }

        public DirectoryPath IncludesBaseDirectory { get; set; }

        public int? ThreadCount { get; set; }

        public DirectoryPath RootDirectory { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// The duration will be rounded to full minutes.
        /// Do not confuse with <see cref="ToolSettings.ToolTimeout"/> used by Cake.
        /// </remarks>
        public TimeSpan? Timeout { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Verbose { get; set; }

        protected override void ApplyParameters(ProcessArgumentBuilder args)
        {
            if (ConfigurationFiles == null || ConfigurationFiles.Count < 1)
                throw new InvalidOperationException();

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
