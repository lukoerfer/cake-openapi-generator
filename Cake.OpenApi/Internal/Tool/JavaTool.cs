using System;

using Cake.Core;
using Cake.Core.IO;
using Cake.Common;
using Cake.Common.IO;
using Cake.Common.Net;

namespace Cake.OpenApi.Internal.Tools
{
    internal class JavaTool : ExternalRuntimeTool
    {
        private const string DEFAULT_VERSION = "3.3.4";

        private static readonly Uri MAVEN_LOCAL = MavenLocal();

        private static readonly Uri MAVEN_CENTRAL = new Uri("http://central.maven.org/maven2/");

        public override bool IsProvided => base.IsProvided;

        public JavaTool(ICakeContext context, OpenApiSettings settings) 
            : base(context, settings, SearchJavaExecutable(context))
        {
            
        }

        protected override ProcessArgumentBuilder GetArguments()
        {
            return base.GetArguments()
                .Append("-jar")
                .Append(ResolvePackage().FullPath);
        }

        private FilePath ResolvePackage()
        {
            Uri package = GetPackageResource();
            FilePath localPackage = FilePath.FromString(new Uri(MAVEN_LOCAL, package).LocalPath);
            if (!Context.FileExists(localPackage))
            {
                Uri remotePackage = new Uri(MAVEN_CENTRAL, package);
                Context.EnsureDirectoryExists(localPackage.GetDirectory());
                Context.DownloadFile(remotePackage.ToString(), localPackage);
            }
            return localPackage;
        }

        private Uri GetPackageResource()
        {
            string version = Settings.Version ?? DEFAULT_VERSION;
            string path = $"org/openapitools/openapi-generator-cli/{version}/openapi-generator-cli-{version}.jar";
            return new Uri(path, UriKind.Relative);
        }

        public static FilePath SearchJavaExecutable(ICakeContext context)
        {
            if (context.IsRunningOnWindows())
            {
                return context.Tools.Resolve("java.exe");
            }
            else if (context.IsRunningOnUnix())
            {
                return context.Tools.Resolve("java");
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private static Uri MavenLocal()
        {
            string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            return new Uri(System.IO.Path.Combine(userProfile, ".m2/repository/"));
        }

    }
}
