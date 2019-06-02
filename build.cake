#r "Cake.OpenApi\bin\Debug\Cake.OpenApi.dll"

Setup(context => {
	SetupOpenAPI(tool: "java", version: "4.0.0");
});

Task("Validate-Api")
	.Does(() => {
		OpenAPI.Generate("petstore.yaml", "bash", "client");
	});

RunTarget("Validate-Api");