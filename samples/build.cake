#r "../src/Cake.OpenApiGenerator/bin/Debug/netstandard2.0/Cake.OpenApiGenerator.dll"

var target = Argument("target", "Test");

if (target == "Test")
{
	TaskTeardown(_ => CleanDirectory("./src"));
}

Task("Generate-Simple")
	.Does(() =>
{
	OpenApiGenerator.Generate("petstore.json", "csharp", "src");
});

Task("Test")
	.IsDependentOn("Generate-Simple");

RunTarget(target);