using System;

using Cake.Core;
using Cake.Core.IO;
using Cake.Common.IO;

using Cake.OpenApi.Internal;

namespace Cake.OpenApi
{
    /// <summary>
    /// 
    /// </summary>
    public class OpenApiAddin
    {
        private readonly ICakeContext _context;

        private readonly Tool _generator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="settings"></param>
        public OpenApiAddin(ICakeContext context, OpenApiSettings settings)
        {
            _context = context;
            // _generator = GeneratorResolution.Init(context, settings).Get();
            _generator = new JavaTool(context, settings);
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
            _generator.Validate(options);
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
            _generator.Generate(options);
        }

    }
}
