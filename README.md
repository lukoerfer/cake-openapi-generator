# Cake OpenAPI Generator Addin
Cake Addin for code generation via the [OpenAPI Generator](https://openapi-generator.tech/) (f.k.a. Swagger Codegen)

## Motivation
The OpenAPI Generator tool provides a lot of powerful code generators, but since its implemented in Java, the only build tools directly supported are Maven and Gradle. This addin provides a simple wrapper around the command line version of the tool to invoke code generation from Cake.

## Installation
Since the addin is available on [NuGet](), it can simply be registered in your `build.cake` file via the `#addin` preprocessor directive:

``` csharp
#addin nuget:?package=Cake.OpenApiGenerator
```

As an additional dependency, Java needs to be installed and available to Cake. The most common way will be adding Java to the `PATH` environment variable, however it is also possible to register Java as a tool directly in the build script:

``` csharp
Setup(context => {
    context.Tools.RegisterFile("/path/to/java(.exe)");
});
```

## Usage
Once the installation is complete, the `OpenApiGenerator` property and its `Generate` method can be used to generate code from OpenAPI specifications:

``` csharp
Task("Generate")
    .Does(() =>
{
    OpenApiGenerator.Generate("./specification.yaml", "csharp", "./output");
}
```

The three mandatory parameters of the `Generate` method are the specification source (either a `FilePath` or an `Uri`), the generator to use (a list can be found [here](https://openapi-generator.tech/docs/generators.html)) and the destination directory.
Additional options can either be passed directly via a `OpenApiGenerateSettings` object or using an `Action` that configures such an object:

``` csharp
Task("Generate")
    .Does(() =>
{
    OpenApiGenerator
    	.Generate(new OpenApiGenerateSettings()
        {
    		Verbose = true
    	});
    	.Generate(settings =>
        {
    		settings.Verbose = true
    	});
}
```

By chaining calls to `Generate` it is possible to generate multiple clients (or servers), as long as different destination directories are defined.

### Tool version
By default, the latest version of the OpenAPI generator will be resolved and used.
Of course, this requires access to the Internet and may break builds that worked with previous tool versions.
It is recommended to define the tool version as shown in the example below:

``` csharp
Task("Generate")
    .Does(() =>
{
    OpenApiGenerator["3.3.4"].Generate("./specification.yaml", "csharp", "./output");
}
```

### Validation
In addition to code generation, the addin can be used to validate OpenAPI specifications via the `Validate` method.
It only takes a specification `FilePath` or `Uri` as mandatory parameter and a `bool` whether to provide recommendations as an optional second parameter (defaults to `false`):

``` csharp
Task("Validate")
    .Does(() =>
{
    OpenApiGenerator.Validate("./specification.yaml", true);
}
```

## License
The software is licensed under the [MIT license](LICENSE).
