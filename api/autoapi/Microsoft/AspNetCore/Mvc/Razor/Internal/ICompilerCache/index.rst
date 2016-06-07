

ICompilerCache Interface
========================






Caches the result of runtime compilation of Razor files for the duration of the app lifetime.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface ICompilerCache








.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.Internal.ICompilerCache
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.Internal.ICompilerCache

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.Internal.ICompilerCache
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.Internal.ICompilerCache.GetOrAdd(System.String, System.Func<Microsoft.AspNetCore.Mvc.Razor.Compilation.RelativeFileInfo, Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult>)
    
        
    
        
        Get an existing compilation result, or create and add a new one if it is
        not available in the cache or is expired.
    
        
    
        
        :param relativePath: Application relative path to the file.
        
        :type relativePath: System.String
    
        
        :param compile: An delegate that will generate a compilation result.
        
        :type compile: System.Func<System.Func`2>{Microsoft.AspNetCore.Mvc.Razor.Compilation.RelativeFileInfo<Microsoft.AspNetCore.Mvc.Razor.Compilation.RelativeFileInfo>, Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult<Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult>}
        :rtype: Microsoft.AspNetCore.Mvc.Razor.Internal.CompilerCacheResult
        :return: A cached :any:`Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult`\.
    
        
        .. code-block:: csharp
    
            CompilerCacheResult GetOrAdd(string relativePath, Func<RelativeFileInfo, CompilationResult> compile)
    

