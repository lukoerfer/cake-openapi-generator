#r "Cake.OpenApi\bin\Debug\Cake.OpenApi.dll"

Setup(context => {
	// SetupOpenAPI(tool: "java", version: "4.0.0");
	SetupOpenAPI();
});

Task("Validate-Api")
	.Does(() => {
		OpenAPI.Generate(options => {
			options.Generator = "bash";
		});
	});

RunTarget("Validate-Api");