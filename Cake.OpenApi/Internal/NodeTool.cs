using System;

using Cake.Core;
using Cake.Core.IO;
using Cake.Common.Diagnostics;
using Cake.Common;

namespace Cake.OpenApi.Internal
{
    internal class NodeTool : ExternalRuntimeTool
    {
        public override bool IsProvided => base.IsProvided && _isJavaInstalled;

        private readonly bool _isJavaInstalled;

        public NodeTool(ICakeContext context, OpenApiSettings settings)
            : base(context, settings, SearchNpxExecutable(context))
        {
            _isJavaInstalled = JavaTool.SearchJavaExecutable(_context) != null;
        }

        protected override ProcessArgumentBuilder GetArguments()
        {
            return base.GetArguments()
                .Append("-p")
                .Append(GetPackageName())
                .Append("openapi-generator");
        }

        private string GetPackageName()
        {
            string version = "";
            if (_settings.IsVersionRequested)
            {
                version = "@cli-" + _settings.Version;
            }
            return "@openapitools/openapi-generator-cli" + version;
        }

        private static FilePath SearchNpxExecutable(ICakeContext context)
        {
            if (context.IsRunningOnWindows())
            {
                return context.Tools.Resolve("npx.cmd");
            }
            else if (context.IsRunningOnUnix())
            {
                return context.Tools.Resolve("npx");
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
