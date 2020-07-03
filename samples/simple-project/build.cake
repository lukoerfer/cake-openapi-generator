#addin nuget:?package=Cake.OpenApiGenerator

var target = Argument("target", "Build");

Task("Clean")
	.Does(() =>
{
	CleanDirectory("./output")
});

Task("Generate")
	.Does(() =>
{
	OpenApiGenerator["3.3.4"].Generate(settings =>
	{
		SpecificationFile = "./petstore.json"
		Generator = "csharp",
		OutputDirectory = "./output"
		Verbose = true
	});
});

RunTarget(target);