#r "../src/Cake.OpenApiGenerator/bin/Debug/netstandard2.0/Cake.OpenApiGenerator.dll"

Task("Validate")
	.Does(() =>
{
	OpenApiGenerator.Validate("./petstore.json", true);
});

RunTarget("Validate");