# Changelog

## 2.0.0 - 2020

### Added

- Option to specify tool version using array syntax
- Support for `batch` command

### Changed

- Renamed namespace and nuget package to `Cake.OpenApiGenerator`
- Renamed repository to `cake-openapi-generator`

### Removed

- Method `OpenApiGeneratorForVersion(version)` (use array syntax instead)
- Support for passing an `URI` as specification (use [`DownloadFile`](https://cakebuild.net/api/Cake.Common.Net/HttpAliases/05F4707C) first instead)

## 1.0.2 - 2020-01-29

### Fixed

- Fixed HTTPS-URL for Maven download

## 1.0.1 - 2020-01-28

### Fixed

- Switched to HTTPS protocol for Maven download

## 1.0.0 - 2019-07-30

### Added

- 