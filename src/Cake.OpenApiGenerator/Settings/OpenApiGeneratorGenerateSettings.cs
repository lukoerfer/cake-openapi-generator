using System.Collections.Generic;

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
        /// Gets or sets the language
        /// </summary>
        /// <remarks>Use this parameter when running <c>swagger-codegen</c></remarks>
        public string Language { get; set; }

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
        public Dictionary<string, string> InstantiationTypes { get; set; } = new Dictionary<string, string>();

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
        public string LibraryTemplate { get; set; }

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
        public bool? StrictSpec { get; set; }

        /// <summary>
        /// Gets or sets system properties
        /// </summary>
        /// <remarks>For version 5.0+ use <see cref="GlobalProperties"/></remarks>
        public Dictionary<string, string> SystemProperties { get; set; } = new Dictionary<string, string>();

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
            return base.AsArguments()
                .Append("generate")
                .AppendOptionalSwitch("-i", Specification)
                .AppendOptionalSwitch("-g", Generator)
                .AppendOptionalSwitch("-l", Language)
                .AppendOptionalSwitch("-o", OutputDirectory)
                .AppendOptionalSwitch("-c", ConfigurationFile)
                .AppendOptionalSwitch("-p", AdditionalProperties,
                    condition: dict => dict.Count > 0 , converter: dict => AsArguments(dict))
                .AppendOptionalSwitch("-a", Authorization)
                .AppendOptionalSwitch("--api-name-suffix", ApiNameSuffix)
                .AppendOptionalSwitch("--api-package", ApiPackage)
                .AppendOptionalSwitch("--artifact-id", ArtifactId)
                .AppendOptionalSwitch("--artifact-version", ArtifactVersion)
                .AppendOptionalSwitch("--dry-run", DryRun)
                .AppendOptionalSwitch("-e", TemplatingEngine)
                .AppendOptionalSwitch("--enable-post-process-file", EnablePostProcessFile)
                .AppendOptionalSwitch("--generate-alias-as-model", GenerateAliasAsModel)
                .AppendOptionalSwitch("--git-host", GitHost)
                .AppendOptionalSwitch("--git-repo-id", GitRepository)
                .AppendOptionalSwitch("--git-user-id", GitUser)
                .AppendOptionalSwitch("--global-property", GlobalProperties,
                    condition: dict => dict.Count > 0, converter: dict => AsArguments(dict))
                .AppendOptionalSwitch("--group-id", GroupId)
                .AppendOptionalSwitch("--http-user-agent", HttpUserAgent)
                .AppendOptionalSwitch("--ignore-file-override", IgnoreFile)
                .AppendOptionalSwitch("--import-mappings", ImportMappings,
                    condition: dict => dict.Count > 0, converter: dict => AsArguments(dict))
                .AppendOptionalSwitch("--instantiation-types", InstantiationTypes,
                    condition: dict => dict.Count > 0, converter: dict => AsArguments(dict))
                .AppendOptionalSwitch("--invoker-package", InvokerPackage)
                .AppendOptionalSwitch("--language-specific-primitives", LanguageSpecificPrimitives,
                    condition: list => list.Count > 0, converter: list => AsArguments(list))
                .AppendOptionalSwitch("--library", LibraryTemplate)
                .AppendOptionalSwitch("--log-to-stderr", LogToStandardError)
                .AppendOptionalSwitch("--minimal-update", MinimalUpdate)
                .AppendOptionalSwitch("--model-name-prefix", ModelNamePrefix)
                .AppendOptionalSwitch("--model-name-suffix", ModelNameSuffix)
                .AppendOptionalSwitch("--model-package", ModelPackage)
                .AppendOptionalSwitch("--package-name", PackageName)
                .AppendOptionalSwitch("--release-note", ReleaseNote)
                .AppendOptionalSwitch("--remove-operation-id-prefix", RemoveOperationIdPrefix)
                .AppendOptionalSwitch("--reserved-words-mappings", ReservedWordsMappings,
                    condition: dict => dict.Count > 0, converter: dict => AsArguments(dict))
                .AppendOptionalSwitch("-s", SkipOverwrite)
                .AppendOptionalSwitch("--server-variables", ServerVariables,
                    condition: dict => dict.Count > 0, converter: dict => AsArguments(dict))
                .AppendOptionalSwitch("--skip-validate-spec", SkipValidation)
                .AppendOptionalSwitch("--strict-spec", StrictSpec,
                    converter: value => value.ToString().ToLower())
                .AppendOptionalSwitch("-t", TemplateDirectory)
                .AppendOptionalSwitch("--type-mappings", TypeMappings,
                    condition: dict => dict.Count > 0, converter: dict => AsArguments(dict))
                .AppendOptionalSwitch("-v", Verbose);
        }

    }
}
