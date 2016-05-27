

ICompilationService Interface
=============================






Provides methods for compilation of a Razor page.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor.Compilation`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface ICompilationService








.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.Compilation.ICompilationService
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.Compilation.ICompilationService

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.Compilation.ICompilationService
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.Compilation.ICompilationService.Compile(Microsoft.AspNetCore.Mvc.Razor.Compilation.RelativeFileInfo, System.String)
    
        
    
        
        Compiles content and returns the result of compilation.
    
        
    
        
        :param fileInfo: The :any:`Microsoft.AspNetCore.Mvc.Razor.Compilation.RelativeFileInfo` for the Razor file that was compiled.
        
        :type fileInfo: Microsoft.AspNetCore.Mvc.Razor.Compilation.RelativeFileInfo
    
        
        :param compilationContent: The generated C# content to be compiled.
        
        :type compilationContent: System.String
        :rtype: Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult
        :return: 
            A :any:`Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult` representing the result of compilation.
    
        
        .. code-block:: csharp
    
            CompilationResult Compile(RelativeFileInfo fileInfo, string compilationContent)
    

