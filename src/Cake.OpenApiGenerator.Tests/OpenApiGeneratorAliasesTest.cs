using Cake.Core;

using FakeItEasy;

using NUnit.Framework;

namespace Cake.OpenApiGenerator
{
    [TestFixture]
    public class OpenApiGeneratorAliasesTest
    {
        private ICakeContext context;

        [SetUp]
        public void Setup()
        {
            context = A.Fake<ICakeContext>();
        }

        [Test]
        public void OpenApiGenerator_WithAnyContext_DoesNotFail()
        {
            Assert.DoesNotThrow(() =>
            {
                var openApiGenerator = OpenApiGeneratorAliases.OpenApiGenerator(context);
            });
        }
    }
}
