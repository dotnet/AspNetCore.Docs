### Libraries and native AOT

Many of the popular libraries used in ASP.NET Core projects currently have some compatibility issues when used in a project targeting native AOT, such as:

* Use of reflection to inspect and discover types.
* Conditionally loading libraries at runtime.
* Generating code on the fly to implement functionality.

Libraries using these dynamic features need to be updated in order to work with native AOT. They can be updated using tools like Roslyn source generators.

Library authors hoping to support native AOT are encouraged to:

* Read about [native AOT compatibility requirements](/dotnet/core/deploying/native-aot/?tabs=net8plus).
* [Prepare the library for trimming](/dotnet/core/deploying/trimming/prepare-libraries-for-trimming).
