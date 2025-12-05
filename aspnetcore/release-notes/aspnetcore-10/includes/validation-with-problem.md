### Minimal API Validation integration with IProblemDetailsService
<!-- https://github.com/dotnet/aspnetcore/pull/62066 -->

Error responses from the validation logic for Minimal APIs can now be customized by an `IProblemDetailsService` implementation provided in the application services collection (Dependency Injection container). This enables more consistent and user-specific error responses.
