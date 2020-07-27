using Cake.Core.IO;
using Cake.Testing;
using Moq;
using NUnit.Framework;

namespace Cake.OpenApiGenerator.Maven
{
    [TestFixture]
    class MavenClientTest
    {
        private FakeFileSystem fileSystem;
        private DirectoryPath mavenLocal;
        private IWebClient mavenCentral;

        [SetUp]
        public void Setup()
        {
            fileSystem = new FakeFileSystem(FakeEnvironment.CreateWindowsEnvironment());
            mavenLocal = new DirectoryPath(".m2");
            mavenCentral = Mock.Of<IWebClient>();
        }

        [Test]
        public void ShouldJustReturnJarIfExists()
        {

            var mavenClient = new MavenClient(fileSystem, mavenLocal, mavenCentral);

        }
    }
}
