using Cake.Core.IO;
using Cake.Testing;
using FakeItEasy;
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
            mavenCentral = A.Fake<IWebClient>();
        }

        [Test]
        public void ShouldNotReadMavenCentralWhenPackageExists()
        {
            // Given
            var mavenClient = new MavenClient(fileSystem, mavenLocal, mavenCentral);

            // When
            mavenClient.Resolve(new MavenCoordinates("artifact", "group", "1.0.0"));

            // Then
            A.CallTo(mavenCentral).MustNotHaveHappened();
        }
    }
}
