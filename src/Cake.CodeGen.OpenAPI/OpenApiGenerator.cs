using System;

using Cake.Core;
using Cake.Core.IO;

namespace Cake.CodeGen.OpenApi
{
    /// <summary>
    /// Wraps the functionality of the OpenAPI generator
    /// </summary>
    public class OpenApiGenerator
    {
        private readonly OpenApiGeneratorTool Tool;

        /// <summary>
        /// Creates a new wrapper around the OpenAPI generator
        /// </summary>
        /// <param name="context">The Cake context</param>
        /// <param name="version">A version supported by the OpenAPI generator, defaults to null meaning the latest version</param>
        public OpenApiGenerator(ICakeContext context, string version = null)
        {
            Tool = new OpenApiGeneratorTool(context, version);
        }

        /// <summary>
        /// Generates code based on an OpenAPI specification from a file
        /// </summary>
        /// <param name="specification">The path to a file containing an OpenAPI specification</param>
        /// <param name="generator">A generator identifier supported by the OpenAPI generator</param>
        /// <param name="outputDirectory">The path to a directory where the files should be generated</param>
        /// <param name="configurator">An action that can be used to configure the passed settings object</param>
        /// <returns>The same wrapper for method chaining</returns>
        public OpenApiGenerator Generate(FilePath specification, string generator, DirectoryPath outputDirectory, Action<OpenApiGenerateSettings> configurator)
        {
            return Generate(ConvertFilePathToUri(specification), generator, outputDirectory, configurator);
        }

        /// <summary>
        /// Generates code based on an OpenAPI specification from a file
        /// </summary>
        /// <param name="specification">The path to a file containing an OpenAPI specification</param>
        /// <param name="generator">A generator identifier supported by the OpenAPI generator</param>
        /// <param name="outputDirectory">The path to a directory where the files should be generated</param>
        /// <param name="settings">A settings object for configuration</param>
        /// <returns>The same wrapper for method chaining</returns>
        public OpenApiGenerator Generate(FilePath specification, string generator, DirectoryPath outputDirectory, OpenApiGenerateSettings settings = null)
        {
            return Generate(ConvertFilePathToUri(specification), generator, outputDirectory, settings);
        }

        /// <summary>
        /// Generates code based on an OpenAPI specification from a URI
        /// </summary>
        /// <param name="specification">A resource providing an OpenAPI specification</param>
        /// <param name="generator">A generator identifier supported by the OpenAPI generator</param>
        /// <param name="outputDirectory">The path to a directory where the files should be generated</param>
        /// <param name="configurator">An action that can be used to configure the passed settings object</param>
        /// <returns>The same wrapper for method chaining</returns>
        public OpenApiGenerator Generate(Uri specification, string generator, DirectoryPath outputDirectory, Action<OpenApiGenerateSettings> configurator)
        {
            OpenApiGenerateSettings settings = new OpenApiGenerateSettings();
            configurator?.Invoke(settings);
            return Generate(specification, generator, outputDirectory, settings);
        }

        /// <summary>
        /// Generates code based on an OpenAPI specification from a URI
        /// </summary>
        /// <param name="specification">A resource providing an OpenAPI specification</param>
        /// <param name="generator">A generator identifier supported by the OpenAPI generator</param>
        /// <param name="outputDirectory">The path to a directory where the files should be generated</param>
        /// <param name="settings">>A settings object for configuration</param>
        /// <returns>The same wrapper for method chaining</returns>
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
        /// <param name="specification">The path to a file containing an OpenAPI specification</param>
        /// <param name="recommend">Whether to provide recommendations regarding the specification, defaults to false</param>
        /// <returns>The same wrapper for method chaining</returns>
        public OpenApiGenerator Validate(FilePath specification, bool recommend = false)
        {
            return Validate(ConvertFilePathToUri(specification), recommend);
        }

        /// <summary>
        /// Validates an OpenAPI specification from a URI
        /// </summary>
        /// <param name="specification">A resource providing an OpenAPI specification</param>
        /// <param name="recommend">Whether to provide recommendations regarding the specification, defaults to false</param>
        /// <returns>The same wrapper for method chaining</returns>
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

        private static Uri ConvertFilePathToUri(FilePath filePath)
        {
            return filePath != null ? new Uri(filePath.FullPath, UriKind.RelativeOrAbsolute) : null;
        }

    }
}
