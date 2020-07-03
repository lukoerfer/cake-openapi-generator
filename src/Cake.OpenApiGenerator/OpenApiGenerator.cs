using System;
using System.Collections.Generic;

using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.OpenApiGenerator;
using Cake.OpenApiGenerator.Settings;

namespace Cake.CodeGen.OpenApi
{
    /// <summary>
    /// Wraps the functionality of the OpenAPI generator
    /// </summary>
    public class OpenApiGenerator : Tool<OpenApiBaseSettings>
    {
        /// <summary>
        /// Gets or sets the version of the OpenAPI generator
        /// </summary>
        public string Version { get; set; }

        private readonly MavenPackage mavenPackage;

        /// <summary>
        /// Creates a new wrapper around the OpenAPI generator
        /// </summary>
        public OpenApiGenerator(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, MavenPackage mavenPackage)
            : base(fileSystem, environment, processRunner, tools)
        {
            this.mavenPackage = mavenPackage;
        }

        /// <summary>
        /// Sets the <see cref="Version"/> of the wrapper using a shorthand notation
        /// </summary>
        /// <param name="version">A version supported by the OpenAPI generator</param>
        /// <returns>The same wrapper for method chaining</returns>
        public OpenApiGenerator this[string version]
        {
            get
            {
                Version = version;
                return this;
            }
        }

        protected override string GetToolName() => $"OpenAPI Generator ({ Version ?? "latest" })";

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
            Run(new OpenApiGenerateSettings()
            {
                SpecificationFile = specificationFile,
                Generator = generator,
                OutputDirectory = outputDirectory
            });
            return this;
        }


        /// <summary>
        /// Generates code based on an OpenAPI specification
        /// </summary>
        /// <param name="settings"></param>
        /// <returns>The same wrapper for method chaining</returns>
        public OpenApiGenerator Generate(OpenApiGenerateSettings settings)
        {
            Run(settings);
            return this;
        }

        /// <summary>
        /// Generates code based on an OpenAPI specification
        /// </summary>
        /// <param name="configurator">An action that defines the settings</param>
        /// <returns>The same wrapper for method chaining</returns>
        public OpenApiGenerator Generate(Action<OpenApiGenerateSettings> configurator)
        {
            Run(configurator.Evaluate());
            return this;
        }


        /// <summary>
        /// Validates an OpenAPI specification
        /// </summary>
        /// <param name="specificationFile">The path to a file containing an OpenAPI specification</param>
        /// <param name="recommend">Whether to provide recommendations regarding the specification, defaults to false</param>
        /// <returns>The same wrapper for method chaining</returns>
        public OpenApiGenerator Validate(FilePath specificationFile, bool recommend = false)
        {
            Run(new OpenApiValidateSettings()
            {
                SpecificationFile = specificationFile,
                Recommend = recommend
            });
            return this;
        }

        /// <summary>
        /// Validates an OpenAPI specification
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public OpenApiGenerator Validate(OpenApiValidateSettings settings)
        {
            Run(settings);
            return this;
        }

        /// <summary>
        /// Validates an OpenAPI specification
        /// </summary>
        /// <param name="configurator"></param>
        /// <returns></returns>
        public OpenApiGenerator Validate(Action<OpenApiValidateSettings> configurator)
        {
            Run(configurator.Evaluate());
            return this;
        }

        /// <summary>
        /// Batch processes OpenAPI configuration files
        /// </summary>
        /// <param name="configurationFiles"></param>
        /// <returns></returns>
        public OpenApiGenerator Batch(params FilePath[] configurationFiles)
        {
            Run(new OpenApiBatchSettings()
            {
                ConfigurationFiles = new FilePathCollection(configurationFiles)
            });
            return this;
        }

        /// <summary>
        /// Batch processes OpenAPI configuration files
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public OpenApiGenerator Batch(OpenApiBatchSettings settings)
        {
            Run(settings);
            return this;
        }

        /// <summary>
        /// Batch processes OpenAPI configuration files
        /// </summary>
        /// <param name="configurator"></param>
        /// <returns></returns>
        public OpenApiGenerator Batch(Action<OpenApiBatchSettings> configurator)
        {
            Run(configurator.Evaluate());
            return this;
        }

        private void Run(OpenApiBaseSettings settings)
        {
            settings.PackageFile = mavenPackage.GetJarFile(Version);
            Run(settings, settings.GetArguments());
        }

    }
}
