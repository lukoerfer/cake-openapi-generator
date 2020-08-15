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
    /// Wraps the functionality of the OpenAPI generator command line tool
    /// </summary>
    public class OpenApiGenerator : Tool<OpenApiGeneratorSettings>
    {
        /// <summary>
        /// Gets or sets the Maven package used to run the commands
        /// </summary>
        /// <remarks></remarks>
        public MavenCoordinates ToolPackage { get; set; }

        /// <summary>
        /// Gets or sets the package file used to run the commands
        /// </summary>
        public FilePath ToolPackageFile { get; set; }

        private readonly IMavenClient mavenClient;

        /// <summary>
        /// Creates a new wrapper around the OpenAPI generator
        /// </summary>
        /// <param name="fileSystem"></param>
        /// <param name="environment"></param>
        /// <param name="runner"></param>
        /// <param name="tools"></param>
        /// <param name="mavenClient"></param>
        public OpenApiGenerator(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner runner, IToolLocator tools, IMavenClient mavenClient)
            : base(fileSystem, environment, runner, tools)
        {
            this.mavenClient = mavenClient;
        }

        /// <summary>
        /// Sets the <see cref="MavenCoordinates.Version"/> of this wrapper using a shorthand notation
        /// </summary>
        /// <param name="version">A version supported by the OpenAPI generator</param>
        /// <returns>The same wrapper for method chaining</returns>
        public OpenApiGenerator this[string version]
        {
            get
            {
                ToolPackage.Version = version;
                return this;
            }
        }

        protected override string GetToolName() => "OpenAPI Generator";

        protected override IEnumerable<string> GetToolExecutableNames() => new string[] { "java", "java.exe" };

        /// <summary>
        /// Generates code based on an OpenAPI specification
        /// </summary>
        /// <param name="settings"></param>
        /// <returns>The same wrapper for method chaining</returns>
        public OpenApiGenerator Generate(OpenApiGeneratorGenerateSettings settings)
        {
            Run(settings);
            return this;
        }

        /// <summary>
        /// Generates code based on an OpenAPI specification
        /// </summary>
        /// <param name="configurator">An action that defines the settings</param>
        /// <returns>The same wrapper for method chaining</returns>
        public OpenApiGenerator Generate(Action<OpenApiGeneratorGenerateSettings> configurator)
        {
            Run(OpenApiGeneratorSettings.From(configurator));
            return this;
        }


        /// <summary>
        /// Validates an OpenAPI specification
        /// </summary>
        /// <param name="specification">The path to a file containing an OpenAPI specification</param>
        /// <param name="recommend">Whether to provide recommendations regarding the specification, defaults to false</param>
        /// <returns>The same wrapper for method chaining</returns>
        public OpenApiGenerator Validate(string specification, bool recommend = false)
        {
            Run(new OpenApiGeneratorValidateSettings()
            {
                Specification = specification,
                Recommend = recommend
            });
            return this;
        }

        /// <summary>
        /// Validates an OpenAPI specification
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public OpenApiGenerator Validate(OpenApiGeneratorValidateSettings settings)
        {
            Run(settings);
            return this;
        }

        /// <summary>
        /// Validates an OpenAPI specification
        /// </summary>
        /// <param name="configurator"></param>
        /// <returns></returns>
        public OpenApiGenerator Validate(Action<OpenApiGeneratorValidateSettings> configurator)
        {
            Run(OpenApiGeneratorSettings.From(configurator));
            return this;
        }

        /// <summary>
        /// Batch processes OpenAPI configuration files
        /// </summary>
        /// <param name="configurationFiles"></param>
        /// <returns></returns>
        public OpenApiGenerator Batch(params FilePath[] configurationFiles)
        {
            Run(new OpenApiGeneratorBatchSettings()
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
        public OpenApiGenerator Batch(OpenApiGeneratorBatchSettings settings)
        {
            Run(settings);
            return this;
        }

        /// <summary>
        /// Batch processes OpenAPI configuration files
        /// </summary>
        /// <param name="configurator"></param>
        /// <returns></returns>
        public OpenApiGenerator Batch(Action<OpenApiGeneratorBatchSettings> configurator)
        {
            Run(OpenApiGeneratorSettings.From(configurator));
            return this;
        }

        private void Run(OpenApiGeneratorSettings settings)
        {
            settings.ToolPackageFile = settings.ToolPackageFile ?? ToolPackageFile ?? mavenClient.Resolve(settings.ToolPackage ?? ToolPackage);
            Run(settings, settings.AsArguments());
        }

    }
}
