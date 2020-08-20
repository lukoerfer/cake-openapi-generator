#addin nuget:?package=Cake.Git&version=0.22.0

#addin nuget:?package=Cake.Coverlet&version=2.4.2

#addin nuget:?package=Cake.Coveralls&version=0.10.2
#tool nuget:?package=coveralls.net&version=0.7.0

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
    .IsDependentOn("Build")
    .Does(() =>
{
	var testSettings = new DotNetCoreTestSettings()
    {
        NoBuild = true,
        Verbosity = DotNetCoreVerbosity.Minimal
    };
    var coverletSettings = new CoverletSettings()
    {
    	CollectCoverage = true,
        CoverletOutputDirectory = "./artifacts/coverage/coverage",
        CoverletOutputFormat = CoverletOutputFormat.opencover
    };
    DotNetCoreTest(testProject, testSettings, coverletSettings);

    if (HasEnvironmentVariable("COVERALLS_TOKEN"))
    {
        CoverallsNet("./artifacts/coverage/coverage.opencover.xml", CoverallsNetReportType.OpenCover, new CoverallsNetSettings()
        {
            RepoTokenVariable = "COVERALLS_TOKEN",
            UseRelativePaths = true,
            TreatUploadErrorsAsWarnings = true
        });
    }
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

Task("Create-Package")
    .Does(() =>
{
    DotNetCorePack(project, new DotNetCorePackSettings()
    {
        NoBuild = true,
        OutputDirectory = "./artifacts/nuget",
        Verbosity = DotNetCoreVerbosity.Quiet
    });
});

Task("Publish-Package")
    .IsDependentOn("Create-Package")
    .Does(() =>
{
    var packages = GetFiles("./artifacts/nuget/*.nupkg");

    NuGetPush(packages, new NuGetPushSettings()
    {
        Source = "https://api.nuget.org/v3/index.json",
        ApiKey = EnvironmentVariable("NUGET_TOKEN")
    });
    NuGetPush(packages, new NuGetPushSettings()
    {
        Source = "https://nuget.pkg.github.com/lukoerfer/index.json",
        ApiKey = EnvironmentVariable("GITHUB_TOKEN")
    });
});

Task("Build-Docs")
    .Does(() =>
{
    EnsureDirectoryExists("artifacts/docs");
    var doxygen = Context.Tools.Resolve("doxygen.exe");
    StartProcess(doxygen, "docs/Doxyfile");
});

Task("Publish")
    .IsDependentOn("Clean")
    .IsDependentOn("Check")
    .IsDependentOn("Publish-Package");

RunTarget(target);