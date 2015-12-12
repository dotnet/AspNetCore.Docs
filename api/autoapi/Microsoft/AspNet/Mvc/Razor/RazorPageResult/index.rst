

RazorPageResult Class
=====================



.. contents:: 
   :local:



Summary
-------

Represents the results of locating a :any:`Microsoft.AspNet.Mvc.Razor.IRazorPage`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.RazorPageResult`








Syntax
------

.. code-block:: csharp

   public class RazorPageResult





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Razor/RazorPageResult.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.RazorPageResult

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.RazorPageResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.RazorPageResult.RazorPageResult(System.String, Microsoft.AspNet.Mvc.Razor.IRazorPage)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.Razor.RazorPageResult` for a successful discovery.
    
        
        
        
        :param name: The name of the page that was located.
        
        :type name: System.String
        
        
        :param page: The located .
        
        :type page: Microsoft.AspNet.Mvc.Razor.IRazorPage
    
        
        .. code-block:: csharp
    
           public RazorPageResult(string name, IRazorPage page)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.RazorPageResult.RazorPageResult(System.String, System.Collections.Generic.IEnumerable<System.String>)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.Razor.RazorPageResult` for an unsuccessful discovery.
    
        
        
        
        :param name: The name of the page that was located.
        
        :type name: System.String
        
        
        :param searchedLocations: The locations that were searched.
        
        :type searchedLocations: System.Collections.Generic.IEnumerable{System.String}
    
        
        .. code-block:: csharp
    
           public RazorPageResult(string name, IEnumerable<string> searchedLocations)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.RazorPageResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.RazorPageResult.Name
    
        
    
        Gets the name of the page being located.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Name { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.RazorPageResult.Page
    
        
    
        Gets the :any:`Microsoft.AspNet.Mvc.Razor.IRazorPage` if found.
    
        
        :rtype: Microsoft.AspNet.Mvc.Razor.IRazorPage
    
        
        .. code-block:: csharp
    
           public IRazorPage Page { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.RazorPageResult.SearchedLocations
    
        
    
        Gets the locations that were searched when :dn:prop:`Microsoft.AspNet.Mvc.Razor.RazorPageResult.Page` could not be located.
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.String}
    
        
        .. code-block:: csharp
    
           public IEnumerable<string> SearchedLocations { get; }
    

