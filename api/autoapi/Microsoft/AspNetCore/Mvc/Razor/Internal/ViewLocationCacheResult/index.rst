

ViewLocationCacheResult Class
=============================






Result of view location cache lookup.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheResult`








Syntax
------

.. code-block:: csharp

    public class ViewLocationCacheResult








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheResult

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheResult.ViewLocationCacheResult(Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheItem, System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheItem>)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheResult`
        for a view that was successfully found at the specified location.
    
        
    
        
        :param view: The :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheItem` for the found view.
        
        :type view: Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheItem
    
        
        :param viewStarts: :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheItem`\s for applicable _ViewStarts.
        
        :type viewStarts: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheItem<Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheItem>}
    
        
        .. code-block:: csharp
    
            public ViewLocationCacheResult(ViewLocationCacheItem view, IReadOnlyList<ViewLocationCacheItem> viewStarts)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheResult.ViewLocationCacheResult(System.Collections.Generic.IEnumerable<System.String>)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheResult` for a
        failed view lookup.
    
        
    
        
        :param searchedLocations: Locations that were searched.
        
        :type searchedLocations: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public ViewLocationCacheResult(IEnumerable<string> searchedLocations)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheResult.SearchedLocations
    
        
    
        
        The sequence of locations that were searched.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<string> SearchedLocations { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheResult.Success
    
        
    
        
        Gets a value that indicates whether the view was successfully found.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Success { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheResult.ViewEntry
    
        
    
        
        :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheItem` for the located view.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheItem
    
        
        .. code-block:: csharp
    
            public ViewLocationCacheItem ViewEntry { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheResult.ViewStartEntries
    
        
    
        
        :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheItem`\s for applicable _ViewStarts.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheItem<Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheItem>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<ViewLocationCacheItem> ViewStartEntries { get; }
    

