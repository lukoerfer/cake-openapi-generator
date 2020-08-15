using NUnit.Framework;
using System;

namespace Cake.OpenApiGenerator.Settings
{
    [TestFixture]
    class OpenApiGeneratorValidateSettingsTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ShouldFailIfSpecificationNull()
        {
            var settings = new OpenApiGeneratorValidateSettings()
            {
                Specification = null
            };

            Assert.Throws<ArgumentNullException>(() =>
            {
                settings.AsArguments();
            });
        }

        [Test]
        public void ShouldHaveSpecificationInArguments()
        {

        }
    }
}
