#r "../src/Cake.OpenApiGenerator/bin/Debug/netstandard2.0/Cake.OpenApiGenerator.dll"

Task("Generate")
	.Does(() =>
{
	OpenApiGenerator.Generate(settings =>
	{
		settings.Specification = "./petstore.json";
		settings.Generator = "csharp";
		settings.OutputDirectory = "./src";
	});
});

RunTarget("Generate");