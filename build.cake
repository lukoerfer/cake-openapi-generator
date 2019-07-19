#r "src/Cake.CodeGen.OpenAPI/bin/Debug/netstandard2.0/Cake.CodeGen.OpenAPI.dll"

var target = Argument("target", "Default");

Task("Generate")
	.Does(() =>
{
	OpenApiGenerator.Generate("petstore.yaml", "csharp-nancyfx", "generated");
});


RunTarget(target);