#r "../src/Cake.OpenApiGenerator/bin/Debug/netstandard2.0/Cake.OpenApiGenerator.dll"

Task("Generate-Settings")
	.Does(() =>
{
	OpenApiGenerator.Generate(new OpenApiGeneratorGenerateSettings()
	{
		Specification = "./petstore.json",
		Generator = "csharp",
		OutputDirectory = "./src"
	});
});

RunTarget("Generate-Settings");