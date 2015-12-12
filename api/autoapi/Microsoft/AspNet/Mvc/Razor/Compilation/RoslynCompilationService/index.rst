

RoslynCompilationService Class
==============================



.. contents:: 
   :local:



Summary
-------

A type that uses Roslyn to compile C# content.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.Compilation.RoslynCompilationService`








Syntax
------

.. code-block:: csharp

   public class RoslynCompilationService : ICompilationService





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Razor/Compilation/RoslynCompilationService.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.Compilation.RoslynCompilationService

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Compilation.RoslynCompilationService
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.Compilation.RoslynCompilationService.RoslynCompilationService(Microsoft.Extensions.PlatformAbstractions.IApplicationEnvironment, Microsoft.Dnx.Compilation.ILibraryExporter, Microsoft.Dnx.Compilation.ICompilerOptionsProvider, Microsoft.AspNet.Mvc.Razor.IMvcRazorHost, Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Mvc.Razor.RazorViewEngineOptions>)
    
        
    
        Initalizes a new instance of the :any:`Microsoft.AspNet.Mvc.Razor.Compilation.RoslynCompilationService` class.
    
        
        
        
        :param environment: The environment for the executing application.
        
        :type environment: Microsoft.Extensions.PlatformAbstractions.IApplicationEnvironment
        
        
        :type libraryExporter: Microsoft.Dnx.Compilation.ILibraryExporter
        
        
        :param compilerOptionsProvider: The  that provides Roslyn compilation settings.
        
        :type compilerOptionsProvider: Microsoft.Dnx.Compilation.ICompilerOptionsProvider
        
        
        :param host: The  that was used to generate the code.
        
        :type host: Microsoft.AspNet.Mvc.Razor.IMvcRazorHost
        
        
        :type optionsAccessor: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.AspNet.Mvc.Razor.RazorViewEngineOptions}
    
        
        .. code-block:: csharp
    
           public RoslynCompilationService(IApplicationEnvironment environment, ILibraryExporter libraryExporter, ICompilerOptionsProvider compilerOptionsProvider, IMvcRazorHost host, IOptions<RazorViewEngineOptions> optionsAccessor)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Compilation.RoslynCompilationService
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Compilation.RoslynCompilationService.Compile(Microsoft.AspNet.Mvc.Razor.Compilation.RelativeFileInfo, System.String)
    
        
        
        
        :type fileInfo: Microsoft.AspNet.Mvc.Razor.Compilation.RelativeFileInfo
        
        
        :type compilationContent: System.String
        :rtype: Microsoft.AspNet.Mvc.Razor.Compilation.CompilationResult
    
        
        .. code-block:: csharp
    
           public CompilationResult Compile(RelativeFileInfo fileInfo, string compilationContent)
    

