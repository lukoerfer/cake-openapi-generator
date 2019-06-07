using System;
using System.Collections.Generic;

using Cake.Common;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.OpenApi.Internal
{
    internal class BashScriptTool : CommandLineTool
    {
        public override bool SupportsVersion => true;

        public override bool SupportsEndpoint => false;


        public BashScriptTool(ICakeContext context, OpenApiSettings settings) 
            : base(context, settings, context.Tools.Resolve("openapi-generator-cli"))
        {
            
        }

        protected override ProcessSettings GetProcessSettings()
        {
            ProcessSettings process = base.GetProcessSettings();
            if (_settings.IsVersionRequested)
            {
                process.EnvironmentVariables.Add("OPENAPI_GENERATOR_VERSION", _settings.Version);
            }
            return process;
        }
    }
}
