
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
        public void AsArguments_DefaultSettings_EqualsDefaultCommand()
        {
            var arguments = settings.AsArguments().Render();

            Assert.AreEqual("-jar package.jar generate -i petstore.yaml -g csharp -o src", arguments);
        }

        [Test]
        public void AsArguments_AuthorizationDefined_ContainsAuthorization()
        {
            settings.Authorization = "Authorization%3A%20Basic%20QWxhZGRpbjpPcGVuU2VzYW1l";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" -a Authorization%3A%20Basic%20QWxhZGRpbjpPcGVuU2VzYW1l"));
        }

        [Test]
        public void AsArguments_ApiNameSuffixDefined_ContainsApiNameSuffix()
        {
            settings.ApiNameSuffix = "Api";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --api-name-suffix Api"));
        }

        [Test]
        public void AsArguments_ApiPackageDefined_ContainsApiPackage()
        {
            settings.ApiPackage = "petstore";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --api-package petstore"));
        }

        [Test]
        public void AsArguments_ArtifactIdDefined_ContainsArtifactId()
        {
            settings.ArtifactId = "petstore";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --artifact-id petstore"));
        }

        [Test]
        public void AsArguments_ArtifactVersionDefined_ContainsArtifactVersion()
        {
            settings.ArtifactVersion = "1.2.3";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --artifact-version 1.2.3"));
        }

        [Test]
        public void AsArguments_ConfigurationFileDefined_ContainsConfigurationFile()
        {
            settings.ConfigurationFile = "config.json";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" -c config.json"));
        }

        [Test]
        public void AsArguments_DryRunTrue_ContainsDryRun()
        {
            settings.DryRun = true;

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --dry-run"));
        }

        [Test]
        public void AsArguments_TemplatingEngineDefined_ContainsTemplatingEngine()
        {
            settings.TemplatingEngine = "handlebars";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" -e handlebars"));
        }

        [Test]
        public void AsArguments_EnablePostProcessFileDefined_ContainsEnablePostProcessFile()
        {
            settings.EnablePostProcessFile = true;

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --enable-post-process-file"));
        }

        [Test]
        public void AsArguments_GenerateAliasAsModelTrue_ContainsGenerateAliasAsModel()
        {
            settings.GenerateAliasAsModel = true;

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --generate-alias-as-model"));
        }

        [Test]
        public void AsArguments_GitHostDefined_ContainsGitHost()
        {
            settings.GitHost = "gitlab.com";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --git-host gitlab.com"));
        }

        [Test]
        public void AsArguments_GitRepositoryDefined_ContainsGitRepository()
        {
            settings.GitRepository = "openapi-generator";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --git-repo-id openapi-generator"));
        }

        [Test]
        public void AsArguments_GitUserDefined_ContainsGitUser()
        {
            settings.GitUser = "openapitools";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --git-user-id openapitools"));
        }

        [Test]
        public void AsArguments_GlobalPropertiesDefined_ContainsGlobalProperties()
        {
            settings.GlobalProperties.Add("name", "value");
            settings.GlobalProperties.Add("name2", "value2");

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --global-property name=value,name2=value2"));
        }

        [Test]
        public void AsArguments_GlobalPropertiesNull_DoesNotFail()
        {
            settings.GlobalProperties = null;

            Assert.DoesNotThrow(() =>
            {
                settings.AsArguments();
            });
        }

        [Test]
        public void AsArguments_GroupIdDefined_ContainsGroupId()
        {
            settings.GroupId = "com.example";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --group-id com.example"));
        }

        [Test]
        public void AsArguments_HttpUserAgentDefined_ContainsHttpUserAgent()
        {
            settings.HttpUserAgent = "codegen_csharp_api_client";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --http-user-agent codegen_csharp_api_client"));
        }

        [Test]
        public void AsArguments_IgnoreFileDefined_ContainsIgnoreFile()
        {
            settings.IgnoreFile = ".generator-ignore";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --ignore-file-override .generator-ignore"));
        }

        [Test]
        public void AsArguments_ImportMappingsDefined_ContainsImportMappings()
        {
            settings.ImportMappings.Add("DateTime", "java.time.LocalDateTime");

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --import-mappings DateTime=java.time.LocalDateTime"));
        }

        [Test]
        public void AsArguments_ImportMappingsNull_DoesNotFail()
        {
            settings.ImportMappings = null;

            Assert.DoesNotThrow(() =>
            {
                settings.AsArguments();
            });
        }

        [Test]
        public void AsArguments_InstantiationTypesDefined_ContainsInstantiationTypes()
        {
            settings.InstantiationTypes.Add("array", "ArrayList");
            settings.InstantiationTypes.Add("map", "HashMap");

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --instantiation-types array=ArrayList,map=HashMap"));
        }

        [Test]
        public void AsArguments_InvokerPackageDefined_ContainsInvokerPackage()
        {
            settings.InvokerPackage = "petstore";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --invoker-package petstore"));
        }

        [Test]
        public void AsArguments_LanguageSpecificPrimitivesDefined_ContainsLanguageSpecificPrimitives()
        {
            settings.LanguageSpecificPrimitives.Add("String");
            settings.LanguageSpecificPrimitives.Add("boolean");

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --language-specific-primitives String,boolean"));
        }

        [Test]
        public void AsArguments_LibraryTemplateDefined_ContainsLibraryTemplate()
        {
            settings.LibraryTemplate = "petstore";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --library petstore"));
        }

        [Test]
        public void AsArguments_LogToStandardErrorTrue_ContainsLogToStandardError()
        {
            settings.LogToStandardError = true;

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --log-to-stderr"));
        }

        [Test]
        public void AsArguments_MinimalUpdateTrue_ContainsMinimalUpdate()
        {
            settings.MinimalUpdate = true;

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --minimal-update"));
        }

        [Test]
        public void AsArguments_ModelNamePrefixDefined_ContainsModelNamePrefix()
        {
            settings.ModelNamePrefix = "T_";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --model-name-prefix T_"));
        }

        [Test]
        public void AsArguments_ModelNameSuffixDefined_ContainsModelNameSuffix()
        {
            settings.ModelNameSuffix = "Model";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --model-name-suffix Model"));
        }

        [Test]
        public void AsArguments_ModelPackageDefined_ContainsModelPackage()
        {
            settings.ModelPackage = "petstore";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --model-package petstore"));
        }

        [Test]
        public void AsArguments_AdditionalPropertiesDefined_ContainsAdditionalProperties()
        {
            settings.AdditionalProperties.Add("name", "value");
            settings.AdditionalProperties.Add("name2", "value2");

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" -p name=value,name2=value2"));
        }

        [Test]
        public void AsArguments_PackageNameDefined_ContainsPackageName()
        {
            settings.PackageName = "petstore";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --package-name petstore"));
        }

        [Test]
        public void AsArguments_ReleaseNoteDefined_ContainsReleaseNote()
        {
            settings.ReleaseNote = "'Minor update'";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --release-note 'Minor update'"));
        }

        [Test]
        public void AsArguments_RemoveOperationIdPrefixTrue_ContainsRemoveOperationIdPrefix()
        {
            settings.RemoveOperationIdPrefix = true;

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --remove-operation-id-prefix"));
        }

        [Test]
        public void AsArguments_ReservedWordsMappingsDefined_ContainsReservedWordsMappings()
        {
            settings.ReservedWordsMappings.Add("id", "identifier");

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --reserved-words-mappings id=identifier"));
        }

        [Test]
        public void AsArguments_SkipOverwriteTrue_ContainsSkipOverwrite()
        {
            settings.SkipOverwrite = true;

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" -s"));
        }

        [Test]
        public void AsArguments_ServerVariablesDefined_ContainsServerVariables()
        {
            settings.ServerVariables.Add("name", "value");
            settings.ServerVariables.Add("name2", "value2");

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --server-variables name=value,name2=value2"));
        }

        [Test]
        public void AsArguments_SkipValidationTrue_ContainsSkipValidation()
        {
            settings.SkipValidation = true;

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --skip-validate-spec"));
        }

        [Test]
        public void AsArguments_StrictSpecDefined_ContainsStrictSpec()
        {
            settings.StrictSpec = false;

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --strict-spec false"));
        }

        [Test]
        public void AsArguments_TemplateDirectoryDefined_ContainsTemplateDirectory()
        {
            settings.TemplateDirectory = "./template";

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" -t template"));
        }

        [Test]
        public void AsArguments_TypeMappingsDefined_ContainsTypeMappings()
        {
            settings.TypeMappings.Add("array", "List");
            settings.TypeMappings.Add("map", "Map");

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" --type-mappings array=List,map=Map"));
        }

        [Test]
        public void AsArguments_VerboseTrue_ContainsVerbose()
        {
            settings.Verbose = true;

            var arguments = settings.AsArguments().Render();

            Assert.That(arguments.Contains(" -v"));
        }
    }
}
