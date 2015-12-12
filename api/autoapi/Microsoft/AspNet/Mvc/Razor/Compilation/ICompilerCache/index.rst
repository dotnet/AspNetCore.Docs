

ICompilerCache Interface
========================



.. contents:: 
   :local:



Summary
-------

Caches the result of runtime compilation of Razor files for the duration of the app lifetime.











Syntax
------

.. code-block:: csharp

   public interface ICompilerCache





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor/Compilation/ICompilerCache.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Razor.Compilation.ICompilerCache

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Razor.Compilation.ICompilerCache
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Compilation.ICompilerCache.GetOrAdd(System.String, System.Func<Microsoft.AspNet.Mvc.Razor.Compilation.RelativeFileInfo, Microsoft.AspNet.Mvc.Razor.Compilation.CompilationResult>)
    
        
    
        Get an existing compilation result, or create and add a new one if it is
        not available in the cache or is expired.
    
        
        
        
        :param relativePath: Application relative path to the file.
        
        :type relativePath: System.String
        
        
        :param compile: An delegate that will generate a compilation result.
        
        :type compile: System.Func{Microsoft.AspNet.Mvc.Razor.Compilation.RelativeFileInfo,Microsoft.AspNet.Mvc.Razor.Compilation.CompilationResult}
        :rtype: Microsoft.AspNet.Mvc.Razor.Compilation.CompilerCacheResult
        :return: A cached <see cref="T:Microsoft.AspNet.Mvc.Razor.Compilation.CompilationResult" />.
    
        
        .. code-block:: csharp
    
           CompilerCacheResult GetOrAdd(string relativePath, Func<RelativeFileInfo, CompilationResult> compile)
    

