using System;

using Cake.Core;
using Cake.Core.IO;

using Cake.OpenApi.Internal;
using Cake.OpenApi.Internal.Tools;

namespace Cake.OpenApi
{
    /// <summary>
    /// 
    /// </summary>
    public class OpenApiRunner
    {
        private readonly ICakeContext Context;

        private readonly Tool Tool;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="settings"></param>
        public OpenApiRunner(ICakeContext context, OpenApiSettings settings)
        {
            Context = context;
            // Tool = ToolResolution.Setup(context, settings).GetTool();
            Tool = new JavaTool(context, settings);
        }

        /// <summary>
        /// Validates an OpenAPI specification from a file
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="recommend"></param>
        public void Validate(FilePath specification = null, bool recommend = false)
        {
            Validate(specification?.ToUri(), recommend);
        }

        /// <summary>
        /// Validates an OpenAPI specification from a URI
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="recommend"></param>
        public void Validate(Uri specification = null, bool recommend = false)
        {
            OpenApiValidateOptions options = new OpenApiValidateOptions()
            {
                Specification = specification,
                Recommend = recommend
            };
            Validate(options);
        }

        /// <summary>
        /// Validates an OpenAPI specification
        /// </summary>
        /// <param name="handler">A handler to configure the options</param>
        public void Validate(Action<OpenApiValidateOptions> handler)
        {
            OpenApiValidateOptions options = new OpenApiValidateOptions();
            handler?.Invoke(options);
            Validate(options);
        }

        /// <summary>
        /// Validates an OpenAPI specification
        /// </summary>
        /// <param name="options"></param>
        public void Validate(OpenApiValidateOptions options)
        {
            if (options?.Specification == null)
            {
                throw new ArgumentException("Missing parameter for OpenAPI validation", "specification");
            }
            Tool.Validate(options);
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
        /// Generates OpenAPI files based on a specification from a URI
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="generator"></param>
        /// <param name="outputDirectory"></param>
        public void Generate(Uri specification = null, string generator = null, DirectoryPath outputDirectory = null)
        {
            OpenApiGenerateOptions options = new OpenApiGenerateOptions()
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
        /// <param name="handler"></param>
        public void Generate(Action<OpenApiGenerateOptions> handler)
        {
            OpenApiGenerateOptions options = new OpenApiGenerateOptions();
            handler?.Invoke(options);
            Generate(options);
        }

        /// <summary>
        /// Generates OpenAPI files
        /// </summary>
        /// <param name="options"></param>
        public void Generate(OpenApiGenerateOptions options)
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
