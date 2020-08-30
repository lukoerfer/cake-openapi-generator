using Cake.Core.IO;

using System.IO;
using System.Xml;

namespace Cake.OpenApiGenerator.Maven
{
    /// <summary>
    /// Provides a Maven client that uses both a local and a remote repository
    /// </summary>
    public class MavenClient : IMavenClient
    {
        private readonly IFileSystem fileSystem;
        private readonly DirectoryPath localRepository;
        private readonly IWebClient remoteRepository;

        /// <summary>
        /// Creates a new Maven client
        /// </summary>
        /// <param name="fileSystem">A file system</param>
        /// <param name="localRepository">A local repository base path</param>
        /// <param name="remoteRepository">A remote repository client</param>
        public MavenClient(IFileSystem fileSystem, DirectoryPath localRepository, IWebClient remoteRepository)
        {
            this.fileSystem = fileSystem;
            this.localRepository = localRepository;
            this.remoteRepository = remoteRepository;
        }

        public FilePath Resolve(MavenPackage package)
        {
            var groupId = package.GroupId;
            var artifactId = package.ArtifactId;
            var version = package.Version ?? GetLatestVersion(groupId, artifactId);

            var path = $"{groupId.Replace('.', '/')}/{artifactId}/{version}/{artifactId}-{version}.jar";
            var localJarFile = fileSystem.GetFile(localRepository.CombineWithFilePath(path));

            if (!localJarFile.Exists)
            {
                fileSystem.GetDirectory(localJarFile.Path.GetDirectory()).Create();

                using (var source = remoteRepository.OpenRead(path))
                using (var target = localJarFile.Open(FileMode.CreateNew))
                {
                    source.CopyTo(target);
                }
            }
            return localJarFile.Path;
        }

        private string GetLatestVersion(string groupId, string artifactId)
        {
            var path = $"{groupId.Replace('.', '/')}/{artifactId}/maven-metadata.xml";
            using (var stream = remoteRepository.OpenRead(path))
            {
                var document = new XmlDocument();
                document.Load(stream);
                return document.SelectSingleNode("/metadata/versioning/latest").InnerText;
            }
        }

    }
}
