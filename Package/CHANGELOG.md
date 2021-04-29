# Changelog
All notable changes to this package will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]
- Added `IndexOf()` extension method for `IReadOnlyList` (with tests)
- Added Enter and Exit events to `FiniteStateMachine` for groups of states (with tests)
- Added `Interpolation` static class with functions for exponential motion (with tests) 

## [0.1.0] - 2021-02-15
### Changed
- Changed repository name (I no longer plan on having multiple unity packages in the same repo)
- Changed versions and tags from `utils-v<version>` to `v<version>`

## [0.0.2] - 2021-02-15
### Added
- CPMath (general math functions)
- ProjectileMath (math functions related to projectiles)
- Added swizzle extension functions for Vector3 to Vector2
- Editor tests for FiniteStateMachine, CPMath, Extensions, ProjectileMath
- Play mode tests for MonoBehaviour extension methods

### Changed
- Better tests for ObjectPool

### Removed
- Removed area and perimeter extension functions
- Removed Divide extension functions for Vector2Int

## [0.0.1] - 2021-01-24
### Added
- FiniteStateMachine class
- ObjectPool class and tests
- Extensions class with a collection of extension methods

[Unreleased]: https://github.com/CheesePie13/UnityPackages/compare/v0.1.0...HEAD
[0.1.0]: https://github.com/CheesePie13/UnityPackages/compare/v0.0.2...v0.1.0
[0.0.2]: https://github.com/CheesePie13/UnityPackages/compare/v0.0.1...v0.0.2
[0.0.1]: https://github.com/CheesePie13/UnityPackages/releases/tag/v0.0.1
