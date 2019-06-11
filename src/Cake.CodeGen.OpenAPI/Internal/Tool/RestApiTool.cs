using System;

using Cake.Core;
using Cake.Http;

namespace Cake.OpenApi.Internal.Tools
{
    internal class RestApiTool : Tool
    {
        public override bool IsProvided => Settings.IsEndpointRequested;

        public override bool SupportsVersion => false;

        public override bool SupportsEndpoint => true;

        public RestApiTool(ICakeContext context, OpenApiGeneratorSettings settings) : base(context, settings)
        {
            
        }

        public override void Generate(OpenApiGenerateOptions options)
        {
            
        }

        public override void Validate(OpenApiValidateOptions options)
        {
            throw new InvalidOperationException("Validation is not supported by REST API");
        }

        protected virtual Uri GetEndpoint()
        {
            return Settings.Endpoint;
        }

        private bool IsClientGenerator(string generator)
        {
            string content = Context.HttpGet("");
            return false;
        }

        private bool IsServerGenerator(string generator)
        {
            string content = Context.HttpGet("");
            return false;
        }
    }
}
