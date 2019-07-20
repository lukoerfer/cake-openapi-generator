using System;
using System.Collections.Generic;
using System.Linq;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.CodeGen.OpenApi
{
    /// <summary>
    /// 
    /// </summary>
    public class OpenApiGenerateSettings
    {
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, string> AdditionalProperties { get; private set; } = new Dictionary<string, string>();

        /// <summary>
        /// 
        /// </summary>
        public FilePath ConfigurationFile { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, string> ImportMappings { get; private set; } = new Dictionary<string, string>();

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, string> TypeMappings { get; private set; } = new Dictionary<string, string>();

        /// <summary>
        /// 
        /// </summary>
        public string Authorization { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ApiPackage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ArtifactId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ArtifactVersion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, string> SystemProperties { get; private set; } = new Dictionary<string, string>();

        /// <summary>
        /// 
        /// </summary>
        public string TemplatingEngine { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool EnablePostProcessFile { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool GenerateAliasAsModel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string GitRepository { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string GitUser { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string GroupId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string HttpUserAgent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public FilePath IgnoreFile { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> InstantiationTypes { get; private set; } = new List<string>();

        /// <summary>
        /// 
        /// </summary>
        public string InvokerPackage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> LanguageSpecificPrimitives { get; private set; } = new List<string>();

        /// <summary>
        /// 
        /// </summary>
        public string Library { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool LogToStandardError { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool MinimalUpdate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ModelNamePrefix { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ModelNameSuffix { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ModelPackage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PackageName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ReleaseNote { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool RemoveOperationIdPrefix { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, string> ReservedWordsMappings { get; private set; } = new Dictionary<string, string>();

        /// <summary>
        /// 
        /// </summary>
        public bool SkipOverwrite { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool SkipValidation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool StrictMode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DirectoryPath TemplateDirectory { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Verbose { get; set; }

        public ProcessArgumentBuilder AsArguments()
        {
            var args = new ProcessArgumentBuilder();
            if (ConfigurationFile != null)
            {
                args.Append("-c").Append(ConfigurationFile.FullPath);
            }
            else if (AdditionalProperties.Count > 0)
            {
                args.Append("--additional-properties=" + string.Join(",", AdditionalProperties.Select(entry => entry.Key + "=" + entry.Value)));
            }
            if (ImportMappings.Count > 0)
            {
                args.Append("--import-mappings=" + string.Join(",", ImportMappings.Select(entry => entry.Key + "=" + entry.Value)));
            }
            if (TypeMappings.Count > 0)
            {
                args.Append("--type-mappings=" + string.Join(",", TypeMappings.Select(entry => entry.Key + "=" + entry.Value)));
            }
            if (Authorization != null)
            {
                args.Append("-a").Append(Authorization);
            }
            if (ApiPackage != null)
            {
                args.Append("--api-package").Append(ApiPackage);
            }
            if (ArtifactId != null)
            {
                args.Append("--artifact-id").Append(ArtifactId);
            }
            if (ArtifactVersion != null)
            {
                args.Append("--artifact-version").Append(ArtifactVersion);
            }
            if (SystemProperties.Count > 0)
            {
                args.Append("--type-mappings=" + string.Join(",", SystemProperties.Select(entry => entry.Key + "=" + entry.Value)));
            }
            if (TemplatingEngine != null)
            {
                args.Append("-e").Append(TemplatingEngine);
            }
            if (EnablePostProcessFile)
            {
                args.Append("--enable-post-process-file");
            }
            if (GenerateAliasAsModel)
            {
                args.Append("--generate-alias-as-model");
            }
            if (GitRepository != null)
            {
                args.Append("--git-repo-id").Append(GitRepository);
            }
            if (GitUser != null)
            {
                args.Append("--git-user-id").Append(GitUser);
            }
            if (GroupId != null)
            {
                args.Append("--group-id").Append(GroupId);
            }
            if (HttpUserAgent != null)
            {
                args.Append("--http-user-agent").Append(HttpUserAgent);
            }
            if (IgnoreFile != null)
            {
                args.Append("--ignore-file-override").Append(IgnoreFile.FullPath);
            }
            if (InstantiationTypes.Count > 0)
            {
                args.Append("--instantiation-types").Append(string.Join(",", InstantiationTypes));
            }
            if (InvokerPackage != null)
            {
                args.Append("--invoker-package").Append(InvokerPackage);
            }
            if (LanguageSpecificPrimitives.Count > 0)
            {
                args.Append("--language-specific-primitives").Append(string.Join(",", LanguageSpecificPrimitives));
            }
            if (Library != null)
            {
                args.Append("--library").Append(Library);
            }
            if (LogToStandardError)
            {
                args.Append("--log-to-stderr");
            }
            if (MinimalUpdate)
            {
                args.Append("--minimal-update");
            }
            if (ModelNamePrefix != null)
            {
                args.Append("--model-name-prefix").Append(ModelNamePrefix);
            }
            if (ModelNameSuffix != null)
            {
                args.Append("--model-name-suffix").Append(ModelNameSuffix);
            }
            if (ModelPackage != null)
            {
                args.Append("--model-package").Append(ModelPackage);
            }
            if (PackageName != null)
            {
                args.Append("--package-name").Append(PackageName);
            }
            if (ReleaseNote != null)
            {
                args.Append("--release-note").Append(ReleaseNote);
            }
            if (RemoveOperationIdPrefix)
            {
                args.Append("--reserved-words-mappings");
            }
            if (SkipOverwrite)
            {
                args.Append("-s");
            }
            if (SkipValidation)
            {
                args.Append("--skip-validate-spec");
            }
            if (StrictMode)
            {

            }
            if (TemplateDirectory != null)
            {
                args.Append("-t").Append(TemplateDirectory.FullPath);
            }
            if (Verbose)
            {
                args.Append("-v");
            }
            return args;
        }

    }
}
