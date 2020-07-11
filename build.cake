#addin nuget:?package=Cake.Coverlet&version=2.3.4

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

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
{
    DotNetCoreTest(testProject, new DotNetCoreTestSettings()
    {
        NoBuild = true,
        NoRestore = true,
        Verbosity = DotNetCoreVerbosity.Minimal
    },
    new CoverletSettings()
    {
        CollectCoverage = true,
        CoverletOutputDirectory = "./artifacts/coverage/coverage",
        CoverletOutputFormat = CoverletOutputFormat.opencover
    });
});

Task("Pack")
    .IsDependentOn("Clean")
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
    .IsDependentOn("Pack")
    .Does(() =>
{
    var packages = GetFiles("./artifacts/nuget/*.nupkg");

    NuGetPush(packages, new NuGetPushSettings()
    {
        Source = "https://api.nuget.org/v3/index.json"
    });
});

Task("Docs")
    .Does(() =>
{
    var doxygen = Context.Tools.Resolve("doxygen.exe");
    StartProcess(doxygen, new ProcessSettings());
});

RunTarget(target);