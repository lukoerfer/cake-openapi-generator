#r "../src/Cake.OpenApiGenerator/bin/Debug/netstandard2.0/Cake.OpenApiGenerator.dll"

// No version specified => use latest
OpenApiGenerator.ToolPackage = new MavenPackage("io.swagger", "swagger-codegen-cli");

Task("Swagger-Codegen")
	.Does(() =>
{
	OpenApiGenerator.Generate(new OpenApiGeneratorGenerateSettings() {
		Specification = "./petstore.json",
		// Use Language (-l) instead of Generator (-g)
		Language = "html",
		OutputDirectory = "./src"
	});
});

RunTarget("Swagger-Codegen");