using Cake.Core;

namespace Cake.OpenApi.Internal.Tools
{
    internal class InstalledTool : CommandLineTool
    {
        public override bool SupportsVersion => false;

        public override bool SupportsEndpoint => false;

        public InstalledTool(ICakeContext context, OpenApiGeneratorSettings settings) 
            : base(context, settings, context.Tools.Resolve("openapi-generator"))
        {
            
        }

    }
}
