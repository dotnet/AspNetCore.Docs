

ViewLocationCacheResult Struct
==============================



.. contents:: 
   :local:



Summary
-------

Result of :any:`Microsoft.AspNet.Mvc.Razor.IViewLocationCache` lookups.











Syntax
------

.. code-block:: csharp

   public struct ViewLocationCacheResult : IEquatable<ViewLocationCacheResult>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Razor/ViewLocationCacheResult.cs>`_





.. dn:structure:: Microsoft.AspNet.Mvc.Razor.ViewLocationCacheResult

Constructors
------------

.. dn:structure:: Microsoft.AspNet.Mvc.Razor.ViewLocationCacheResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.ViewLocationCacheResult.ViewLocationCacheResult(System.Collections.Generic.IEnumerable<System.String>)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.Razor.ViewLocationCacheResult` for a
        failed view lookup.
    
        
        
        
        :param searchedLocations: Locations that were searched.
        
        :type searchedLocations: System.Collections.Generic.IEnumerable{System.String}
    
        
        .. code-block:: csharp
    
           public ViewLocationCacheResult(IEnumerable<string> searchedLocations)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.ViewLocationCacheResult.ViewLocationCacheResult(System.String, System.Collections.Generic.IEnumerable<System.String>)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.Razor.ViewLocationCacheResult`
        for a view that was successfully found at the specified location.
    
        
        
        
        :param foundLocation: The view location.
        
        :type foundLocation: System.String
        
        
        :param searchedLocations: Locations that were searched
            in addition to .
        
        :type searchedLocations: System.Collections.Generic.IEnumerable{System.String}
    
        
        .. code-block:: csharp
    
           public ViewLocationCacheResult(string foundLocation, IEnumerable<string> searchedLocations)
    

Methods
-------

.. dn:structure:: Microsoft.AspNet.Mvc.Razor.ViewLocationCacheResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.ViewLocationCacheResult.Equals(Microsoft.AspNet.Mvc.Razor.ViewLocationCacheResult)
    
        
        
        
        :type other: Microsoft.AspNet.Mvc.Razor.ViewLocationCacheResult
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Equals(ViewLocationCacheResult other)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.ViewLocationCacheResult.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    

Fields
------

.. dn:structure:: Microsoft.AspNet.Mvc.Razor.ViewLocationCacheResult
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Mvc.Razor.ViewLocationCacheResult.None
    
        
    
        A :any:`Microsoft.AspNet.Mvc.Razor.ViewLocationCacheResult` that represents a cache miss.
    
        
    
        
        .. code-block:: csharp
    
           public static readonly ViewLocationCacheResult None
    

Properties
----------

.. dn:structure:: Microsoft.AspNet.Mvc.Razor.ViewLocationCacheResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.ViewLocationCacheResult.IsFoundResult
    
        
    
        Gets a value that indicates whether the view was successfully found.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsFoundResult { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.ViewLocationCacheResult.SearchedLocations
    
        
    
        The sequence of locations that were searched.
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.String}
    
        
        .. code-block:: csharp
    
           public IEnumerable<string> SearchedLocations { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.ViewLocationCacheResult.ViewLocation
    
        
    
        The location the view was found.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ViewLocation { get; }
    

