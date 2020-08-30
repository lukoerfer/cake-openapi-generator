using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.OpenApiGenerator.Maven;
using Cake.OpenApiGenerator.Settings;

using System;
using System.Collections.Generic;

namespace Cake.OpenApiGenerator
{
    /// <summary>
    /// Wraps the functionality of the OpenAPI generator command line tool
    /// </summary>
    public class OpenApiGenerator : Tool<OpenApiGeneratorSettings>
    {
        /// <summary>
        /// Gets or sets the tool path
        /// </summary>
        /// <remarks></remarks>
        public FilePath ToolPath { get; set; }

        /// <summary>
        /// Gets or sets the Maven package used to run the commands
        /// </summary>
        public MavenPackage ToolPackage { get; set; }

        /// <summary>
        /// Gets or sets the package file used to run the commands
        /// </summary>
        public FilePath ToolPackagePath { get; set; }

        private readonly IMavenClient mavenClient;

        /// <summary>
        /// Creates a new wrapper around the OpenAPI generator
        /// </summary>
        /// <param name="fileSystem">A file system</param>
        /// <param name="environment">A Cake environment</param>
        /// <param name="processRunner">A process runner</param>
        /// <param name="toolLocator">A tool locator</param>
        /// <param name="mavenClient">A Maven client</param>
        public OpenApiGenerator(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator toolLocator, IMavenClient mavenClient)
            : base(fileSystem, environment, processRunner, toolLocator)
        {
            this.mavenClient = mavenClient;
        }

        /// <summary>
        /// Sets the <see cref="MavenPackage.Version"/> of the <see cref="ToolPackage"/> using a shortcut notation
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public OpenApiGenerator this[string version]
        {
            get
            {
                if (ToolPackage != null)
                {
                    ToolPackage.Version = version;
                }
                return this;
            }
        }

        protected override string GetToolName() => "OpenAPI Generator";

        protected override IEnumerable<string> GetToolExecutableNames() => new string[] { "java", "java.exe" };

        /// <summary>
        /// Runs an OpenAPI generator <c>generate</c> command
        /// </summary>
        /// <param name="settings">A collection of parameters for the <c>generate</c> command</param>
        /// <returns>The same wrapper for method chaining</returns>
        public OpenApiGenerator Generate(OpenApiGeneratorGenerateSettings settings)
        {
            Run(settings);
            return this;
        }

        /// <summary>
        /// Runs an OpenAPI generator <c>generate</c> command
        /// </summary>
        /// <param name="configurator">An action that configures the parameters for the <c>generate</c> command</param>
        /// <returns>The same wrapper for method chaining</returns>
        public OpenApiGenerator Generate(Action<OpenApiGeneratorGenerateSettings> configurator)
        {
            Run(OpenApiGeneratorSettings.ConfiguredBy(configurator));
            return this;
        }


        /// <summary>
        /// Runs an OpenAPI generator <c>validate</c> command
        /// </summary>
        /// <param name="specification">The location of the OpenAPI specification</param>
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
        /// Runs an OpenAPI generator <c>batch</c> command
        /// </summary>
        /// <param name="configurationFiles">Any number of generator configuration files</param>
        /// <returns>The same wrapper for method chaining</returns>
        public OpenApiGenerator Batch(params FilePath[] configurationFiles)
        {
            Run(new OpenApiGeneratorBatchSettings()
            {
                ConfigurationFiles = new FilePathCollection(configurationFiles)
            });
            return this;
        }

        /// <summary>
        /// Runs an OpenAPI generator <c>batch</c> command
        /// </summary>
        /// <param name="settings">A collection of parameters for the <c>batch</c> command</param>
        /// <returns>The same wrapper for method chaining</returns>
        public OpenApiGenerator Batch(OpenApiGeneratorBatchSettings settings)
        {
            Run(settings);
            return this;
        }

        /// <summary>
        /// Runs an OpenAPI generator <c>batch</c> command
        /// </summary>
        /// <param name="configurator">An action that configures the parameters for the <c>batch</c> command</param>
        /// <returns>The same wrapper for method chaining</returns>
        public OpenApiGenerator Batch(Action<OpenApiGeneratorBatchSettings> configurator)
        {
            Run(OpenApiGeneratorSettings.ConfiguredBy(configurator));
            return this;
        }

        private void Run(OpenApiGeneratorSettings settings)
        {
            settings.ToolPath = settings.ToolPath ?? ToolPath;
            settings.ToolPackagePath = settings.ToolPackagePath ?? ToolPackagePath
                ?? mavenClient.Resolve(settings.ToolPackage ?? ToolPackage);
            Run(settings, settings.AsArguments());
        }

    }
}
