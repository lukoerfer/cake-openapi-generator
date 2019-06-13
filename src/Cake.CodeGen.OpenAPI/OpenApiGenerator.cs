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
        private readonly ICakeContext Context;

        private readonly Tool Tool;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="settings"></param>
        public OpenApiGenerator(ICakeContext context, OpenApiGeneratorSettings settings)
        {
            Context = context;
            // Tool = ToolResolution.Setup(context, settings).GetTool();
            Tool = new JavaTool(context, settings);
        }

        /// <summary>
        /// Generates OpenAPI files based on a specification from a file
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="generator"></param>
        /// <param name="outputDirectory"></param>
        public void Generate(FilePath specification = null, string generator = null, DirectoryPath outputDirectory = null)
        {
            Generate(specification?.ToUri(), generator, outputDirectory);
        }

        /// <summary>
        /// Generates OpenAPI files based on a specification from a file
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="generator"></param>
        /// <param name="outputDirectory"></param>
        public void Generate(FilePath specification = null, string generator = null, DirectoryPath outputDirectory = null, OpenApiGenerateSettings settings = null)
        {
            Generate(specification?.ToUri(), generator, outputDirectory);
        }

        /// <summary>
        /// Generates OpenAPI files based on a specification from a file
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="generator"></param>
        /// <param name="outputDirectory"></param>
        public void Generate(FilePath specification = null, string generator = null, DirectoryPath outputDirectory = null, Action<OpenApiGenerateSettings> configurator = null)
        {
            Generate(specification?.ToUri(), generator, outputDirectory);
        }

        /// <summary>
        /// Generates OpenAPI files based on a specification from a URI
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="generator"></param>
        /// <param name="outputDirectory"></param>
        public void Generate(Uri specification = null, string generator = null, DirectoryPath outputDirectory = null)
        {
            OpenApiGenerateSettings options = new OpenApiGenerateSettings()
            {
                Specification = specification,
                Generator = generator,
                OutputDirectory = outputDirectory
            };
            Generate(options);
        }

        /// <summary>
        /// Generates OpenAPI files based on a specification from a URI
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="generator"></param>
        /// <param name="outputDirectory"></param>
        public void Generate(Uri specification = null, string generator = null, DirectoryPath outputDirectory = null, OpenApiGenerateSettings settings = null)
        {
            OpenApiGenerateSettings options = new OpenApiGenerateSettings()
            {
                Specification = specification,
                Generator = generator,
                OutputDirectory = outputDirectory
            };
            Generate(options);
        }

        /// <summary>
        /// Generates OpenAPI files based on a specification from a URI
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="generator"></param>
        /// <param name="outputDirectory"></param>
        public void Generate(Uri specification = null, string generator = null, DirectoryPath outputDirectory = null, Action<OpenApiGenerateSettings> configurator = null)
        {
            OpenApiGenerateSettings options = new OpenApiGenerateSettings()
            {
                Specification = specification,
                Generator = generator,
                OutputDirectory = outputDirectory
            };
            Generate(options);
        }

        /// <summary>
        /// Generates OpenAPI files
        /// </summary>
        /// <param name="options"></param>
        public void Generate(OpenApiGenerateSettings options)
        {
            if (options?.Specification == null)
            {
                throw new ArgumentException("Missing parameter for OpenAPI generation", "specification");
            }
            if (options?.Generator == null)
            {
                throw new ArgumentException("Missing parameter for OpenAPI generation", "generator");
            }
            if (options?.OutputDirectory == null)
            {
                throw new ArgumentException("Missing parameter for OpenAPI generation", "outputDirectory");
            }
            Tool.Generate(options);
        }

    }
}
