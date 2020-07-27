using Cake.Core;
using Cake.Core.IO;

using System;

namespace Cake.OpenApiGenerator.Settings
{
    /// <summary>
    /// Stores settings for the OpenAPI generator command <c>validate</c>
    /// </summary>
    public class OpenApiValidateSettings : OpenApiSettings
    {
        /// <summary>
        /// Gets or sets the OpenAPI specification file
        /// </summary>
        /// <remarks>This parameter is required.</remarks>
        public FilePath SpecificationFile { get; set; }

        /// <summary>
        /// Gets or sets whether recommendations should by provided
        /// </summary>
        public bool Recommend { get; set; }

        public override ProcessArgumentBuilder AsArguments()
        {
            var arguments = base.AsArguments();

            if (SpecificationFile == null)
                throw new ArgumentNullException(nameof(SpecificationFile));

            arguments.Append("validate");

            arguments.Append("-i").Append(SpecificationFile.FullPath);

            if (Recommend)
            {
                arguments.Append("--recommend");
            }

            return arguments;
        }
    }
}
