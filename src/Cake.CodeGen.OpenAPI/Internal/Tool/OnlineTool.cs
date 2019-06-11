using System;

using Cake.Core;

namespace Cake.CodeGen.OpenApi.Internal.Tools
{
    internal class OnlineTool : RestApiTool
    {
        public override bool IsProvided => !Settings.IsEndpointRequested;

        public override bool SupportsEndpoint => false;

        public OnlineTool(ICakeContext context, OpenApiGeneratorSettings settings) : base(context, settings)
        {

        }

        protected override Uri GetEndpoint()
        {
            return new Uri("http://api.openapi-generator.tech");
        }
    }
}
