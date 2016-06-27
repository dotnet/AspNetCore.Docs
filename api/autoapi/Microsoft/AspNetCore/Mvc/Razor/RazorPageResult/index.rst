

RazorPageResult Struct
======================






Result of locating a :any:`Microsoft.AspNetCore.Mvc.Razor.IRazorPage`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public struct RazorPageResult








.. dn:structure:: Microsoft.AspNetCore.Mvc.Razor.RazorPageResult
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Mvc.Razor.RazorPageResult

Constructors
------------

.. dn:structure:: Microsoft.AspNetCore.Mvc.Razor.RazorPageResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.RazorPageResult.RazorPageResult(System.String, Microsoft.AspNetCore.Mvc.Razor.IRazorPage)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Razor.RazorPageResult` for a successful discovery.
    
        
    
        
        :param name: The name of the page that was found.
        
        :type name: System.String
    
        
        :param page: The located :any:`Microsoft.AspNetCore.Mvc.Razor.IRazorPage`\.
        
        :type page: Microsoft.AspNetCore.Mvc.Razor.IRazorPage
    
        
        .. code-block:: csharp
    
            public RazorPageResult(string name, IRazorPage page)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.RazorPageResult.RazorPageResult(System.String, System.Collections.Generic.IEnumerable<System.String>)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Razor.RazorPageResult` for an unsuccessful discovery.
    
        
    
        
        :param name: The name of the page that was not found.
        
        :type name: System.String
    
        
        :param searchedLocations: The locations that were searched.
        
        :type searchedLocations: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public RazorPageResult(string name, IEnumerable<string> searchedLocations)
    

Properties
----------

.. dn:structure:: Microsoft.AspNetCore.Mvc.Razor.RazorPageResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.RazorPageResult.Name
    
        
    
        
        Gets the name or the path of the page being located.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.RazorPageResult.Page
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.Razor.IRazorPage` if found.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Razor.IRazorPage
    
        
        .. code-block:: csharp
    
            public IRazorPage Page { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.RazorPageResult.SearchedLocations
    
        
    
        
        Gets the locations that were searched when :dn:prop:`Microsoft.AspNetCore.Mvc.Razor.RazorPageResult.Page` could not be found.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<string> SearchedLocations { get; }
    

