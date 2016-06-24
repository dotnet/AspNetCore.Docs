

ViewLocationCacheItem Struct
============================






An item in :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheResult`\.


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

    public struct ViewLocationCacheItem








.. dn:structure:: Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheItem
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheItem

Constructors
------------

.. dn:structure:: Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheItem
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheItem.ViewLocationCacheItem(System.Func<Microsoft.AspNetCore.Mvc.Razor.IRazorPage>, System.String)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheItem`\.
    
        
    
        
        :param razorPageFactory: The :any:`Microsoft.AspNetCore.Mvc.Razor.IRazorPage` factory.
        
        :type razorPageFactory: System.Func<System.Func`1>{Microsoft.AspNetCore.Mvc.Razor.IRazorPage<Microsoft.AspNetCore.Mvc.Razor.IRazorPage>}
    
        
        :param location: The application relative path of the :any:`Microsoft.AspNetCore.Mvc.Razor.IRazorPage`\.
        
        :type location: System.String
    
        
        .. code-block:: csharp
    
            public ViewLocationCacheItem(Func<IRazorPage> razorPageFactory, string location)
    

Properties
----------

.. dn:structure:: Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheItem
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheItem.Location
    
        
    
        
        Gets the application relative path of the :any:`Microsoft.AspNetCore.Mvc.Razor.IRazorPage`
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Location { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheItem.PageFactory
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.Razor.IRazorPage` factory.
    
        
        :rtype: System.Func<System.Func`1>{Microsoft.AspNetCore.Mvc.Razor.IRazorPage<Microsoft.AspNetCore.Mvc.Razor.IRazorPage>}
    
        
        .. code-block:: csharp
    
            public Func<IRazorPage> PageFactory { get; }
    

