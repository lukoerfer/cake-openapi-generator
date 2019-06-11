using System.Collections.Generic;
using System.Linq;

using Cake.Common;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.OpenApi.Internal.Tools
{
    internal abstract class CommandLineTool : Tool
    {
        public override bool IsProvided => Executable != null;

        private readonly FilePath Executable;

        protected CommandLineTool(ICakeContext context, OpenApiSettings settings, FilePath executable) : base(context, settings)
        {
            Executable = executable;
        }

        public override void Generate(OpenApiGenerateOptions options)
        {
            ProcessArgumentBuilder arguments = GetArguments()
                .Append("generate")
                .Append("-i")
                .Append(options.Specification.ToString())
                .Append("-g")
                .Append(options.Generator)
                .Append("-o")
                .Append(options.OutputDirectory.FullPath);
            if (options.ConfigurationFile != null)
            {
                arguments.Append("-c").Append(options.ConfigurationFile.ToString());
            } 
            // Ignore additional properties if configuration file is specified
            else if (options.AdditionalProperties?.Count > 0)
            {
                arguments.AppendSwitch("additional-properties", GetArgumentDictionaryString(options.AdditionalProperties));
            }
            if (options.ImportMappings?.Count > 0)
            {
                arguments.AppendSwitch("import-mappings", GetArgumentDictionaryString(options.ImportMappings));
            }
            if (options.TypeMappings?.Count > 0)
            {
                arguments.AppendSwitch("type-mappings", GetArgumentDictionaryString(options.TypeMappings));
            }
            RunProcess(arguments);
        }

        public override void Validate(OpenApiValidateOptions options)
        {
            ProcessArgumentBuilder arguments = GetArguments()
                .Append("validate")
                .Append("-i")
                .Append(options.Specification.ToString());
            if (options.Recommend)
            {
                arguments.Append("--recommend");
            }
            RunProcess(arguments);
        }

        private void RunProcess(ProcessArgumentBuilder arguments)
        {
            ProcessSettings process = GetProcessSettings();
            process.Arguments = arguments;
            Context.StartProcess(Executable, process);
        }

        protected virtual ProcessArgumentBuilder GetArguments()
        {
            return new ProcessArgumentBuilder();
        }

        protected virtual ProcessSettings GetProcessSettings()
        {
            return new ProcessSettings();
        }

        private string GetArgumentDictionaryString(Dictionary<string, string> arguments)
        {
            return string.Join(",", arguments?.Select(entry => $"{entry.Key}={entry.Value}"));
        }

    }
}
