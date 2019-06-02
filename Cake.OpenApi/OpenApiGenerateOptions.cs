using System;
using System.Collections.Generic;

using Cake.Core.IO;

namespace Cake.OpenApi
{
    /// <summary>
    /// 
    /// </summary>
    public class OpenApiGenerateOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public Uri InputSource { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Generator { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DirectoryPath OutputDirectory { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, string> AdditionalProperties { get; private set; } = new Dictionary<string, string>();

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, string> ImportMappings { get; private set; } = new Dictionary<string, string>();

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, string> TypeMappings { get; private set; } = new Dictionary<string, string>();

        
    }
}
