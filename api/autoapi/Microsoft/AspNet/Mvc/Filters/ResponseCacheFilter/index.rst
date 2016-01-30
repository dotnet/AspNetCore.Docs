

ResponseCacheFilter Class
=========================



.. contents:: 
   :local:



Summary
-------

An :any:`Microsoft.AspNet.Mvc.Filters.ActionFilterAttribute` which sets the appropriate headers related to response caching.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Filters.ResponseCacheFilter`








Syntax
------

.. code-block:: csharp

   public class ResponseCacheFilter : IResponseCacheFilter, IActionFilter, IFilterMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/Filters/ResponseCacheFilter.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Filters.ResponseCacheFilter

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.ResponseCacheFilter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Filters.ResponseCacheFilter.ResponseCacheFilter(Microsoft.AspNet.Mvc.CacheProfile)
    
        
    
        Creates a new instance of :any:`Microsoft.AspNet.Mvc.Filters.ResponseCacheFilter`
    
        
        
        
        :param cacheProfile: The profile which contains the settings for
            .
        
        :type cacheProfile: Microsoft.AspNet.Mvc.CacheProfile
    
        
        .. code-block:: csharp
    
           public ResponseCacheFilter(CacheProfile cacheProfile)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.ResponseCacheFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.ResponseCacheFilter.OnActionExecuted(Microsoft.AspNet.Mvc.Filters.ActionExecutedContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.ActionExecutedContext
    
        
        .. code-block:: csharp
    
           public void OnActionExecuted(ActionExecutedContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.ResponseCacheFilter.OnActionExecuting(Microsoft.AspNet.Mvc.Filters.ActionExecutingContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.ActionExecutingContext
    
        
        .. code-block:: csharp
    
           public void OnActionExecuting(ActionExecutingContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.ResponseCacheFilter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.ResponseCacheFilter.Duration
    
        
    
        Gets or sets the duration in seconds for which the response is cached.
        This is a required parameter.
        This sets "max-age" in "Cache-control" header.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Duration { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.ResponseCacheFilter.Location
    
        
    
        Gets or sets the location where the data from a particular URL must be cached.
    
        
        :rtype: Microsoft.AspNet.Mvc.ResponseCacheLocation
    
        
        .. code-block:: csharp
    
           public ResponseCacheLocation Location { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.ResponseCacheFilter.NoStore
    
        
    
        Gets or sets the value which determines whether the data should be stored or not.
        When set to <see langword="true" />, it sets "Cache-control" header to "no-store".
        Ignores the "Location" parameter for values other than "None".
        Ignores the "duration" parameter.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool NoStore { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.ResponseCacheFilter.VaryByHeader
    
        
    
        Gets or sets the value for the Vary response header.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string VaryByHeader { get; set; }
    

