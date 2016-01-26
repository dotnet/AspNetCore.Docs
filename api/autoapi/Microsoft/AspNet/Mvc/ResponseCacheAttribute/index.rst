

ResponseCacheAttribute Class
============================



.. contents:: 
   :local:



Summary
-------

Specifies the parameters necessary for setting appropriate headers in response caching.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Mvc.ResponseCacheAttribute`








Syntax
------

.. code-block:: csharp

   public class ResponseCacheAttribute : Attribute, _Attribute, IFilterFactory, IOrderedFilter, IFilterMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ResponseCacheAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ResponseCacheAttribute

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ResponseCacheAttribute
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ResponseCacheAttribute.CreateInstance(System.IServiceProvider)
    
        
        
        
        :type serviceProvider: System.IServiceProvider
        :rtype: Microsoft.AspNet.Mvc.Filters.IFilterMetadata
    
        
        .. code-block:: csharp
    
           public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ResponseCacheAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ResponseCacheAttribute.CacheProfileName
    
        
    
        Gets or sets the value of the cache profile name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string CacheProfileName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ResponseCacheAttribute.Duration
    
        
    
        Gets or sets the duration in seconds for which the response is cached.
        This sets "max-age" in "Cache-control" header.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Duration { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ResponseCacheAttribute.Location
    
        
    
        Gets or sets the location where the data from a particular URL must be cached.
    
        
        :rtype: Microsoft.AspNet.Mvc.ResponseCacheLocation
    
        
        .. code-block:: csharp
    
           public ResponseCacheLocation Location { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ResponseCacheAttribute.NoStore
    
        
    
        Gets or sets the value which determines whether the data should be stored or not.
        When set to <see langword="true" />, it sets "Cache-control" header to "no-store".
        Ignores the "Location" parameter for values other than "None".
        Ignores the "duration" parameter.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool NoStore { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ResponseCacheAttribute.Order
    
        
    
        The order of the filter.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Order { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ResponseCacheAttribute.VaryByHeader
    
        
    
        Gets or sets the value for the Vary response header.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string VaryByHeader { get; set; }
    

