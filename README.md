# Cake OpenAPI Generator Addin
Cake Addin for code generation via the [OpenAPI Generator](https://openapi-generator.tech/) (f.k.a. Swagger Codegen)

## Motivation

## Installation
Since the addin is available on NuGet, it can simply be registered in your `build.cake` file via the `#addin` preprocessor directive:

    #addin nuget:?package=Cake.CodeGen.OpenAPI&version=1.0.0

> The addin will be fully functional without any further setup, because the OpenAPI generator tool can be invoked in many different ways and the addin may always fall back to using the [public online generator](https://openapi-generator.tech/docs/online). For offline availability and **privacy** reasons, it is highly recommended to setup a local service or CLI tool, one of them being simply the Java runtime environment, which is required for the others to work anyhow. Having Java installed and registered in your `PATH` is already sufficient for this addin to run locally instead of using the public online generator. See [Tool selection](#tool-selection) for more details.

## Usage
Once the addin has been registered in your `build.cake` file, the `OpenAPI` extension property and its `Generate` method can be used to generate code from OpenAPI specifications:

    Task("Generate")
        .Does(() =>
    {
        OpenAPI.Generate("./specification.yaml", "csharp", "./output");
    }

### Setup

### Tool selection

## License
The software is licensed under the [MIT license](https://github.com/lukoerfer/cake-openapi/blob/master/LICENSE).
