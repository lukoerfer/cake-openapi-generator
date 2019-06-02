using System;

using Cake.Common;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.OpenApi.Internal
{
    internal abstract class CommandLineTool : Tool
    {
        public override bool IsProvided => _executable != null;


        private readonly FilePath _executable;

        protected CommandLineTool(ICakeContext context, OpenApiSettings settings, FilePath executable) : base(context, settings)
        {
            _executable = executable;
        }

        public override void Generate(OpenApiGenerateOptions options)
        {
            ProcessArgumentBuilder arguments = GetBaseArguments()
                .Append("generate")
                .Append("-i")
                .Append(options.InputSource.ToString())
                .Append("-g")
                .Append(options.Generator)
                .Append("-o")
                .Append(options.OutputDirectory.FullPath);
            RunProcess(arguments);
        }

        public override void Validate(OpenApiValidateOptions options)
        {
            ProcessArgumentBuilder arguments = GetBaseArguments()
                .Append("validate")
                .Append("-i")
                .Append(options.InputSource.ToString());
            if (options.Recommend)
            {
                arguments.Append("--recommend");
            }
            RunProcess(arguments);
        }

        protected virtual ProcessArgumentBuilder GetBaseArguments()
        {
            return new ProcessArgumentBuilder();
        }

        private void RunProcess(ProcessArgumentBuilder arguments)
        {
            ProcessSettings process = SetupProcess();
            process.Arguments = arguments;
            _context.StartProcess(_executable, process);
        }

        protected virtual ProcessSettings SetupProcess()
        {
            return new ProcessSettings();
        }

    }
}
