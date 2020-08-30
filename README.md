# Cake OpenAPI Generator Addin
Cake Addin for code generation via the [OpenAPI Generator](https://openapi-generator.tech/) (f.k.a. Swagger Codegen)

## Motivation
The OpenAPI Generator tool provides a lot of powerful code generators, but since its implemented in Java, the only build tools directly supported are Maven and Gradle. This addin provides a simple wrapper around the command line version of the tool to invoke code generation from Cake.

## Installation
Since the addin is available on [NuGet](), it can simply be registered in your `build.cake` file using the `#addin` preprocessor directive:

``` csharp
#addin nuget:?package=Cake.OpenApiGenerator&version=<version>
```

As an additional dependency, Java needs to be installed and available to Cake. It may be either added to the `PATH` environment variable or registered manually in the build script:

``` csharp
Setup(context => {
    context.Tools.RegisterFile("/path/to/java(.exe)");
});
```

## Usage
Once the addin is registered, the alias `OpenApiGenerator` provides a wrapper around the OpenAPI Generator.
The first example shows a minimal example for the method `Generate`:

``` csharp
Task("My-Task")
    .Does(() =>
{
    OpenApiGenerator.Generate(new OpenApiGeneratorGenerateSettings()
    {
        Specification = "specification.yaml",
        Generator = "csharp",
        OutputDirectory = "./src"
    });
});
```

Alternatively, you may pass an `Action` that configures the `OpenApiGeneratorGenerateSettings`:

``` csharp
OpenApiGenerator.Generate(settings =>
{
    setttings.Specification = "specification.yaml";
    // ...
})
```

### Reproducible builds

By default, the latest version of the OpenAPI generator will be resolved and used.
Of course, this requires access to the Internet and may break builds that worked with previous tool versions.
It is recommended to pin the tool version as shown in the example below:

``` csharp
Task("My-Task")
    .Does(() =>
{
    OpenApiGenerator["3.3.4"].Generate(...);
});
```

This shorthand notation is useful for build scripts that only use the `OpenApiGenerator` once.
If there are multiple calls to the `OpenApiGenerator`, the version should be defined at the top of the build script or using a `Setup` method:

``` csharp
Setup(context =>
{
    OpenApiGenerator.ToolPackage.Version = "3.3.4";
});
```

### Validate specifications


``` csharp
OpenApiGenerator.Validate("specification.yaml", recommend: true);
```

### Batch processing


``` csharp
OpenApiGenerator.Batch("csharp-server.yaml", "javascript-client.yaml");

OpenApiGenerator.Batch(new OpenApiBatchSettings()
{
    ConfigurationFiles = new FilePathCollection()
    // ...
});

OpenApiGenerator.Batch(settings =>
{
    settings.ConfigurationFiles.Add("");
    settings.ConfigurationFiles.Add("");
    // ...
});
```

### Advanced usage

``` csharp
Setup(context =>
{
    OpenApiGenerator.ToolPackage = new MavenPackage("io.swagger", "swagger-codegen-cli");
});

Task("Swagger-Codegen")
    .Does(() =>
{
    OpenApiGenerator.Generate(new OpenApiGeneratorGenerateSettings()
    {
        Specification = "./petstore.json",
        // Use Language (-l) instead of Generator (-g)
        Language = "html",
        OutputDirectory = "./src"
    });
});
```

``` csharp
Setup(context =>
{
    OpenApiGenerator.ToolPath = context.Tools.Resolve("openapi-generator");
});
```

## License
The software is licensed under the [MIT license](https://github.com/lukoerfer/cake-openapi-generator/blob/master/LICENSE).
