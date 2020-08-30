#addin nuget:?package=Cake.Git&version=0.22.0

#addin nuget:?package=Cake.Coverlet&version=2.4.2

#addin nuget:?package=Cake.Coveralls&version=0.10.2
#tool nuget:?package=coveralls.net&version=0.7.0

#addin nuget:?package=Cake.Sonar&version=1.1.25
#tool nuget:?package=MSBuild.SonarQube.Runner.Tool&version=4.8.0

#tool nuget:?package=Doxygen&version=1.8.14

var target = Argument("target", "Build");

var solution = File("./src/Cake.OpenApiGenerator.sln");
var project = File("./src/Cake.OpenApiGenerator/Cake.OpenApiGenerator.csproj");
var testProject = File("./src/Cake.OpenApiGenerator.Tests/Cake.OpenApiGenerator.Tests.csproj");

var sonarSettings = new SonarBeginSettings()
{
    Key = "Cake.OpenApiGenerator",
    VsTestReportsPath = "./artifacts/reports/tests/results.xml",
    OpenCoverReportsPath = "./artifacts/reports/coverage/coverage.opencover.xml"
};

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
    DotNetCoreTest(testProject, new DotNetCoreTestSettings()
    {
        NoBuild = true,
        VSTestReportPath = "./artifacts/reports/tests/results.xml",
        Verbosity = DotNetCoreVerbosity.Minimal
    }, 
    new CoverletSettings()
    {
    	CollectCoverage = true,
        CoverletOutputDirectory = "./artifacts/reports/coverage/coverage",
        CoverletOutputFormat = CoverletOutputFormat.opencover
    });
});

Task("Functional-Tests")
    .IsDependentOn("Build")
    .Does(() =>
{
    var samples = GetFiles("./samples/*.cake");

    foreach (var sample in samples)
    {
        CakeExecuteScript(sample);
        CleanDirectory("./samples/src");
    }
});

Task("Sonar-Setup")
    .Does(() =>
{
    SonarBegin(sonarSettings);
});

Task("Sonar-Analysis")
    .IsDependentOn("Sonar-Setup")
    .IsDependentOn("Build")
    .IsDependentOn("Unit-Tests")
    .Does(() =>
{
    SonarEnd(sonarSettings.GetEndSettings());
});

Task("Check")
    .IsDependentOn("Unit-Tests")
    .IsDependentOn("Functional-Tests");

Task("Create-Package")
    .Does(() =>
{
    DotNetCorePack(project, new DotNetCorePackSettings()
    {
        OutputDirectory = "./artifacts/nuget",
        Verbosity = DotNetCoreVerbosity.Quiet
    });
});

Task("Publish-Package-To-Nuget")
    .WithCriteria(HasEnvironmentVariable("NUGET_TOKEN"))
    .IsDependentOn("Create-Package")
    .Does(() =>
{
    var packages = GetFiles("./artifacts/nuget/*.nupkg");

    NuGetPush(packages, new NuGetPushSettings()
    {
        Source = "https://api.nuget.org/v3/index.json",
        ApiKey = EnvironmentVariable("NUGET_TOKEN")
    });
});

Task("Publish-Package-To-GitHub")
    .WithCriteria(HasEnvironmentVariable("GITHUB_TOKEN"))
    .IsDependentOn("Create-Package")
    .Does(() =>
{
    var packages = GetFiles("./artifacts/nuget/*.nupkg");

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
    .IsDependentOn("Publish-Package-To-Nuget")
    .IsDependentOn("Publish-Package-To-GitHub");

RunTarget(target);