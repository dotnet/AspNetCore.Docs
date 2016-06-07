

IRazorCompilationService Interface
==================================






Specifies the contracts for a service that compiles Razor files.


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

    public interface IRazorCompilationService








.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.Compilation.IRazorCompilationService
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.Compilation.IRazorCompilationService

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.Compilation.IRazorCompilationService
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.Compilation.IRazorCompilationService.Compile(Microsoft.AspNetCore.Mvc.Razor.Compilation.RelativeFileInfo)
    
        
    
        
        Compiles the razor file located at <em>fileInfo</em>.
    
        
    
        
        :param fileInfo: A :any:`Microsoft.AspNetCore.Mvc.Razor.Compilation.RelativeFileInfo` instance that represents the file to compile.
            
        
        :type fileInfo: Microsoft.AspNetCore.Mvc.Razor.Compilation.RelativeFileInfo
        :rtype: Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult
        :return: 
            A :any:`Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult` that represents the results of parsing and compiling the file.
    
        
        .. code-block:: csharp
    
            CompilationResult Compile(RelativeFileInfo fileInfo)
    

