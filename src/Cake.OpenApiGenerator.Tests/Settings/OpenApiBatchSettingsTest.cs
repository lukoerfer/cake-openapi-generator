using NUnit.Framework;

namespace Cake.OpenApiGenerator.Settings
{
    [TestFixture]
    class OpenApiBatchSettingsTest
    {
        [Test]
        public void ShouldFailWithoutPackage()
        {
            var settings = new OpenApiBatchSettings();

            
        }

        [Test]
        public void ShouldFailWithoutConfigurationFile()
        {
            
        }
    }
}
