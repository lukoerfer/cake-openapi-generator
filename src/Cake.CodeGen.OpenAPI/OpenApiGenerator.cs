using System;

using Cake.Core;
using Cake.Core.IO;

using Cake.CodeGen.OpenApi.Internal;
using Cake.CodeGen.OpenApi.Internal.Tools;

namespace Cake.CodeGen.OpenApi
{
    /// <summary>
    /// 
    /// </summary>
    public class OpenApiGenerator
    {
        private readonly OpenApiGeneratorTool Tool;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="settings"></param>
        public OpenApiGenerator(ICakeContext context, string version = null)
        {
            Tool = new OpenApiGeneratorTool(context, version);
        }

        /// <summary>
        /// Generates code based on an OpenAPI specification from a file
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="generator"></param>
        /// <param name="outputDirectory"></param>
        public OpenApiGenerator Generate(FilePath specification, string generator, DirectoryPath outputDirectory, Action<OpenApiGenerateSettings> configurator)
        {
            return Generate(specification?.ToUri(), generator, outputDirectory, configurator);
        }

        /// <summary>
        /// Generates code based on an OpenAPI specification from a file
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="generator"></param>
        /// <param name="outputDirectory"></param>
        public OpenApiGenerator Generate(FilePath specification, string generator, DirectoryPath outputDirectory, OpenApiGenerateSettings settings = null)
        {
            return Generate(specification?.ToUri(), generator, outputDirectory, settings);
        }

        /// <summary>
        /// Generates code based on an OpenAPI specification from a URI
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="generator"></param>
        /// <param name="outputDirectory"></param>
        public OpenApiGenerator Generate(Uri specification, string generator, DirectoryPath outputDirectory, Action<OpenApiGenerateSettings> configurator)
        {
            OpenApiGenerateSettings settings = new OpenApiGenerateSettings();
            configurator?.Invoke(settings);
            return Generate(specification, generator, outputDirectory, settings);
        }

        /// <summary>
        /// Generates code based on an OpenAPI specification from a URI
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="generator"></param>
        /// <param name="outputDirectory"></param>
        public OpenApiGenerator Generate(Uri specification, string generator, DirectoryPath outputDirectory, OpenApiGenerateSettings settings = null)
        {
            var args = new ProcessArgumentBuilder();
            args.Append("generate");
            args.Append("-i").Append(specification.ToString());
            args.Append("-g").Append(generator);
            args.Append("-o").Append(outputDirectory.FullPath);
            args.Append(settings?.AsArguments().Render() ?? string.Empty);
            Tool.Run(args);
            return this;
        }

        /// <summary>
        /// Validates an OpenAPI specification from a file
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="recommend"></param>
        /// <returns></returns>
        public OpenApiGenerator Validate(FilePath specification, bool recommend = false)
        {
            return Validate(specification.ToUri(), recommend);
        }

        /// <summary>
        /// Validates an OpenAPI specification from a URI
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="recommend"></param>
        /// <returns></returns>
        public OpenApiGenerator Validate(Uri specification, bool recommend = false)
        {
            var args = new ProcessArgumentBuilder();
            args.Append("validate");
            args.Append("-i").Append(specification.ToString());
            if (recommend)
            {
                args.Append("--recommend");
            }
            Tool.Run(args);
            return this;
        }

    }
}
