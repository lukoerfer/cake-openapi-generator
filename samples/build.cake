#r "../src/Cake.OpenApiGenerator/bin/Debug/netstandard2.0/Cake.OpenApiGenerator.dll"

var target = Argument("target", "Check-All");

Task("Generate-With-Settings")
	.Does(() =>
{
	OpenApiGenerator.Generate(new OpenApiGeneratorGenerateSettings()
	{
		Specification = "./petstore.json",
		Generator = "csharp",
		OutputDirectory = "./src"
	});
});

Task("Generate-With-Configurator")
	.Does(() =>
{
	OpenApiGenerator.Generate(settings =>
	{
		settings.Specification = "./petstore.json";
		settings.Generator = "csharp";
		settings.OutputDirectory = "./src";
	});
});

Task("Generate-Pinned-Version")
	.Does(() =>
{
	OpenApiGenerator["3.3.4"].Generate(new OpenApiGeneratorGenerateSettings() {
		Specification = "./petstore.json",
		Generator = "csharp",
		OutputDirectory = "./src"
	});
});

Task("Validate-Simple")
	.Does(() =>
{
	OpenApiGenerator.Validate("./petstore.json", true);
});

Task("Batch-Simple")
	.Does(() =>
{
	OpenApiGenerator.Batch("csharp-server.yaml", "javascript-client.yaml");
});

Task("Batch-With-Settings")
	.Does(() =>
{
	OpenApiGenerator.Batch(new OpenApiGeneratorBatchSettings()
	{
		ConfigurationFiles = new FilePathCollection(new FilePath[] { "csharp-server.yaml", "javascript-client.yaml" })
	});
});

Task("Batch-With-Configurator")
	.Does(() =>
{
	OpenApiGenerator.Batch(settings =>
	{
		settings.ConfigurationFiles.Add("csharp-server.yaml");
		settings.ConfigurationFiles.Add("javascript-client.yaml");
	});
});

if (target == "Check-All")
{
	TaskSetup(_ => { OpenApiGenerator.ToolPackage.Version = null; });
	TaskTeardown(_ => CleanDirectory("./src"));
}

Task("Check-All")
	.IsDependentOn("Generate-With-Settings")
	.IsDependentOn("Generate-With-Configurator")
	.IsDependentOn("Generate-Pinned-Version")
	.IsDependentOn("Validate-Simple")
	.IsDependentOn("Batch-Simple")
	.IsDependentOn("Batch-With-Settings")
	.IsDependentOn("Batch-With-Configurator");

RunTarget(target);