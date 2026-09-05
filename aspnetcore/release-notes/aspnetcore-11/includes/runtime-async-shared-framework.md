### Runtime-async enabled for shared framework libraries

ASP.NET Core's shared-framework-only libraries are now compiled with the `runtime-async` feature on `net11.0+`. Runtime-async lets the runtime, rather than the C# compiler, generate the state machine for `async`/`await`, which can reduce per-await allocations and improve diagnostics. This is an internal codegen change with no public API impact — apps targeting `net11.0` automatically benefit when they call into the affected ASP.NET Core libraries.

Libraries that ship as both shared-framework members and standalone NuGet packages are excluded, because runtime-async is incompatible with WebAssembly and would otherwise break Wasm consumers of those packages.

Because runtime-async changes how `async`/`await` is generated for a large portion of the ASP.NET Core stack, try your apps against this preview and [file an issue](https://github.com/dotnet/aspnetcore/issues/new/choose) if you hit unexpected behavior, particularly around exception stacks, `ExecutionContext`/`AsyncLocal` flow, or anything that looks like a regression from .NET 10.
