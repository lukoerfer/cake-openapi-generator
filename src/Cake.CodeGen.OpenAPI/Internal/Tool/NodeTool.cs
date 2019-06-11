using System;

using Cake.Core;
using Cake.Core.IO;
using Cake.Common;

namespace Cake.OpenApi.Internal.Tools
{
    internal class NodeTool : ExternalRuntimeTool
    {
        public override bool IsProvided => base.IsProvided && IsJavaInstalled;

        private readonly bool IsJavaInstalled;

        public NodeTool(ICakeContext context, OpenApiGeneratorSettings settings)
            : base(context, settings, SearchNpxExecutable(context))
        {
            IsJavaInstalled = JavaTool.SearchJavaExecutable(Context) != null;
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
            if (Settings.IsVersionRequested)
            {
                version = "@cli-" + Settings.Version;
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
