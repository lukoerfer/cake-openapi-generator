using NUnit.Framework;

using System;

namespace Cake.OpenApiGenerator.Settings
{
    [TestFixture]
    class OpenApiBatchSettingsTest
    {
        [Test]
        public void ShouldFailWithoutPackage()
        {
            var settings = new OpenApiBatchSettings();

            Assert.Throws<InvalidOperationException>(() =>
            {
                settings.GetArguments();
            });
        }

        [Test]
        public void ShouldFailWithoutConfigurationFile()
        {
            
        }
    }
}
