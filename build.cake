var target = Argument("target", "Default");

var solution = File("./src/Cake.CodeGen.OpenAPI.sln");
var project = File("./src/Cake.CodeGen.OpenAPI/Cake.CodeGen.OpenAPI.csproj");

Task("Clean")
	.Does(() =>
{
	CleanDirectory("./artifacts");
	CleanDirectories("./src/**/bin");
	CleanDirectories("./src/**/obj");
});

Task("Restore")
	.Does(() =>
{
	DotNetCoreRestore(solution, new DotNetCoreRestoreSettings()
	{
		Verbosity = DotNetCoreVerbosity.Quiet
	});
});

Task("Build")
	.IsDependentOn("Restore")
	.Does(() =>
{
	DotNetCoreBuild(solution, new DotNetCoreBuildSettings()
	{
		NoRestore = true,
		Verbosity = DotNetCoreVerbosity.Quiet
	});
});

Task("Pack")
	.IsDependentOn("Build")
	.Does(() =>
{
	DotNetCorePack(project, new DotNetCorePackSettings()
	{
		NoRestore = true,
		NoBuild = true,
		OutputDirectory = "./artifacts/nuget",
		Verbosity = DotNetCoreVerbosity.Quiet
	});
});

Task("Push")
	.Does(() =>
{
	var packages = GetFiles("./artifacts/nuget/*.nupkg");

	NuGetPush(packages, new NuGetPushSettings()
	{
		Source = "https://api.nuget.org/v3/index.json"
	});
});

RunTarget(target);