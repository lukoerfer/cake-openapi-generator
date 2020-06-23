using Cake.Core;
using Cake.Core.IO;

using System;

namespace Cake.OpenApiGenerator.Settings
{
    public class OpenApiValidateSettings : OpenApiBaseSettings
    {

        public override string Command => "validate";

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>This parameter is required.</remarks>
        public FilePath SpecificationFile { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Recommend { get; set; }


        protected override void ApplyParameters(ProcessArgumentBuilder args)
        {
            if (SpecificationFile == null)
                throw new InvalidOperationException($"{nameof(SpecificationFile)} must be defined");

            args.Append("-i").Append(SpecificationFile.FullPath);

            if (Recommend)
            {
                args.Append("--recommend");
            }
        }
    }
}
