

PrecompiledViewsCompilerCacheProvider Class
===========================================



.. contents:: 
   :local:



Summary
-------

An :any:`Microsoft.AspNet.Mvc.Razor.Compilation.ICompilerCacheProvider` that provides a :any:`Microsoft.AspNet.Mvc.Razor.Compilation.CompilerCache` instance
populated with precompiled views.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.Compilation.PrecompiledViewsCompilerCacheProvider`








Syntax
------

.. code-block:: csharp

   public class PrecompiledViewsCompilerCacheProvider : ICompilerCacheProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor/Compilation/PrecompiledViewsCompilerCacheProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.Compilation.PrecompiledViewsCompilerCacheProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Compilation.PrecompiledViewsCompilerCacheProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.Compilation.PrecompiledViewsCompilerCacheProvider.PrecompiledViewsCompilerCacheProvider(Microsoft.Extensions.PlatformAbstractions.IAssemblyLoadContextAccessor, Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Mvc.Razor.RazorViewEngineOptions>, System.Collections.Generic.IEnumerable<System.Reflection.Assembly>)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.Razor.Compilation.DefaultCompilerCacheProvider`\.
    
        
        
        
        :type loadContextAccessor: Microsoft.Extensions.PlatformAbstractions.IAssemblyLoadContextAccessor
        
        
        :type mvcViewOptions: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.AspNet.Mvc.Razor.RazorViewEngineOptions}
        
        
        :param assemblies: instances to scan for precompiled views.
        
        :type assemblies: System.Collections.Generic.IEnumerable{System.Reflection.Assembly}
    
        
        .. code-block:: csharp
    
           public PrecompiledViewsCompilerCacheProvider(IAssemblyLoadContextAccessor loadContextAccessor, IOptions<RazorViewEngineOptions> mvcViewOptions, IEnumerable<Assembly> assemblies)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Compilation.PrecompiledViewsCompilerCacheProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.Compilation.PrecompiledViewsCompilerCacheProvider.Cache
    
        
        :rtype: Microsoft.AspNet.Mvc.Razor.Compilation.ICompilerCache
    
        
        .. code-block:: csharp
    
           public ICompilerCache Cache { get; }
    

