## Share interop code in a class library

JS interop code can be included in a class library, which allows you to share the code in a NuGet package.

The class library handles embedding JavaScript resources in the built assembly. The JavaScript files are placed in the *wwwroot* folder. The tooling takes care of embedding the resources when the library is built.

The built NuGet package is referenced in the app's project file the same way that any NuGet package is referenced. After the package is restored, app code can call into JavaScript as if it were C#.

For more information, see <xref:blazor/class-libraries>.
