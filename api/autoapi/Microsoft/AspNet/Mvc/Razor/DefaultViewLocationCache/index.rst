

DefaultViewLocationCache Class
==============================



.. contents:: 
   :local:



Summary
-------

Default implementation of :any:`Microsoft.AspNet.Mvc.Razor.IViewLocationCache`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.DefaultViewLocationCache`








Syntax
------

.. code-block:: csharp

   public class DefaultViewLocationCache : IViewLocationCache





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor/DefaultViewLocationCache.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.DefaultViewLocationCache

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.DefaultViewLocationCache
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.DefaultViewLocationCache.DefaultViewLocationCache()
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.Razor.DefaultViewLocationCache`\.
    
        
    
        
        .. code-block:: csharp
    
           public DefaultViewLocationCache()
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.DefaultViewLocationCache
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.DefaultViewLocationCache.Get(Microsoft.AspNet.Mvc.Razor.ViewLocationExpanderContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Razor.ViewLocationExpanderContext
        :rtype: Microsoft.AspNet.Mvc.Razor.ViewLocationCacheResult
    
        
        .. code-block:: csharp
    
           public ViewLocationCacheResult Get(ViewLocationExpanderContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.DefaultViewLocationCache.Set(Microsoft.AspNet.Mvc.Razor.ViewLocationExpanderContext, Microsoft.AspNet.Mvc.Razor.ViewLocationCacheResult)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Razor.ViewLocationExpanderContext
        
        
        :type value: Microsoft.AspNet.Mvc.Razor.ViewLocationCacheResult
    
        
        .. code-block:: csharp
    
           public void Set(ViewLocationExpanderContext context, ViewLocationCacheResult value)
    

