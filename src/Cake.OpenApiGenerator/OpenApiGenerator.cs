using System;
using System.Collections.Generic;

using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.OpenApiGenerator.Maven;
using Cake.OpenApiGenerator.Settings;

namespace Cake.OpenApiGenerator
{
    /// <summary>
    /// Wraps the functionality of the OpenAPI generator
    /// </summary>
    public class OpenApiGenerator : Tool<OpenApiBaseSettings>
    {
        /// <summary>
        /// 
        /// </summary>
        public MavenPackage Package { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public FilePath PackageFile { get; set; }

        private readonly IMavenClient mavenClient;

        /// <summary>
        /// Creates a new wrapper around the OpenAPI generator
        /// </summary>
        public OpenApiGenerator(ICakeContext context, IMavenClient mavenClient)
            : base(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools)
        {
            this.mavenClient = mavenClient;
        }

        /// <summary>
        /// Sets the <see cref="MavenPackage.Version"/> of this wrapper using a shorthand notation
        /// </summary>
        /// <param name="version">A version supported by the OpenAPI generator</param>
        /// <returns>The same wrapper for method chaining</returns>
        public OpenApiGenerator this[string version]
        {
            get
            {
                if (Package != null)
                {
                    Package.Version = version;
                }
                return this;
            }
        }

        protected override string GetToolName() => "OpenAPI Generator";

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
            Run(OpenApiBaseSettings.From(configurator));
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
            Run(OpenApiBaseSettings.From(configurator));
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
            Run(OpenApiBaseSettings.From(configurator));
            return this;
        }

        private void Run(OpenApiBaseSettings settings)
        {
            if (settings.PackageFile == null)
            {
                
            }
            Run(settings, settings.GetArguments());
        }

    }
}
