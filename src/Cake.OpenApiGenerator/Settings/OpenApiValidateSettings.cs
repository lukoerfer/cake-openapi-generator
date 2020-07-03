using Cake.Core;
using Cake.Core.IO;

using System;

namespace Cake.OpenApiGenerator.Settings
{
    /// <summary>
    /// Stores settings for the OpenAPI generator command <c>validate</c>
    /// </summary>
    public class OpenApiValidateSettings : OpenApiBaseSettings
    {
        public override string Command => "validate";

        /// <summary>
        /// Gets or sets the OpenAPI specification file
        /// </summary>
        /// <remarks>This parameter is required.</remarks>
        public FilePath SpecificationFile { get; set; }

        /// <summary>
        /// Gets or sets whether recommendations should by provided 
        /// </summary>
        public bool Recommend { get; set; }

        protected override void ApplyParameters(ProcessArgumentBuilder args)
        {
            if (SpecificationFile == null)
                throw new ArgumentNullException(nameof(SpecificationFile));

            args.Append("-i").Append(SpecificationFile.FullPath);

            if (Recommend)
            {
                args.Append("--recommend");
            }
        }
    }
}
