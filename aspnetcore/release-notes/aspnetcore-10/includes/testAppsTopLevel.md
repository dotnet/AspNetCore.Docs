## Better support for testing apps with top-level statements

.NET 10 now has better support for testing apps that use top-level statements. Previously developers had to manually add `public partial class Program` to the `Program.cs` file so that the test project could reference the `Program class`. This is because the top-level statement feature in C# 9 generated a `Program class` that was declared as internal.

In .NET 10, a source generator is used to generate the `public partial class Program` declaration if the programmer did not declare it explicitly. In addition, an analyzer was added to detect when `public partial class Program` is declared explicitly and advise the developer to remove it.

![Image](https://github.com/user-attachments/assets/a37f0c81-a58a-453f-8da5-fa49356ca180)

The following PRs contribited to this feature:

- [PR 58199](https://github.com/dotnet/aspnetcore/pull/58199)
- [PR 58482](https://github.com/dotnet/aspnetcore/pull/58482)