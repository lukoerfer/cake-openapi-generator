using System;

using Cake.Core;
using Cake.Core.IO;
using Cake.Common;
using Cake.Common.IO;
using Cake.Common.Net;
using Cake.Common.Diagnostics;
using Cake.Common.Xml;

namespace Cake.CodeGen.OpenApi.Internal.Tools
{
    public class OpenApiGeneratorTool
    {
        private static readonly Uri MAVEN_LOCAL = MavenLocal();

        private static readonly Uri MAVEN_CENTRAL = new Uri("http://central.maven.org/maven2/");

        private readonly ICakeContext Context;

        private readonly FilePath JavaExecutable;

        private readonly FilePath Package;

        public OpenApiGeneratorTool(ICakeContext context, string version)
        {
            Context = context;
            JavaExecutable = ResolveJavaExecutable();
            Package = ResolvePackage(version);
        }

        public void Run(ProcessArgumentBuilder generatorArgs)
        {
            var processArgs = new ProcessArgumentBuilder();
            processArgs.Append("-jar");
            processArgs.Append(Package.FullPath);
            processArgs.Append(generatorArgs.Render());
            Context.StartProcess(JavaExecutable, new ProcessSettings()
            {
                Arguments = processArgs
            });
        }

        private FilePath ResolveJavaExecutable()
        {
            if (Context.IsRunningOnWindows())
            {
                return Context.Tools.Resolve("java.exe");
            }
            else if (Context.IsRunningOnUnix())
            {
                return Context.Tools.Resolve("java");
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private FilePath ResolvePackage(string version)
        {
            version = version ?? GetLatestVersionFromMetadata();
            Uri package = new Uri($"org/openapitools/openapi-generator-cli/{version}/openapi-generator-cli-{version}.jar", UriKind.Relative);
            FilePath localPackage = FilePath.FromString(new Uri(MAVEN_LOCAL, package).LocalPath);
            if (!Context.FileExists(localPackage))
            {
                Uri remotePackage = new Uri(MAVEN_CENTRAL, package);
                Context.EnsureDirectoryExists(localPackage.GetDirectory());
                Context.DownloadFile(remotePackage.ToString(), localPackage);
            }
            return localPackage;
        }

        private string GetLatestVersionFromMetadata()
        {
            Uri metadataUri = new Uri(MAVEN_CENTRAL, "org/openapitools/openapi-generator-cli/maven-metadata.xml");
            FilePath metadataFile = Context.DownloadFile(metadataUri);
            return Context.XmlPeek(metadataFile, "/metadata/versioning/latest");
        }

        private static Uri MavenLocal()
        {
            string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            return new Uri(System.IO.Path.Combine(userProfile, ".m2/repository/"));
        }

    }
}
