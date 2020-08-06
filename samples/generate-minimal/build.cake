#r "../../src/Cake.OpenApiGenerator/bin/Debug/netstandard2.0/Cake.OpenApiGenerator.dll"

var target = Argument("target", "Test");

Task("Generate")
	.Does(() =>
{
	OpenApiGenerator.Generate("petstore.json", "csharp", "src");
});

Task("Clean")
	.Does(() =>
{
	DeleteDirectory("src", true);
});

Task("Test")
	.IsDependentOn("Generate")
	.IsDependentOn("Clean");

RunTarget(target);