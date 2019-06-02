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
        /// Validates an OpenAPI specification in a specified file
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="recommend"></param>
        public void Validate(FilePath inputFile, bool recommend = false)
        {
            Validate(new Uri(inputFile.FullPath, UriKind.RelativeOrAbsolute), recommend);
        }

        /// <summary>
        /// Validates an OpenAPI specification at a specified URI
        /// </summary>
        /// <param name="inputSource"></param>
        /// <param name="recommend"></param>
        public void Validate(Uri inputSource, bool recommend = false)
        {
            OpenApiValidateOptions options = new OpenApiValidateOptions()
            {
                InputSource = inputSource,
                Recommend = recommend
            };
            Validate(options);
        }

        /// <summary>
        /// Validates an OpenAPI specification based on the specified options
        /// </summary>
        /// <param name="handler">A handler to configure the options</param>
        public void Validate(Action<OpenApiValidateOptions> handler)
        {
            OpenApiValidateOptions options = new OpenApiValidateOptions();
            handler.Invoke(options);
            Validate(options);
        }

        /// <summary>
        /// Validates an OpenAPI specification based on the specified options
        /// </summary>
        /// <param name="options"></param>
        public void Validate(OpenApiValidateOptions options)
        {
            _generator.Validate(options);
        }

        /// <summary>
        /// Generates OpenAPI files based on a specification file and a generator type at an output directory
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="generator"></param>
        /// <param name="outputDirectory"></param>
        public void Generate(FilePath inputFile, string generator, DirectoryPath outputDirectory)
        {
            Generate(new Uri(inputFile.FullPath, UriKind.RelativeOrAbsolute), generator, outputDirectory);
        }

        /// <summary>
        /// Generates OpenAPI files based on a specification at some URI and a generator type at an output directory
        /// </summary>
        /// <param name="inputSource"></param>
        /// <param name="generator"></param>
        /// <param name="outputDirectory"></param>
        public void Generate(Uri inputSource, string generator, DirectoryPath outputDirectory)
        {
            OpenApiGenerateOptions options = new OpenApiGenerateOptions()
            {
                InputSource = inputSource,
                Generator = generator,
                OutputDirectory = outputDirectory
            };
            Generate(options);
        }

        /// <summary>
        /// Generates OpenAPI files based on the specified options
        /// </summary>
        /// <param name="handler"></param>
        public void Generate(Action<OpenApiGenerateOptions> handler)
        {
            OpenApiGenerateOptions options = new OpenApiGenerateOptions();
            handler.Invoke(options);
            Generate(options);
        }

        /// <summary>
        /// Generates OpenAPI files based on the specified options
        /// </summary>
        /// <param name="options"></param>
        public void Generate(OpenApiGenerateOptions options)
        {
            _generator.Generate(options);
        }


    }
}
