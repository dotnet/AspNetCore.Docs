

VirtualPathData Class
=====================






Represents information about the route and virtual path that are the result of
generating a URL with the ASP.NET routing middleware.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Routing`
Assemblies
    * Microsoft.AspNetCore.Routing.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Routing.VirtualPathData`








Syntax
------

.. code-block:: csharp

    public class VirtualPathData








.. dn:class:: Microsoft.AspNetCore.Routing.VirtualPathData
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.VirtualPathData

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Routing.VirtualPathData
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.VirtualPathData.VirtualPathData(Microsoft.AspNetCore.Routing.IRouter, System.String)
    
        
    
        
         Initializes a new instance of the :any:`Microsoft.AspNetCore.Routing.VirtualPathData` class.
    
        
    
        
        :param router: The object that is used to generate the URL.
        
        :type router: Microsoft.AspNetCore.Routing.IRouter
    
        
        :param virtualPath: The generated URL.
        
        :type virtualPath: System.String
    
        
        .. code-block:: csharp
    
            public VirtualPathData(IRouter router, string virtualPath)
    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.VirtualPathData.VirtualPathData(Microsoft.AspNetCore.Routing.IRouter, System.String, Microsoft.AspNetCore.Routing.RouteValueDictionary)
    
        
    
        
         Initializes a new instance of the :any:`Microsoft.AspNetCore.Routing.VirtualPathData` class.
    
        
    
        
        :param router: The object that is used to generate the URL.
        
        :type router: Microsoft.AspNetCore.Routing.IRouter
    
        
        :param virtualPath: The generated URL.
        
        :type virtualPath: System.String
    
        
        :param dataTokens: The collection of custom values.
        
        :type dataTokens: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        .. code-block:: csharp
    
            public VirtualPathData(IRouter router, string virtualPath, RouteValueDictionary dataTokens)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Routing.VirtualPathData
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.VirtualPathData.DataTokens
    
        
    
        
        Gets the collection of custom values for the :dn:prop:`Microsoft.AspNetCore.Routing.VirtualPathData.Router`\.
    
        
        :rtype: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        .. code-block:: csharp
    
            public RouteValueDictionary DataTokens { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.VirtualPathData.Router
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Routing.IRouter` that was used to generate the URL.
    
        
        :rtype: Microsoft.AspNetCore.Routing.IRouter
    
        
        .. code-block:: csharp
    
            public IRouter Router { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.VirtualPathData.VirtualPath
    
        
    
        
        Gets or sets the URL that was generated from the :dn:prop:`Microsoft.AspNetCore.Routing.VirtualPathData.Router`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string VirtualPath { get; set; }
    

