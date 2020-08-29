using NUnit.Framework;

namespace Cake.OpenApiGenerator.Settings
{
    [TestFixture]
    class OpenApiGeneratorValidateSettingsTest
    {
        private OpenApiGeneratorValidateSettings settings;

        [SetUp]
        public void Setup()
        {
            settings = new OpenApiGeneratorValidateSettings()
            {
                ToolPackagePath = "package.jar",
                Specification = "petstore.yaml"
            };
        }

        [Test]
        public void ShouldRenderArgumentsFromRequiredParameters()
        {
            var arguments = settings.AsArguments().Render();

            Assert.AreEqual("-jar package.jar validate -i petstore.yaml", arguments);
        }

        [Test]
        public void ShouldRenderRecommendInArguments()
        {
            settings.Recommend = true;

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --recommend"));
        }
    }
}
