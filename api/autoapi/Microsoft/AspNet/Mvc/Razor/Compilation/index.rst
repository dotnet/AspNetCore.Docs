

Microsoft.AspNet.Mvc.Razor.Compilation Namespace
================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNet/Mvc/Razor/Compilation/CompilationFailedException/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Razor/Compilation/CompilationOptionsProviderExtension/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Razor/Compilation/CompilationResult/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Razor/Compilation/CompilerCache/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Razor/Compilation/CompilerCacheResult/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Razor/Compilation/DefaultCompilerCacheProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Razor/Compilation/ExpressionRewriter/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Razor/Compilation/ICompilationService/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Razor/Compilation/ICompilerCache/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Razor/Compilation/ICompilerCacheProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Razor/Compilation/IRazorCompilationService/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Razor/Compilation/PrecompiledViewsCompilerCacheProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Razor/Compilation/RazorCompilationService/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Razor/Compilation/RelativeFileInfo/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Razor/Compilation/RoslynCompilationService/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Razor/Compilation/SyntaxTreeGenerator/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Razor/Compilation/UncachedCompilationResult/index
   
   











.. dn:namespace:: Microsoft.AspNet.Mvc.Razor.Compilation


    .. rubric:: Classes


    class :dn:cls:`Microsoft.AspNet.Mvc.Razor.Compilation.CompilationFailedException`
        An :any:`System.Exception` thrown when accessing the result of a failed compilation.


    class :dn:cls:`Microsoft.AspNet.Mvc.Razor.Compilation.CompilationOptionsProviderExtension`
        Extension methods for :any:`Microsoft.Dnx.Compilation.ICompilerOptionsProvider`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.Razor.Compilation.CompilationResult`
        Represents the result of compilation.


    class :dn:cls:`Microsoft.AspNet.Mvc.Razor.Compilation.CompilerCache`
        Caches the result of runtime compilation of Razor files for the duration of the application lifetime.


    class :dn:cls:`Microsoft.AspNet.Mvc.Razor.Compilation.CompilerCacheResult`
        Result of :any:`Microsoft.AspNet.Mvc.Razor.Compilation.ICompilerCache`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.Razor.Compilation.DefaultCompilerCacheProvider`
        Default implementation for :any:`Microsoft.AspNet.Mvc.Razor.Compilation.ICompilerCacheProvider`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.Razor.Compilation.ExpressionRewriter`
        An expression rewriter which can hoist a simple expression lambda into a private field.


    class :dn:cls:`Microsoft.AspNet.Mvc.Razor.Compilation.PrecompiledViewsCompilerCacheProvider`
        An :any:`Microsoft.AspNet.Mvc.Razor.Compilation.ICompilerCacheProvider` that provides a :any:`Microsoft.AspNet.Mvc.Razor.Compilation.CompilerCache` instance
        populated with precompiled views.


    class :dn:cls:`Microsoft.AspNet.Mvc.Razor.Compilation.RazorCompilationService`
        Default implementation of :any:`Microsoft.AspNet.Mvc.Razor.Compilation.IRazorCompilationService`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.Razor.Compilation.RelativeFileInfo`
        A container type that represents :any:`Microsoft.AspNet.FileProviders.IFileInfo` along with the application base relative path
        for a file in the file system.


    class :dn:cls:`Microsoft.AspNet.Mvc.Razor.Compilation.RoslynCompilationService`
        A type that uses Roslyn to compile C# content.


    class :dn:cls:`Microsoft.AspNet.Mvc.Razor.Compilation.SyntaxTreeGenerator`
        


    class :dn:cls:`Microsoft.AspNet.Mvc.Razor.Compilation.UncachedCompilationResult`
        Represents the result of compilation that does not come from the :any:`Microsoft.AspNet.Mvc.Razor.Compilation.ICompilerCache`\.


    .. rubric:: Interfaces


    interface :dn:iface:`Microsoft.AspNet.Mvc.Razor.Compilation.ICompilationService`
        Provides methods for compilation of a Razor page.


    interface :dn:iface:`Microsoft.AspNet.Mvc.Razor.Compilation.ICompilerCache`
        Caches the result of runtime compilation of Razor files for the duration of the app lifetime.


    interface :dn:iface:`Microsoft.AspNet.Mvc.Razor.Compilation.ICompilerCacheProvider`
        Provides access to a cached :any:`Microsoft.AspNet.Mvc.Razor.Compilation.ICompilerCache` instance.


    interface :dn:iface:`Microsoft.AspNet.Mvc.Razor.Compilation.IRazorCompilationService`
        Specifies the contracts for a service that compiles Razor files.


