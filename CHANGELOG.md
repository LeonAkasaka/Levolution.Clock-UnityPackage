# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [0.1.1-preview] - 2025-09-13

### Added

- Unity meta files for documentation and license files
- Version tag support for Unity Package Manager installation

### Fixed

- Unity Package Manager preview version compatibility
- Installation URLs now include version tags for better version control

## [0.1.0-preview] - 2025-09-12

### Added (Initial Release)

- Initial release of Levolution Clock package
- `IClock` interface for time provider abstraction
- `SystemClock` implementation using real system time
- `ManualClock` implementation for manual time control
- `CachedClock` implementation for frame-consistent timing
- `Clocks` static class providing convenient access to standard clocks
- Unity Package Manager support
- MIT License
- Comprehensive documentation and usage examples

### Technical Details

- Unity 6+ compatibility (tested)
- Probably compatible with earlier Unity versions (not tested - uses only standard C# features)
- No Unity Engine dependencies (`noEngineReferences: true`)
- Assembly definition file for proper dependency management
- Namespace: `Levolution.Clock`

[Unreleased]: https://github.com/LeonAkasaka/Levolution.Clock-UnityPackage/compare/v0.1.1-preview...HEAD
[0.1.1-preview]: https://github.com/LeonAkasaka/Levolution.Clock-UnityPackage/compare/v0.1.0-preview...v0.1.1-preview
[0.1.0-preview]: https://github.com/LeonAkasaka/Levolution.Clock-UnityPackage/releases/tag/v0.1.0-preview
