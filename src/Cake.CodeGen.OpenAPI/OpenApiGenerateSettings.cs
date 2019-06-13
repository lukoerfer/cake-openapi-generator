using System;
using System.Collections.Generic;

using Cake.Core.IO;

namespace Cake.CodeGen.OpenApi
{
    /// <summary>
    /// 
    /// </summary>
    public class OpenApiGenerateSettings
    {
        internal Uri Specification { get; set; }

        internal string Generator { get; set; }

        internal DirectoryPath OutputDirectory { get; set; }

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

    }
}
