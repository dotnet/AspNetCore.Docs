

ICompilationService Interface
=============================



.. contents:: 
   :local:



Summary
-------

Provides methods for compilation of a Razor page.











Syntax
------

.. code-block:: csharp

   public interface ICompilationService





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Razor/Compilation/ICompilationService.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Razor.Compilation.ICompilationService

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Razor.Compilation.ICompilationService
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Compilation.ICompilationService.Compile(Microsoft.AspNet.Mvc.Razor.Compilation.RelativeFileInfo, System.String)
    
        
    
        Compiles content and returns the result of compilation.
    
        
        
        
        :param fileInfo: The  for the Razor file that was compiled.
        
        :type fileInfo: Microsoft.AspNet.Mvc.Razor.Compilation.RelativeFileInfo
        
        
        :param compilationContent: The generated C# content to be compiled.
        
        :type compilationContent: System.String
        :rtype: Microsoft.AspNet.Mvc.Razor.Compilation.CompilationResult
        :return: A <see cref="T:Microsoft.AspNet.Mvc.Razor.Compilation.CompilationResult" /> representing the result of compilation.
    
        
        .. code-block:: csharp
    
           CompilationResult Compile(RelativeFileInfo fileInfo, string compilationContent)
    

