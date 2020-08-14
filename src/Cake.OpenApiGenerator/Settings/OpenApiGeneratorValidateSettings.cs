using Cake.Core;
using Cake.Core.IO;

using System;

namespace Cake.OpenApiGenerator.Settings
{
    /// <summary>
    /// Stores settings for the OpenAPI generator command <c>validate</c>
    /// </summary>
    public class OpenApiGeneratorValidateSettings : OpenApiGeneratorSettings
    {
        /// <summary>
        /// Gets or sets the OpenAPI specification file
        /// </summary>
        /// <remarks>This parameter is required.</remarks>
        public string Specification { get; set; }

        /// <summary>
        /// Gets or sets whether recommendations should by provided
        /// </summary>
        public bool Recommend { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal override ProcessArgumentBuilder AsArguments()
        {
            var arguments = base.AsArguments();

            if (Specification == null)
                throw new ArgumentNullException(nameof(Specification));

            arguments.Append("validate");

            arguments.Append("-i").Append(Specification);
            if (Recommend)
            {
                arguments.Append("--recommend");
            }

            return arguments;
        }
    }
}
