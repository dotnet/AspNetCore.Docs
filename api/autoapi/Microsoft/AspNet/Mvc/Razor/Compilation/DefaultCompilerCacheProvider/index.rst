

DefaultCompilerCacheProvider Class
==================================



.. contents:: 
   :local:



Summary
-------

Default implementation for :any:`Microsoft.AspNet.Mvc.Razor.Compilation.ICompilerCacheProvider`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.Compilation.DefaultCompilerCacheProvider`








Syntax
------

.. code-block:: csharp

   public class DefaultCompilerCacheProvider : ICompilerCacheProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Razor/Compilation/DefaultCompilerCacheProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.Compilation.DefaultCompilerCacheProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Compilation.DefaultCompilerCacheProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.Compilation.DefaultCompilerCacheProvider.DefaultCompilerCacheProvider(Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Mvc.Razor.RazorViewEngineOptions>)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.Razor.Compilation.DefaultCompilerCacheProvider`\.
    
        
        
        
        :type mvcViewOptions: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.AspNet.Mvc.Razor.RazorViewEngineOptions}
    
        
        .. code-block:: csharp
    
           public DefaultCompilerCacheProvider(IOptions<RazorViewEngineOptions> mvcViewOptions)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Compilation.DefaultCompilerCacheProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.Compilation.DefaultCompilerCacheProvider.Cache
    
        
        :rtype: Microsoft.AspNet.Mvc.Razor.Compilation.ICompilerCache
    
        
        .. code-block:: csharp
    
           public ICompilerCache Cache { get; }
    

