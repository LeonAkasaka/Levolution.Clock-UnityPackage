# Levolution.Clock-UnityPackage

A time provider abstraction library for Unity that allows switching between different time sources through a unified `IClock` interface.

## Features

- **System Clock**: Real-time clock based on system time (unaffected by Unity's time scale)
- **Manual Clock**: Manually controlled clock for testing and debugging
- **Cached Clock**: Clock that caches time values within the same frame for consistency

## Installation

### Unity Package Manager (recommended)

Add the following to your `manifest.json` in the `Packages` folder:

```json
{
  "dependencies": {
    "levolution.clock": "https://github.com/LeonAkasaka/Levolution.Clock-UnityPackage.git"
  }
}
```

### Git URL

In Unity Package Manager, click "Add package from git URL" and enter:

``` text
https://github.com/LeonAkasaka/Levolution.Clock-UnityPackage.git
```

## Usage

### Basic Usage

```csharp
using Levolution.Clock;

// Use system clock
IClock systemClock = Clocks.System;
float currentTime = systemClock.GetTime();

// Use manual clock for testing
var manualClock = new ManualClock();
manualClock.CurrentTime = 123.45f;
float testTime = manualClock.GetTime(); // Returns 123.45

// Use cached clock for frame consistency
var cachedClock = new CachedClock(Clocks.System);
float frameTime1 = cachedClock.GetTime();
float frameTime2 = cachedClock.GetTime(); // Same value as frameTime1

// Update cached clock (typically once per frame)
cachedClock.Update();
float newFrameTime = cachedClock.GetTime(); // Updated value
```

## Clock Types

| Clock Type | Description | Use Case |
|------------|-------------|----------|
| `SystemClock` | Real-time based on system clock | Accurate timing, unaffected by Unity time scale |
| `ManualClock` | Manually controlled time | Testing, debugging, replay systems |
| `CachedClock` | Caches time within frames | Consistent timing across frame operations |

## Requirements

- Unity 6 or later (tested)
- Probably compatible with earlier versions (not tested - the package uses only standard C# features)
- No additional dependencies

## Changelog

See [CHANGELOG.md](CHANGELOG.md) for version history and release notes.

## License

MIT License - see [LICENSE](LICENSE) file for details.
