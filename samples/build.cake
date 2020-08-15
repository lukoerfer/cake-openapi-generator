#r "../src/Cake.OpenApiGenerator/bin/Debug/netstandard2.0/Cake.OpenApiGenerator.dll"

var target = Argument("target", "Test");

if (target == "Test")
{
	TaskTeardown(_ => CleanDirectory("./src"));
}

Task("Generate-Simple")
	.Does(() =>
{
	OpenApiGenerator.Generate(new OpenApiGeneratorGenerateSettings()
	{
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
	OpenApiGenerator.Batch("csharp.yaml", "typescript.yaml");
});

Task("Test")
	.IsDependentOn("Generate-Simple")
	.IsDependentOn("Validate-Simple")
	.IsDependentOn("Batch-Simple");

RunTarget(target);