using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

using System;

namespace Cake.OpenApiGenerator.Settings
{
    /// <summary>
    /// Base for classes that store settings for OpenAPI generator commands
    /// </summary>
    public abstract class OpenApiBaseSettings : ToolSettings
    {
        /// <summary>
        /// Gets the OpenAPI generator command that uses these settings
        /// </summary>
        public abstract string Command { get; }

        internal FilePath PackageFile { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ProcessArgumentBuilder GetArguments()
        {
            if (PackageFile == null)
                throw new InvalidOperationException("");

            ProcessArgumentBuilder args = new ProcessArgumentBuilder()
                .Append("-jar")
                .Append(PackageFile.FullPath)
                .Append(Command);

            ApplyParameters(args);
            return args;
        }

        protected abstract void ApplyParameters(ProcessArgumentBuilder args);
    }
}
