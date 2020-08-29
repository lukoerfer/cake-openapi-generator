#r "../src/Cake.OpenApiGenerator/bin/Debug/netstandard2.0/Cake.OpenApiGenerator.dll"

Task("Generate")
	.Does(() =>
{
	OpenApiGenerator.Batch(settings =>
	{
		settings.ConfigurationFiles.Add("csharp-server.yaml");
		settings.ConfigurationFiles.Add("javascript-client.yaml");
	});
});

RunTarget("Generate");