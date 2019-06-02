using Cake.Core;
using Cake.Core.IO;

namespace Cake.OpenApi.Internal
{
    internal abstract class ExternalRuntimeTool : CommandLineTool
    {
        public override bool SupportsVersion => true;

        public override bool SupportsEndpoint => false;

        protected ExternalRuntimeTool(ICakeContext context, OpenApiSettings settings, FilePath executable) 
            : base(context, settings, executable)
        {

        }
    }
}
