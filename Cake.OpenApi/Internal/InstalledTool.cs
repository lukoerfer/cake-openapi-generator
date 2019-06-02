using Cake.Core;
using Cake.Core.IO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cake.OpenApi.Internal
{
    internal class InstalledTool : CommandLineTool
    {
        public override bool SupportsVersion => false;

        public override bool SupportsEndpoint => false;

        public InstalledTool(ICakeContext context, OpenApiSettings settings) 
            : base(context, settings, context.Tools.Resolve("openapi-generator"))
        {
            
        }

    }
}
