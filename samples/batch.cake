#r "../src/Cake.OpenApiGenerator/bin/Debug/netstandard2.0/Cake.OpenApiGenerator.dll"

Task("Generate")
	.Does(() =>
{
	OpenApiGenerator.Batch("csharp-server.yaml", "javascript-client.yaml");
});

RunTarget("Generate");