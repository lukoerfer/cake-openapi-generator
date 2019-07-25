var target = Argument("target", "Default");

var solution = File("src/Cake.CodeGen.OpenAPI.sln");
var project = File("src/Cake.CodeGen.OpenAPI/Cake.CodeGen.OpenAPI.csproj");

Task("Clean")
	.Does(() =>
{
	CleanDirectory("artifacts");
	CleanDirectories("/src/**/bin");
	CleanDirectories("/src/**/obj");
});

Task("Restore")
	.Does(() =>
{
	DotNetCoreRestore(solution, new DotNetCoreRestoreSettings() {
		Verbosity = DotNetCoreVerbosity.Quiet
	});
});

Task("Build")
	.IsDependentOn("Restore")
	.Does(() =>
{
	DotNetCoreBuild(solution, new DotNetCoreBuildSettings() {
		NoRestore = true,
		Verbosity = DotNetCoreVerbosity.Quiet
	});
});

Task("Pack")
	.Does(() =>
{
	
});

Task("Push")
	.Does(() =>
{
	
});

RunTarget(target);