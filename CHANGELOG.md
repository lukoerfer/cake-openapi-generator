# Changelog

All notable changes to this project will be documented in this file.
The format is based on [Keep a Changelog](https://keepachangelog.com).

## 2.0.0 - 2020-07

### Added

- `Version` property to specify tool version
- Shorthand notation for tool version using array syntax
- Support for OpenAPI generator command `batch`

### Changed

- Renamed namespace and nuget package to `Cake.OpenApiGenerator`
- Renamed repository to `cake-openapi-generator`
- Tool invocation using Cake Tooling API
- No dependencies on `Cake.Common` and `Cake.Http`

### Removed

- Method `OpenApiGeneratorForVersion(version)` (use array syntax instead)
- Support for passing an `URI` as specification (use `DownloadFile` of `Cake.Http` first instead)

### Fixed

- Some parameters of `openapi-generator generate` command

## 1.0.2 - 2020-01-29

### Fixed

- HTTPS-URL for Maven download

## 1.0.1 - 2020-01-28

### Fixed

- Switch to HTTPS protocol for Maven download

## 1.0.0 - 2019-07-30

### Added

- Property alias `OpenApiGenerator`
- Method alias `OpenApiGeneratorForVersion(version)`
- Support for OpenAPI Generator commands `generate` and `validate`