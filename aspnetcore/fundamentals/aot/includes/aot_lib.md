### Use libraries with Native AOT

Many popular libraries used in ASP.NET Core projects currently have some compatibility issues when they're incorporated into projects that target Native AOT, such as:

* Using reflection to inspect and discover types
* Loading libraries conditionally at runtime
* Generating code on the fly to implement functionality

Libraries that use these dynamic features require updates to work with Native AOT. Various tools are available for applying the necessary updates, such as [Roslyn source generators](/dotnet/csharp/roslyn-sdk/#source-generators).

Library authors hoping to support Native AOT are encouraged to review the following articles:

* [Native AOT deployment](/dotnet/core/deploying/native-aot)
* [Prepare .NET libraries for trimming](/dotnet/core/deploying/trimming/prepare-libraries-for-trimming)
