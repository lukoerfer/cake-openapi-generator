#addin nuget:?package=Cake.OpenApiGenerator

Task("Generate")
	.Does(() =>
{
	OpenApiGenerator.Generate("petstore.json", "csharp", "src");
});

RunTarget("Generate");