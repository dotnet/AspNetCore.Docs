

RazorCompilationService Class
=============================



.. contents:: 
   :local:



Summary
-------

Default implementation of :any:`Microsoft.AspNet.Mvc.Razor.Compilation.IRazorCompilationService`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.Compilation.RazorCompilationService`








Syntax
------

.. code-block:: csharp

   public class RazorCompilationService : IRazorCompilationService





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor/Compilation/RazorCompilationService.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.Compilation.RazorCompilationService

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Compilation.RazorCompilationService
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.Compilation.RazorCompilationService.RazorCompilationService(Microsoft.AspNet.Mvc.Razor.Compilation.ICompilationService, Microsoft.AspNet.Mvc.Razor.IMvcRazorHost, Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Mvc.Razor.RazorViewEngineOptions>)
    
        
    
        Instantiates a new instance of the :any:`Microsoft.AspNet.Mvc.Razor.Compilation.RazorCompilationService` class.
    
        
        
        
        :param compilationService: The  to compile generated code.
        
        :type compilationService: Microsoft.AspNet.Mvc.Razor.Compilation.ICompilationService
        
        
        :param razorHost: The  to generate code from Razor files.
        
        :type razorHost: Microsoft.AspNet.Mvc.Razor.IMvcRazorHost
        
        
        :param viewEngineOptions: The  to read Razor files referenced in error messages.
        
        :type viewEngineOptions: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.AspNet.Mvc.Razor.RazorViewEngineOptions}
    
        
        .. code-block:: csharp
    
           public RazorCompilationService(ICompilationService compilationService, IMvcRazorHost razorHost, IOptions<RazorViewEngineOptions> viewEngineOptions)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Compilation.RazorCompilationService
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Compilation.RazorCompilationService.Compile(Microsoft.AspNet.Mvc.Razor.Compilation.RelativeFileInfo)
    
        
        
        
        :type file: Microsoft.AspNet.Mvc.Razor.Compilation.RelativeFileInfo
        :rtype: Microsoft.AspNet.Mvc.Razor.Compilation.CompilationResult
    
        
        .. code-block:: csharp
    
           public CompilationResult Compile(RelativeFileInfo file)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Compilation.RazorCompilationService.GenerateCode(System.String, System.IO.Stream)
    
        
    
        Generate code for the Razor file at ``relativePath`` with content
        ``inputStream``.
    
        
        
        
        :param relativePath: The path of the Razor file relative to the root of the application. Used to generate line pragmas and
            calculate the class name of the generated type.
        
        :type relativePath: System.String
        
        
        :param inputStream: A  that contains the Razor content.
        
        :type inputStream: System.IO.Stream
        :rtype: Microsoft.AspNet.Razor.CodeGenerators.GeneratorResults
        :return: A <see cref="T:Microsoft.AspNet.Razor.CodeGenerators.GeneratorResults" /> instance containing results of code generation.
    
        
        .. code-block:: csharp
    
           protected virtual GeneratorResults GenerateCode(string relativePath, Stream inputStream)
    

