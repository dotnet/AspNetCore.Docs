

CacheProfile Class
==================



.. contents:: 
   :local:



Summary
-------

Defines a set of settings which can be used for response caching.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.CacheProfile`








Syntax
------

.. code-block:: csharp

   public class CacheProfile





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/CacheProfile.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.CacheProfile

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.CacheProfile
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.CacheProfile.Duration
    
        
    
        Gets or sets the duration in seconds for which the response is cached.
        If this property is set to a non null value,
        the "max-age" in "Cache-control" header is set in the 
        :dn:prop:`Microsoft.AspNet.Http.HttpContext.Response`\.
    
        
        :rtype: System.Nullable{System.Int32}
    
        
        .. code-block:: csharp
    
           public int ? Duration { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.CacheProfile.Location
    
        
    
        Gets or sets the location where the data from a particular URL must be cached.
        If this property is set to a non null value,
        the "Cache-control" header is set in the :dn:prop:`Microsoft.AspNet.Http.HttpContext.Response`\.
    
        
        :rtype: System.Nullable{Microsoft.AspNet.Mvc.ResponseCacheLocation}
    
        
        .. code-block:: csharp
    
           public ResponseCacheLocation? Location { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.CacheProfile.NoStore
    
        
    
        Gets or sets the value which determines whether the data should be stored or not.
        When set to <see langword="true" />, it sets "Cache-control" header in 
        :dn:prop:`Microsoft.AspNet.Http.HttpContext.Response` to "no-store".
        Ignores the "Location" parameter for values other than "None".
        Ignores the "Duration" parameter.
    
        
        :rtype: System.Nullable{System.Boolean}
    
        
        .. code-block:: csharp
    
           public bool ? NoStore { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.CacheProfile.VaryByHeader
    
        
    
        Gets or sets the value for the Vary header in :dn:prop:`Microsoft.AspNet.Http.HttpContext.Response`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string VaryByHeader { get; set; }
    

