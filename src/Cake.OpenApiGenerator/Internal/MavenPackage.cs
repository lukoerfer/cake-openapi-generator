using Cake.Core.IO;
using Cake.OpenApiGenerator.Internal;

using System.Xml;

namespace Cake.OpenApiGenerator
{
    internal class MavenPackage
    {
        private readonly IFileSystem fileSystem;
        private readonly IWebClient remotePackage;
        private readonly DirectoryPath localPackage;

        public MavenPackage(IFileSystem fileSystem, IWebClient remotePackage, DirectoryPath localPackage)
        {
            this.fileSystem = fileSystem;
            this.remotePackage = remotePackage;
            this.localPackage = localPackage;
        }

        public FilePath GetJarFile(string version)
        {
            version = version ?? GetLatestVersion();
            var jarFile = $"{version}/openapi-generator-cli-{version}.jar";
            var localJarFile = fileSystem.GetFile(localPackage.CombineWithFilePath(jarFile));

            if (!localJarFile.Exists)
            {
                using (var source = remotePackage.OpenRead(jarFile))
                using (var target = localJarFile.OpenWrite())
                {
                    source.CopyTo(target);
                }
            }
            return localJarFile.Path;
        }

        private string GetLatestVersion()
        {
            using (var stream = remotePackage.OpenRead("maven-metadata.xml"))
            {
                var document = new XmlDocument();
                document.Load(stream);
                return document.SelectSingleNode("/metadata/versioning/latest").InnerText;
            }
        }
    }
}
