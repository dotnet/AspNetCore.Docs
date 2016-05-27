

RazorCompilationService Class
=============================






Default implementation of :any:`Microsoft.AspNetCore.Mvc.Razor.Compilation.IRazorCompilationService`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.Internal.RazorCompilationService`








Syntax
------

.. code-block:: csharp

    public class RazorCompilationService : IRazorCompilationService








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.RazorCompilationService
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.RazorCompilationService

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.RazorCompilationService
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.Internal.RazorCompilationService.RazorCompilationService(Microsoft.AspNetCore.Mvc.Razor.Compilation.ICompilationService, Microsoft.AspNetCore.Mvc.Razor.IMvcRazorHost, Microsoft.AspNetCore.Mvc.Razor.Internal.IRazorViewEngineFileProviderAccessor, Microsoft.Extensions.Logging.ILoggerFactory)
    
        
    
        
        Instantiates a new instance of the :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.RazorCompilationService` class.
    
        
    
        
        :param compilationService: The :any:`Microsoft.AspNetCore.Mvc.Razor.Compilation.ICompilationService` to compile generated code.
        
        :type compilationService: Microsoft.AspNetCore.Mvc.Razor.Compilation.ICompilationService
    
        
        :param razorHost: The :any:`Microsoft.AspNetCore.Mvc.Razor.IMvcRazorHost` to generate code from Razor files.
        
        :type razorHost: Microsoft.AspNetCore.Mvc.Razor.IMvcRazorHost
    
        
        :param fileProviderAccessor: The :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.IRazorViewEngineFileProviderAccessor`\.
        
        :type fileProviderAccessor: Microsoft.AspNetCore.Mvc.Razor.Internal.IRazorViewEngineFileProviderAccessor
    
        
        :param loggerFactory: The :any:`Microsoft.Extensions.Logging.ILoggerFactory`\.
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public RazorCompilationService(ICompilationService compilationService, IMvcRazorHost razorHost, IRazorViewEngineFileProviderAccessor fileProviderAccessor, ILoggerFactory loggerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.RazorCompilationService
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.Internal.RazorCompilationService.Compile(Microsoft.AspNetCore.Mvc.Razor.Compilation.RelativeFileInfo)
    
        
    
        
        :type file: Microsoft.AspNetCore.Mvc.Razor.Compilation.RelativeFileInfo
        :rtype: Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult
    
        
        .. code-block:: csharp
    
            public CompilationResult Compile(RelativeFileInfo file)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.Internal.RazorCompilationService.GenerateCode(System.String, System.IO.Stream)
    
        
    
        
        Generate code for the Razor file at <em>relativePath</em> with content
        <em>inputStream</em>.
    
        
    
        
        :param relativePath: 
            The path of the Razor file relative to the root of the application. Used to generate line pragmas and
            calculate the class name of the generated type.
        
        :type relativePath: System.String
    
        
        :param inputStream: A :any:`System.IO.Stream` that contains the Razor content.
        
        :type inputStream: System.IO.Stream
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratorResults
        :return: A :any:`Microsoft.AspNetCore.Razor.CodeGenerators.GeneratorResults` instance containing results of code generation.
    
        
        .. code-block:: csharp
    
            protected virtual GeneratorResults GenerateCode(string relativePath, Stream inputStream)
    

