using System;
using System.Collections.Generic;

using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.OpenApiGenerator.Settings;

namespace Cake.CodeGen.OpenApi
{
    /// <summary>
    /// Wraps the functionality of the OpenAPI generator
    /// </summary>
    public class OpenApiGenerator : Tool<OpenApiBaseSettings>
    {
        /// <summary>
        /// Creates a new wrapper around the OpenAPI generator
        /// </summary>
        public OpenApiGenerator(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
            
        }

        /// <summary>
        /// Provides a wrapper around the OpenAPI generator in the specified version
        /// </summary>
        /// <param name="version">A version supported by the OpenAPI generator</param>
        /// <returns></returns>
        public OpenApiGenerator this[string version] => this;

        protected override string GetToolName() => $"OpenAPI Generator ({ "" ?? "latest" })";

        protected override IEnumerable<string> GetToolExecutableNames() => new string[] { "java", "java.exe" };

        /// <summary>
        /// Generates code based on an OpenAPI specification
        /// </summary>
        /// <param name="specificationFile">The path to a file containing an OpenAPI specification</param>
        /// <param name="generator">A generator identifier supported by the OpenAPI generator</param>
        /// <param name="outputDirectory">The path to a directory where the files should be generated</param>
        /// <returns>The same wrapper for method chaining</returns>
        public OpenApiGenerator Generate(FilePath specificationFile, string generator, DirectoryPath outputDirectory)
        {
            return Run(new OpenApiGenerateSettings()
            {
                SpecificationFile = specificationFile,
                Generator = generator,
                OutputDirectory = outputDirectory
            });
        }


        /// <summary>
        /// Generates code based on an OpenAPI specification
        /// </summary>
        /// <param name="settings">>A settings object for configuration</param>
        /// <returns>The same wrapper for method chaining</returns>
        public OpenApiGenerator Generate(OpenApiGenerateSettings settings)
        {
            return Run(settings);
        }

        /// <summary>
        /// Generates code based on an OpenAPI specification
        /// </summary>
        /// <param name="configurator">An action that can be used to configure the passed settings object</param>
        /// <returns>The same wrapper for method chaining</returns>
        public OpenApiGenerator Generate(Action<OpenApiGenerateSettings> configurator)
        {
            var settings = new OpenApiGenerateSettings();
            configurator?.Invoke(settings);
            return Run(settings);
        }


        /// <summary>
        /// Validates an OpenAPI specification from a file
        /// </summary>
        /// <param name="specificationFile">The path to a file containing an OpenAPI specification</param>
        /// <param name="recommend">Whether to provide recommendations regarding the specification, defaults to false</param>
        /// <returns>The same wrapper for method chaining</returns>
        public OpenApiGenerator Validate(FilePath specificationFile, bool recommend = false)
        {
            return Run(new OpenApiValidateSettings()
            {
                SpecificationFile = specificationFile,
                Recommend = recommend
            });
        }

        public OpenApiGenerator Validate(OpenApiValidateSettings settings)
        {
            return Run(settings);
        }

        public OpenApiGenerator Validate(Action<OpenApiValidateSettings> configurator)
        {
            var settings = new OpenApiValidateSettings();
            configurator?.Invoke(settings);
            return Run(settings);
        }

        public OpenApiGenerator Batch(params FilePath[] configurationFiles)
        {
            return Run(new OpenApiBatchSettings()
            {
                ConfigurationFiles = new FilePathCollection(configurationFiles)
            });
        }

        public OpenApiGenerator Batch(OpenApiBatchSettings settings)
        {
            return this;
        }

        public OpenApiGenerator Batch(Action<OpenApiBatchSettings> configurator)
        {
            return this;
        }

        private OpenApiGenerator Run(OpenApiBaseSettings settings)
        {
            settings.PackageFile = "";
            Run(settings, settings.GetArguments());
            return this;
        }

    }
}
