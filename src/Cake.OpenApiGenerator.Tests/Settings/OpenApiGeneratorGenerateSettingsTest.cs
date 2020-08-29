
using NUnit.Framework;

namespace Cake.OpenApiGenerator.Settings
{
    [TestFixture]
    class OpenApiGeneratorGenerateSettingsTest
    {
        private OpenApiGeneratorGenerateSettings settings;

        [SetUp]
        public void Setup()
        {
            settings = new OpenApiGeneratorGenerateSettings()
            {
                ToolPackagePath = "package.jar",
                Specification = "petstore.yaml",
                Generator = "csharp",
                OutputDirectory = "./src"
            };
        }

        [Test]
        public void AsArguments_ShouldEqualDefaultCommand_OnDefaultSetup()
        {
            var arguments = settings.AsArguments().Render();

            Assert.AreEqual("-jar package.jar generate -i petstore.yaml -g csharp -o src", arguments);
        }

        [Test]
        public void AsArguments_ShouldContainAuthorization_IfAuthorizationDefined()
        {
            settings.Authorization = "Authorization%3A%20Basic%20QWxhZGRpbjpPcGVuU2VzYW1l";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" -a Authorization%3A%20Basic%20QWxhZGRpbjpPcGVuU2VzYW1l"));
        }

        [Test]
        public void ShouldRenderApiNameSuffixInArguments()
        {
            settings.ApiNameSuffix = "Api";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --api-name-suffix Api"));
        }

        [Test]
        public void ShouldRenderApiPackageInArguments()
        {
            settings.ApiPackage = "petstore";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --api-package petstore"));
        }

        [Test]
        public void ShouldRenderArtifactIdInArguments()
        {
            settings.ArtifactId = "petstore";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --artifact-id petstore"));
        }

        [Test]
        public void ShouldRenderArtifactVersionInArguments()
        {
            settings.ArtifactVersion = "1.2.3";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --artifact-version 1.2.3"));
        }

        [Test]
        public void ShouldRenderConfigurationFileInArguments()
        {
            settings.ConfigurationFile = "config.json";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" -c config.json"));
        }

        [Test]
        public void ShouldRenderDryRunInArguments()
        {
            settings.DryRun = true;

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --dry-run"));
        }

        [Test]
        public void ShouldRenderTemplatingEngineInArguments()
        {
            settings.TemplatingEngine = "handlebars";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" -e handlebars"));
        }

        [Test]
        public void ShouldRenderEnablePostProcessFileInArguments()
        {
            settings.EnablePostProcessFile = true;

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --enable-post-process-file"));
        }

        [Test]
        public void ShouldRenderGenerateAliasAsModelInArguments()
        {
            settings.GenerateAliasAsModel = true;

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --generate-alias-as-model"));
        }

        [Test]
        public void ShouldRenderGitHostInArguments()
        {
            settings.GitHost = "gitlab.com";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --git-host gitlab.com"));
        }

        [Test]
        public void ShouldRenderGitRepositoryInArguments()
        {
            settings.GitRepository = "openapi-generator";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --git-repo-id openapi-generator"));
        }

        [Test]
        public void ShouldRenderGitUserInArguments()
        {
            settings.GitUser = "openapitools";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --git-user-id openapitools"));
        }

        [Test]
        public void ShouldRenderGlobalPropertiesInArguments()
        {
            settings.GlobalProperties.Add("name", "value");
            settings.GlobalProperties.Add("name2", "value2");

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --global-property name=value,name2=value2"));
        }

        [Test]
        public void ShouldNotFailIfGlobalPropertiesIsNull()
        {
            settings.GlobalProperties = null;

            Assert.DoesNotThrow(() =>
            {
                settings.AsArguments();
            });
        }

        [Test]
        public void ShouldRenderGroupIdInArguments()
        {
            settings.GroupId = "com.example";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --group-id com.example"));
        }

        [Test]
        public void ShouldRenderHttpUserAgentInArguments()
        {
            settings.HttpUserAgent = "codegen_csharp_api_client";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --http-user-agent codegen_csharp_api_client"));
        }

        [Test]
        public void ShouldRenderIgnoreFileInArguments()
        {
            settings.IgnoreFile = ".generator-ignore";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --ignore-file-override .generator-ignore"));
        }

        [Test]
        public void ShouldRenderImportMappingsInArguments()
        {
            settings.ImportMappings.Add("DateTime", "java.time.LocalDateTime");

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --import-mappings DateTime=java.time.LocalDateTime"));
        }

        [Test]
        public void ShouldNotFailIfImportMappingsIsNull()
        {
            settings.ImportMappings = null;

            Assert.DoesNotThrow(() =>
            {
                settings.AsArguments();
            });
        }

        [Test]
        public void ShouldRenderInstantiationTypesInArguments()
        {
            settings.InstantiationTypes.Add("array", "ArrayList");
            settings.InstantiationTypes.Add("map", "HashMap");

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --instantiation-types array=ArrayList,map=HashMap"));
        }

        [Test]
        public void ShouldRenderInvokerPackageInArguments()
        {
            settings.InvokerPackage = "petstore";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --invoker-package petstore"));
        }

        [Test]
        public void ShouldRenderLanguageSpecificPrimitivesInArguments()
        {
            settings.LanguageSpecificPrimitives.Add("String");
            settings.LanguageSpecificPrimitives.Add("boolean");

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --language-specific-primitives String,boolean"));
        }

        [Test]
        public void ShouldRenderLibraryTemplate()
        {
            settings.LibraryTemplate = "petstore";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --library petstore"));
        }

        [Test]
        public void ShouldRenderLogToStandardErrorInArguments()
        {
            settings.LogToStandardError = true;

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --log-to-stderr"));
        }

        [Test]
        public void ShouldRenderMinimalUpdateInArguments()
        {
            settings.MinimalUpdate = true;

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --minimal-update"));
        }

        [Test]
        public void ShouldRenderModelNamePrefixInArguments()
        {
            settings.ModelNamePrefix = "T_";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --model-name-prefix T_"));
        }

        [Test]
        public void ShouldRenderModelNameSuffixInArguments()
        {
            settings.ModelNameSuffix = "Model";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --model-name-suffix Model"));
        }

        [Test]
        public void ShouldRenderModelPackageInArguments()
        {
            settings.ModelPackage = "petstore";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --model-package petstore"));
        }

        [Test]
        public void ShouldRenderAdditionalPropertiesInArguments()
        {
            settings.AdditionalProperties.Add("name", "value");
            settings.AdditionalProperties.Add("name2", "value2");

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" -p name=value,name2=value2"));
        }

        [Test]
        public void ShouldRenderPackageNameInArguments()
        {
            settings.PackageName = "petstore";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --package-name petstore"));
        }

        [Test]
        public void ShouldRenderReleaseNoteInArguments()
        {
            settings.ReleaseNote = "'Minor update'";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --release-note 'Minor update'"));
        }

        [Test]
        public void ShouldRenderRemoveOperationIdPrefixInArguments()
        {
            settings.RemoveOperationIdPrefix = true;

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --remove-operation-id-prefix"));
        }

        [Test]
        public void ShouldRenderReservedWordsMappingsInArguments()
        {
            settings.ReservedWordsMappings.Add("id", "identifier");

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --reserved-words-mappings id=identifier"));
        }

        [Test]
        public void ShouldRenderSkipOverwriteInArguments()
        {
            settings.SkipOverwrite = true;

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" -s"));
        }

        [Test]
        public void ShouldRenderServerVariablesAsArguments()
        {
            settings.ServerVariables.Add("name", "value");
            settings.ServerVariables.Add("name2", "value2");

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --server-variables name=value,name2=value2"));
        }

        [Test]
        public void ShouldRenderSkipValidationAsArguments()
        {
            settings.SkipValidation = true;

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --skip-validate-spec"));
        }

        [Test]
        public void ShouldRenderStrictSpecAsArguments()
        {
            settings.StrictSpec = false;

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --strict-spec false"));
        }

        [Test]
        public void ShouldRenderTemplateDirectoryAsArguments()
        {
            settings.TemplateDirectory = "./template";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" -t template"));
        }

        [Test]
        public void ShouldRenderTypeMappingsAsArguments()
        {
            settings.TypeMappings.Add("array", "List");
            settings.TypeMappings.Add("map", "Map");

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --type-mappings array=List,map=Map"));
        }

        [Test]
        public void ShouldRenderVerboseAsArguments()
        {
            settings.Verbose = true;

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" -v"));
        }
    }
}
