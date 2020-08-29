#r "../src/Cake.OpenApiGenerator/bin/Debug/netstandard2.0/Cake.OpenApiGenerator.dll"

Task("Generate")
	.Does(() =>
{
	OpenApiGenerator.Batch(new OpenApiGeneratorBatchSettings()
	{
		ConfigurationFiles = new FilePathCollection(new FilePath[] { "csharp-server.yaml", "javascript-client.yaml" })
	});
});

RunTarget("Generate");