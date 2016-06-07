

CompilerCache Class
===================






Caches the result of runtime compilation of Razor files for the duration of the application lifetime.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.Internal.CompilerCache`








Syntax
------

.. code-block:: csharp

    public class CompilerCache : ICompilerCache








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.CompilerCache
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.CompilerCache

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.CompilerCache
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.Internal.CompilerCache.CompilerCache(Microsoft.Extensions.FileProviders.IFileProvider)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.CompilerCache`\.
    
        
    
        
        :param fileProvider: :any:`Microsoft.Extensions.FileProviders.IFileProvider` used to locate Razor views.
        
        :type fileProvider: Microsoft.Extensions.FileProviders.IFileProvider
    
        
        .. code-block:: csharp
    
            public CompilerCache(IFileProvider fileProvider)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.Internal.CompilerCache.CompilerCache(Microsoft.Extensions.FileProviders.IFileProvider, System.Collections.Generic.IDictionary<System.String, System.Type>)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.CompilerCache` populated with precompiled views
        specified by <em>precompiledViews</em>.
    
        
    
        
        :param fileProvider: :any:`Microsoft.Extensions.FileProviders.IFileProvider` used to locate Razor views.
        
        :type fileProvider: Microsoft.Extensions.FileProviders.IFileProvider
    
        
        :param precompiledViews: A mapping of application relative paths of view to the precompiled view 
            :any:`System.Type`\s.
        
        :type precompiledViews: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Type<System.Type>}
    
        
        .. code-block:: csharp
    
            public CompilerCache(IFileProvider fileProvider, IDictionary<string, Type> precompiledViews)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.CompilerCache
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.Internal.CompilerCache.GetOrAdd(System.String, System.Func<Microsoft.AspNetCore.Mvc.Razor.Compilation.RelativeFileInfo, Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult>)
    
        
    
        
        :type relativePath: System.String
    
        
        :type compile: System.Func<System.Func`2>{Microsoft.AspNetCore.Mvc.Razor.Compilation.RelativeFileInfo<Microsoft.AspNetCore.Mvc.Razor.Compilation.RelativeFileInfo>, Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult<Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult>}
        :rtype: Microsoft.AspNetCore.Mvc.Razor.Internal.CompilerCacheResult
    
        
        .. code-block:: csharp
    
            public CompilerCacheResult GetOrAdd(string relativePath, Func<RelativeFileInfo, CompilationResult> compile)
    

