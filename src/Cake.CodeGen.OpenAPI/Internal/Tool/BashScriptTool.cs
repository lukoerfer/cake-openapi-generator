using Cake.Core;
using Cake.Core.IO;

namespace Cake.CodeGen.OpenApi.Internal.Tools
{
    internal class BashScriptTool : CommandLineTool
    {
        public override bool SupportsVersion => true;

        public override bool SupportsEndpoint => false;

        public BashScriptTool(ICakeContext context, OpenApiGeneratorSettings settings) 
            : base(context, settings, context.Tools.Resolve("openapi-generator-cli"))
        {
            
        }

        protected override ProcessSettings GetProcessSettings()
        {
            ProcessSettings process = base.GetProcessSettings();
            if (Settings.IsVersionRequested)
            {
                process.EnvironmentVariables.Add("OPENAPI_GENERATOR_VERSION", Settings.Version);
            }
            return process;
        }
    }
}
