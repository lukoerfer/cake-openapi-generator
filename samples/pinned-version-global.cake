#r "../src/Cake.OpenApiGenerator/bin/Debug/netstandard2.0/Cake.OpenApiGenerator.dll"

OpenApiGenerator.ToolPackage.Version = "3.3.4";

Task("Pinned-Version-Global-Validate")
	.Does(() =>
{
	OpenApiGenerator.Validate("./petstore.json");
});

Task("Pinned-Version-Global-Generate")
	.IsDependentOn("Pinned-Version-Global-Validate")
	.Does(() =>
{
	OpenApiGenerator.Generate(new OpenApiGeneratorGenerateSettings() {
		Specification = "./petstore.json",
		Generator = "csharp",
		OutputDirectory = "./src"
	});
});

RunTarget("Pinned-Version-Global-Generate");