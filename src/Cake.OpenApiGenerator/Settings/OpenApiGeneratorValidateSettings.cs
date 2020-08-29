using Cake.Core;
using Cake.Core.IO;
using Cake.OpenApiGenerator.Extensions;

namespace Cake.OpenApiGenerator.Settings
{
    /// <summary>
    /// Stores settings for the OpenAPI generator command <c>validate</c>
    /// </summary>
    public class OpenApiGeneratorValidateSettings : OpenApiGeneratorSettings
    {
        /// <summary>
        /// Gets or sets the location of the OpenAPI specification, as URL or file
        /// </summary>
        /// <remarks>This parameter is required.</remarks>
        public string Specification { get; set; }

        /// <summary>
        /// Gets or sets whether recommendations should by provided
        /// </summary>
        public bool Recommend { get; set; }

        internal override ProcessArgumentBuilder AsArguments()
        {
            return base.AsArguments()
                .Append("validate")
                .AppendOptionalSwitch("-i", Specification)
                .AppendOptionalSwitch("--recommend", Recommend);
        }
    }
}
