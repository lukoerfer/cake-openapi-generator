using Cake.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cake.OpenApi.Internal.Tools
{
    internal class RestApiTool : Tool
    {
        public override bool IsProvided => _settings.IsEndpointRequested;

        public override bool SupportsVersion => false;

        public override bool SupportsEndpoint => true;

        public RestApiTool(ICakeContext context, OpenApiSettings settings) : base(context, settings)
        {
            
        }

        public override void Generate(OpenApiGenerateOptions options)
        {
            
        }

        public override void Validate(OpenApiValidateOptions options)
        {
            
        }

        protected virtual Uri GetEndpoint()
        {
            return _settings.Endpoint;
        }
    }
}
