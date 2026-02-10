### `TimeProvider` support in ASP.NET Core Identity

ASP.NET Core Identity now uses `TimeProvider` instead of `DateTime` and `DateTimeOffset` for all time-related operations. This change makes Identity components more testable and provides better control over time in tests and specialized scenarios.

The following example shows how to use a fake `TimeProvider` for testing Identity features:

```csharp
// In tests
var fakeTimeProvider = new FakeTimeProvider(
    new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero));

services.AddSingleton<TimeProvider>(fakeTimeProvider);
services.AddIdentity<IdentityUser, IdentityRole>();

// Identity will now use the fake time provider
```

By using `TimeProvider`, you can more easily write deterministic tests for time-sensitive Identity features such as token expiration, lockout durations, and security stamp validation.