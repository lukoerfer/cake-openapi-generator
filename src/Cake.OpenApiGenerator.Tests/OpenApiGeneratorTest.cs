using Cake.Core;
using Cake.OpenApiGenerator.Maven;

using Moq;

using NUnit.Framework;

namespace Cake.OpenApiGenerator
{
    [TestFixture]
    class OpenApiGeneratorTest
    {
        private OpenApiGenerator generator;

        [SetUp]
        public void CreateOpenApiGenerator()
        {
            var context = Mock.Of<ICakeContext>();
            var mavenClient = Mock.Of<IMavenClient>();
            generator = new OpenApiGenerator(context, mavenClient);
        }

        [Test]
        public void ShouldCallToolOnGenerate()
        {

        }
    }
}
