using System;
using System.Collections.Generic;
using System.Linq;

using Cake.Core;
using Cake.Core.IO;

namespace Cake.OpenApiGenerator.Settings
{
    /// <summary>
    /// Stores settings for the OpenAPI generator command <c>generate</c>
    /// </summary>
    public class OpenApiGeneratorGenerateSettings : OpenApiGeneratorSettings
    {
        /// <summary>
        /// Gets or sets the location of the OpenAPI specification, as URL or file
        /// </summary>
        /// <remarks>This parameter is required.</remarks>
        public string Specification { get; set; }

        /// <summary>
        /// Gets or sets the generator to use
        /// </summary>
        /// <remarks>This parameter is required.</remarks>
        public string Generator { get; set; }

        /// <summary>
        /// Gets or sets the output directory
        /// </summary>
        /// <remarks>This parameter is required.</remarks>
        public DirectoryPath OutputDirectory { get; set; }

        /// <summary>
        /// Gets or sets the path to a configuration file with generator-specific properties
        /// </summary>
        /// <remarks>If this parameter is defined, <see cref="AdditionalProperties"/> will be ignored</remarks>
        public FilePath ConfigurationFile { get; set; }

        /// <summary>
        /// Gets or sets generator-specific properties
        /// </summary>
        /// <remarks>If <see cref="ConfigurationFile"/> is defined, this parameter will be ignored</remarks>
        public Dictionary<string, string> AdditionalProperties { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// Gets or sets authorization headers when fetching the OpenAPI definitions remotely
        /// </summary>
        /// <remarks>Pass in a URL-encoded string of <c>name:header</c> with a comma separating multiple values</remarks>
        public string Authorization { get; set; }

        /// <summary>
        /// Gets or sets a suffix that will be appended to all API names
        /// </summary>
        public string ApiNameSuffix { get; set; }

        /// <summary>
        /// Gets or sets the package for generated API classes
        /// </summary>
        public string ApiPackage { get; set; }

        /// <summary>
        /// Gets or sets the artifact identifier in the generated <c>pom.xml</c>
        /// </summary>
        /// <remarks>This also becomes part of the generated library's filename</remarks>
        public string ArtifactId { get; set; }

        /// <summary>
        /// Gets or sets the artifact version in the generated <c>pom.xml</c>
        /// </summary>
        /// <remarks>This also becomes part of the generated library's filename</remarks>
        public string ArtifactVersion { get; set; }

        /// <summary>
        /// Gets or sets whether to just try things out and report on potential changes (without actually making changes)
        /// </summary>
        public bool DryRun { get; set; }

        /// <summary>
        /// Gets or sets the templating engine
        /// </summary>
        public string TemplatingEngine { get; set; }

        /// <summary>
        /// Gets or sets whether to enable post-processing file using environment variables
        /// </summary>
        public bool EnablePostProcessFile { get; set; }

        /// <summary>
        /// Gets or sets whether to generate a model implementation for aliases to map and array schemas
        /// </summary>
        public bool GenerateAliasAsModel { get; set; }

        /// <summary>
        /// Gets or sets the Git host
        /// </summary>
        public string GitHost { get; set; }

        /// <summary>
        /// Gets or sets the Git repository identifier
        /// </summary>
        public string GitRepository { get; set; }

        /// <summary>
        /// Gets or sets the Git user identifier
        /// </summary>
        public string GitUser { get; set; }

        /// <summary>
        /// Gets or sets global properties
        /// </summary>
        public Dictionary<string, string> GlobalProperties { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// Gets or sets the group identifier in the generated <c>pom.xml</c>
        /// </summary>
        public string GroupId { get; set; }

        /// <summary>
        /// Gets or sets the HTTP user agent
        /// </summary>
        public string HttpUserAgent { get; set; }

        /// <summary>
        /// Gets or sets an override location for the <c>.openapi-generator-ignore</c> file
        /// </summary>
        public FilePath IgnoreFile { get; set; }

        /// <summary>
        /// Gets or sets mappings between a given class and the import that should be used for that class
        /// </summary>
        public Dictionary<string, string> ImportMappings { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// Gets or sets instantiation type mappings
        /// </summary>
        public List<string> InstantiationTypes { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the root package for generated code
        /// </summary>
        public string InvokerPackage { get; set; }

        /// <summary>
        /// Gets or sets additional language specific primitive types
        /// </summary>
        public List<string> LanguageSpecificPrimitives { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the library template (sub-template)
        /// </summary>
        public string Library { get; set; }

        /// <summary>
        /// Gets or sets whether to write all log messages (not just errors) to <c>STDOUT</c>
        /// </summary>
        public bool LogToStandardError { get; set; }

        /// <summary>
        /// Gets or sets whether to only write output files that have changed
        /// </summary>
        public bool MinimalUpdate { get; set; }

        /// <summary>
        /// Gets or sets the prefix that will be prepended to all model names
        /// </summary>
        public string ModelNamePrefix { get; set; }

        /// <summary>
        /// Gets or sets the suffix that will be appended to all model names
        /// </summary>
        public string ModelNameSuffix { get; set; }

        /// <summary>
        /// Gets or sets the package for generated models
        /// </summary>
        public string ModelPackage { get; set; }

        /// <summary>
        /// Gets or sets the package for generated classes (where supported)
        /// </summary>
        public string PackageName { get; set; }

        /// <summary>
        /// Gets or sets the release note
        /// </summary>
        /// <remarks>Defaults to <c>'Minor update'</c>.</remarks>
        public string ReleaseNote { get; set; }

        /// <summary>
        /// Gets or sets whether to remove the prefix of <c>operationId</c>
        /// </summary>
        public bool RemoveOperationIdPrefix { get; set; }

        /// <summary>
        /// Gets or sets how a reserved name should be escaped to
        /// </summary>
        public Dictionary<string, string> ReservedWordsMappings { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// Gets or sets server variables overrides for specification documents which support variable templating of servers
        /// </summary>
        public Dictionary<string, string> ServerVariables { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// Gets or sets whether the existing files should be overwritten during the generation
        /// </summary>
        public bool SkipOverwrite { get; set; }

        /// <summary>
        /// Gets or sets whether to skip the default behavior of validating an input specification
        /// </summary>
        public bool SkipValidation { get; set; }

        /// <summary>
        /// Gets or sets whether <c>'MUST'</c> and <c>'SHALL'</c> wording in OpenAPI spec is strictly adhered to
        /// </summary>
        /// <remarks>When false, no fixes will be applied to documents which pass validation but don't follow the spec</remarks>
        public bool StrictSpec { get; set; }

        /// <summary>
        /// Gets or sets the folder containing the template files
        /// </summary>
        public DirectoryPath TemplateDirectory { get; set; }

        /// <summary>
        /// Gets or sets mappings between OpenAPI spec types and generated code types
        /// </summary>
        public Dictionary<string, string> TypeMappings { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// Gets or sets whether to run in verbose mode
        /// </summary>
        public bool Verbose { get; set; }

        internal override ProcessArgumentBuilder AsArguments()
        {
            var arguments = base.AsArguments();

            if (Specification == null)
                throw new ArgumentNullException(nameof(Specification));
            if (Generator == null)
                throw new ArgumentNullException(nameof(Generator));
            if (OutputDirectory == null)
                throw new ArgumentNullException(nameof(OutputDirectory));

            arguments.Append("generate");

            arguments.Append("-i").Append(Specification);
            arguments.Append("-g").Append(Generator);
            arguments.Append("-o").Append(OutputDirectory.FullPath);

            if (ConfigurationFile != null)
            {
                arguments.Append("-c").Append(ConfigurationFile.FullPath);
            }
            else if (AdditionalProperties != null && AdditionalProperties.Count > 0)
            {
                arguments.Append("--additional-properties=" + string.Join(",", AdditionalProperties.Select(e => e.Key + "=" + e.Value)));
            }

            if (Authorization != null)
            {
                arguments.Append("-a").Append(Authorization);
            }
            if (ApiNameSuffix != null)
            {
                arguments.Append("--api-name-suffix").Append(ApiNameSuffix);
            }
            if (ApiPackage != null)
            {
                arguments.Append("--api-package").Append(ApiPackage);
            }
            if (ArtifactId != null)
            {
                arguments.Append("--artifact-id").Append(ArtifactId);
            }
            if (ArtifactVersion != null)
            {
                arguments.Append("--artifact-version").Append(ArtifactVersion);
            }
            if (DryRun)
            {
                arguments.Append("--dry-run");
            }
            if (TemplatingEngine != null)
            {
                arguments.Append("-e").Append(TemplatingEngine);
            }
            if (EnablePostProcessFile)
            {
                arguments.Append("--enable-post-process-file");
            }
            if (GenerateAliasAsModel)
            {
                arguments.Append("--generate-alias-as-model");
            }
            if (GitHost != null)
            {
                arguments.Append("--git-host").Append(GitHost);
            }
            if (GitRepository != null)
            {
                arguments.Append("--git-repo-id").Append(GitRepository);
            }
            if (GitUser != null)
            {
                arguments.Append("--git-user-id").Append(GitUser);
            }
            if (GlobalProperties != null && GlobalProperties.Count > 0)
            {
                arguments.Append("--global-property").Append(string.Join(",", GlobalProperties.Select(e => e.Key + "=" + e.Value)));
            }
            if (GroupId != null)
            {
                arguments.Append("--group-id").Append(GroupId);
            }
            if (HttpUserAgent != null)
            {
                arguments.Append("--http-user-agent").Append(HttpUserAgent);
            }
            if (IgnoreFile != null)
            {
                arguments.Append("--ignore-file-override").Append(IgnoreFile.FullPath);
            }
            if (ImportMappings != null && ImportMappings.Count > 0)
            {
                arguments.Append("--import-mappings=" + string.Join(",", ImportMappings.Select(e => e.Key + "=" + e.Value)));
            }
            if (InstantiationTypes != null && InstantiationTypes.Count > 0)
            {
                arguments.Append("--instantiation-types").Append(string.Join(",", InstantiationTypes));
            }
            if (InvokerPackage != null)
            {
                arguments.Append("--invoker-package").Append(InvokerPackage);
            }
            if (LanguageSpecificPrimitives != null && LanguageSpecificPrimitives.Count > 0)
            {
                arguments.Append("--language-specific-primitives").Append(string.Join(",", LanguageSpecificPrimitives));
            }
            if (Library != null)
            {
                arguments.Append("--library").Append(Library);
            }
            if (LogToStandardError)
            {
                arguments.Append("--log-to-stderr");
            }
            if (MinimalUpdate)
            {
                arguments.Append("--minimal-update");
            }
            if (ModelNamePrefix != null)
            {
                arguments.Append("--model-name-prefix").Append(ModelNamePrefix);
            }
            if (ModelNameSuffix != null)
            {
                arguments.Append("--model-name-suffix").Append(ModelNameSuffix);
            }
            if (ModelPackage != null)
            {
                arguments.Append("--model-package").Append(ModelPackage);
            }
            if (PackageName != null)
            {
                arguments.Append("--package-name").Append(PackageName);
            }
            if (ReleaseNote != null)
            {
                arguments.Append("--release-note").Append(ReleaseNote);
            }            
            if (RemoveOperationIdPrefix)
            {
                arguments.Append("--remove-operation-id-prefix");
            }
            if (ReservedWordsMappings != null && ReservedWordsMappings.Count > 0)
            {
                arguments.Append("--reserved-word-mappings=" + string.Join(",", ReservedWordsMappings.Select(e => e.Key + "=" + e.Value)));
            }
            if (SkipOverwrite)
            {
                arguments.Append("-s");
            }
            if (SkipValidation)
            {
                arguments.Append("--skip-validate-spec");
            }
            if (TemplateDirectory != null)
            {
                arguments.Append("-t").Append(TemplateDirectory.FullPath);
            }
            if (TypeMappings != null && TypeMappings.Count > 0)
            {
                arguments.Append("--type-mappings=" + string.Join(",", TypeMappings.Select(e => e.Key + "=" + e.Value)));
            }
            if (Verbose)
            {
                arguments.Append("-v");
            }

            return arguments;
        }

    }
}
