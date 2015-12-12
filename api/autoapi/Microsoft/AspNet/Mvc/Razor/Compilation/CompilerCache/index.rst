

CompilerCache Class
===================



.. contents:: 
   :local:



Summary
-------

Caches the result of runtime compilation of Razor files for the duration of the application lifetime.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.Compilation.CompilerCache`








Syntax
------

.. code-block:: csharp

   public class CompilerCache : ICompilerCache





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Razor/Compilation/CompilerCache.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.Compilation.CompilerCache

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Compilation.CompilerCache
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.Compilation.CompilerCache.CompilerCache(Microsoft.AspNet.FileProviders.IFileProvider)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.Razor.Compilation.CompilerCache`\.
    
        
        
        
        :param fileProvider: used to locate Razor views.
        
        :type fileProvider: Microsoft.AspNet.FileProviders.IFileProvider
    
        
        .. code-block:: csharp
    
           public CompilerCache(IFileProvider fileProvider)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.Compilation.CompilerCache.CompilerCache(Microsoft.AspNet.FileProviders.IFileProvider, System.Collections.Generic.IDictionary<System.String, System.Type>)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.Razor.Compilation.CompilerCache` populated with precompiled views
        specified by ``precompiledViews``.
    
        
        
        
        :param fileProvider: used to locate Razor views.
        
        :type fileProvider: Microsoft.AspNet.FileProviders.IFileProvider
        
        
        :param precompiledViews: A mapping of application relative paths of view to the precompiled view
            s.
        
        :type precompiledViews: System.Collections.Generic.IDictionary{System.String,System.Type}
    
        
        .. code-block:: csharp
    
           public CompilerCache(IFileProvider fileProvider, IDictionary<string, Type> precompiledViews)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Compilation.CompilerCache
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Compilation.CompilerCache.GetOrAdd(System.String, System.Func<Microsoft.AspNet.Mvc.Razor.Compilation.RelativeFileInfo, Microsoft.AspNet.Mvc.Razor.Compilation.CompilationResult>)
    
        
        
        
        :type relativePath: System.String
        
        
        :type compile: System.Func{Microsoft.AspNet.Mvc.Razor.Compilation.RelativeFileInfo,Microsoft.AspNet.Mvc.Razor.Compilation.CompilationResult}
        :rtype: Microsoft.AspNet.Mvc.Razor.Compilation.CompilerCacheResult
    
        
        .. code-block:: csharp
    
           public CompilerCacheResult GetOrAdd(string relativePath, Func<RelativeFileInfo, CompilationResult> compile)
    

