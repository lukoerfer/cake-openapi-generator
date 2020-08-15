#addin nuget:?package=Cake.Coverlet&version=2.4.2
#addin nuget:?package=Cake.Git&version=0.22.0

#tool nuget:?package=Doxygen&version=1.8.14

var target = Argument("target", "Build");

var solution = File("./src/Cake.OpenApiGenerator.sln");
var project = File("./src/Cake.OpenApiGenerator/Cake.OpenApiGenerator.csproj");
var testProject = File("./src/Cake.OpenApiGenerator.Tests/Cake.OpenApiGenerator.Tests.csproj");

Task("Clean")
    .Does(() =>
{
    CleanDirectory("./artifacts");
    CleanDirectories("./src/**/bin");
    CleanDirectories("./src/**/obj");
});

Task("Build")
    .Does(() =>
{
    DotNetCoreBuild(solution, new DotNetCoreBuildSettings()
    {
        Verbosity = DotNetCoreVerbosity.Quiet
    });
});

Task("Unit-Tests")
    .Does(() =>
{
	var testSettings = new DotNetCoreTestSettings()
    {
        Verbosity = DotNetCoreVerbosity.Minimal
    };
    var coverletSettings = new CoverletSettings()
    {
    	CollectCoverage = true,
        CoverletOutputDirectory = "./artifacts/coverage/coverage",
        CoverletOutputFormat = CoverletOutputFormat.opencover
    };
    DotNetCoreTest(testProject, testSettings, coverletSettings);
});

Task("Functional-Tests")
    .IsDependentOn("Build")
    .Does(() =>
{
    CakeExecuteScript("./samples/build.cake");
});

Task("Check")
    .IsDependentOn("Unit-Tests")
    .IsDependentOn("Functional-Tests");

Task("Nuget-Pack")
    .Does(() =>
{
    DotNetCorePack(project, new DotNetCorePackSettings()
    {
        OutputDirectory = "./artifacts/nuget",
        Verbosity = DotNetCoreVerbosity.Quiet
    });
});

Task("Nuget-Push")
    .IsDependentOn("Nuget-Pack")
    .Does(() =>
{
    var packages = GetFiles("./artifacts/nuget/*.nupkg");

    NuGetPush(packages, new NuGetPushSettings()
    {
        Source = "https://api.nuget.org/v3/index.json"
    });
});

Task("Build-Docs")
    .Does(() =>
{
    EnsureDirectoryExists("artifacts/docs");
    var doxygen = Context.Tools.Resolve("doxygen.exe");
    StartProcess(doxygen, "docs/Doxyfile");
});

RunTarget(target);