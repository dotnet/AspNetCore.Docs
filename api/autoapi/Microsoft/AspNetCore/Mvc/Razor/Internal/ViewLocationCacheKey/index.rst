

ViewLocationCacheKey Struct
===========================






Key for entries in :dn:prop:`Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine.ViewLookupCache`\.


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

    public struct ViewLocationCacheKey : IEquatable<ViewLocationCacheKey>








.. dn:structure:: Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheKey
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheKey

Properties
----------

.. dn:structure:: Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheKey
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheKey.AreaName
    
        
    
        
        Gets the area name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string AreaName
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheKey.ControllerName
    
        
    
        
        Gets the controller name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ControllerName
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheKey.IsMainPage
    
        
    
        
        Determines if the page being found is the main page for an action.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsMainPage
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheKey.ViewLocationExpanderValues
    
        
    
        
        Gets the values populated by :any:`Microsoft.AspNetCore.Mvc.Razor.IViewLocationExpander` instances.
    
        
        :rtype: System.Collections.Generic.IReadOnlyDictionary<System.Collections.Generic.IReadOnlyDictionary`2>{System.String<System.String>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyDictionary<string, string> ViewLocationExpanderValues
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheKey.ViewName
    
        
    
        
        Gets the view name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ViewName
            {
                get;
            }
    

Constructors
------------

.. dn:structure:: Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheKey
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheKey.ViewLocationCacheKey(System.String, System.Boolean)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheKey`\.
    
        
    
        
        :param viewName: The view name or path.
        
        :type viewName: System.String
    
        
        :param isMainPage: Determines if the page being found is the main page for an action.
        
        :type isMainPage: System.Boolean
    
        
        .. code-block:: csharp
    
            public ViewLocationCacheKey(string viewName, bool isMainPage)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheKey.ViewLocationCacheKey(System.String, System.String, System.String, System.Boolean, System.Collections.Generic.IReadOnlyDictionary<System.String, System.String>)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheKey`\.
    
        
    
        
        :param viewName: The view name.
        
        :type viewName: System.String
    
        
        :param controllerName: The controller name.
        
        :type controllerName: System.String
    
        
        :param areaName: The area name.
        
        :type areaName: System.String
    
        
        :param isMainPage: Determines if the page being found is the main page for an action.
        
        :type isMainPage: System.Boolean
    
        
        :param values: Values from :any:`Microsoft.AspNetCore.Mvc.Razor.IViewLocationExpander` instances.
        
        :type values: System.Collections.Generic.IReadOnlyDictionary<System.Collections.Generic.IReadOnlyDictionary`2>{System.String<System.String>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public ViewLocationCacheKey(string viewName, string controllerName, string areaName, bool isMainPage, IReadOnlyDictionary<string, string> values)
    

Methods
-------

.. dn:structure:: Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheKey
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheKey.Equals(Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheKey)
    
        
    
        
        :type y: Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheKey
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Equals(ViewLocationCacheKey y)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheKey.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheKey.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    

