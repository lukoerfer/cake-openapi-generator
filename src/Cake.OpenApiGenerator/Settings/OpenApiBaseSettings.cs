using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

using System;

namespace Cake.OpenApiGenerator.Settings
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class OpenApiBaseSettings : ToolSettings
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract string Command { get; }

        internal FilePath PackageFile { get; set; }

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

        protected static Uri ConvertFilePathToUri(FilePath filePath)
        {
            return filePath != null ? new Uri(filePath.FullPath, UriKind.RelativeOrAbsolute) : null;
        }
    }
}
