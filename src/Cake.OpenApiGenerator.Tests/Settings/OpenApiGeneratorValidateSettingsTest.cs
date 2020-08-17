using NUnit.Framework;
using System;

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
                ToolPackageFile = "package.jar",
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
        public void ShouldFailIfSpecificationIsNull()
        {
            settings.Specification = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                settings.AsArguments();
            });
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
