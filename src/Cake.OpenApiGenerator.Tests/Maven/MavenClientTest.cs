using Cake.Core.IO;
using Cake.Testing;
using Moq;
using NUnit.Framework;
using System.IO;

namespace Cake.OpenApiGenerator.Maven
{
    [TestFixture]
    class MavenClientTest
    {
        private FakeFileSystem fileSystem;
        private Mock<IWebClient> mavenCentral;

        [SetUp]
        public void Setup()
        {
            var environment = FakeEnvironment.CreateWindowsEnvironment();
            fileSystem = new FakeFileSystem(environment);
            mavenCentral = new Mock<IWebClient>();
        }

        [Test]
        public void ShouldJustReturnJarIfExists()
        {

            var mavenClient = new MavenClient(fileSystem, null, mavenCentral.Object);

        }
    }
}
