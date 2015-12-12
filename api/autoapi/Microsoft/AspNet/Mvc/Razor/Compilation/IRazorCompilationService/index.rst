

IRazorCompilationService Interface
==================================



.. contents:: 
   :local:



Summary
-------

Specifies the contracts for a service that compiles Razor files.











Syntax
------

.. code-block:: csharp

   public interface IRazorCompilationService





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Razor/Compilation/IRazorCompilationService.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Razor.Compilation.IRazorCompilationService

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Razor.Compilation.IRazorCompilationService
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Compilation.IRazorCompilationService.Compile(Microsoft.AspNet.Mvc.Razor.Compilation.RelativeFileInfo)
    
        
    
        Compiles the razor file located at ``fileInfo``.
    
        
        
        
        :param fileInfo: A  instance that represents the file to compile.
        
        :type fileInfo: Microsoft.AspNet.Mvc.Razor.Compilation.RelativeFileInfo
        :rtype: Microsoft.AspNet.Mvc.Razor.Compilation.CompilationResult
        :return: A <see cref="T:Microsoft.AspNet.Mvc.Razor.Compilation.CompilationResult" /> that represents the results of parsing and compiling the file.
    
        
        .. code-block:: csharp
    
           CompilationResult Compile(RelativeFileInfo fileInfo)
    

