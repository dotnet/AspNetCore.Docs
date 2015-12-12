

VirtualPathData Class
=====================



.. contents:: 
   :local:



Summary
-------

Represents information about the route and virtual path that are the result of
generating a URL with the ASP.NET routing middleware.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Routing.VirtualPathData`








Syntax
------

.. code-block:: csharp

   public class VirtualPathData





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/routing/src/Microsoft.AspNet.Routing/VirtualPathData.cs>`_





.. dn:class:: Microsoft.AspNet.Routing.VirtualPathData

Constructors
------------

.. dn:class:: Microsoft.AspNet.Routing.VirtualPathData
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Routing.VirtualPathData.VirtualPathData(Microsoft.AspNet.Routing.IRouter, Microsoft.AspNet.Http.PathString, System.Collections.Generic.IDictionary<System.String, System.Object>)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Routing.VirtualPathData` class.
    
        
        
        
        :param router: The object that is used to generate the URL.
        
        :type router: Microsoft.AspNet.Routing.IRouter
        
        
        :param virtualPath: The generated URL.
        
        :type virtualPath: Microsoft.AspNet.Http.PathString
        
        
        :param dataTokens: The collection of custom values.
        
        :type dataTokens: System.Collections.Generic.IDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public VirtualPathData(IRouter router, PathString virtualPath, IDictionary<string, object> dataTokens)
    
    .. dn:constructor:: Microsoft.AspNet.Routing.VirtualPathData.VirtualPathData(Microsoft.AspNet.Routing.IRouter, System.String)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Routing.VirtualPathData` class.
    
        
        
        
        :param router: The object that is used to generate the URL.
        
        :type router: Microsoft.AspNet.Routing.IRouter
        
        
        :param virtualPath: The generated URL.
        
        :type virtualPath: System.String
    
        
        .. code-block:: csharp
    
           public VirtualPathData(IRouter router, string virtualPath)
    
    .. dn:constructor:: Microsoft.AspNet.Routing.VirtualPathData.VirtualPathData(Microsoft.AspNet.Routing.IRouter, System.String, System.Collections.Generic.IDictionary<System.String, System.Object>)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Routing.VirtualPathData` class.
    
        
        
        
        :param router: The object that is used to generate the URL.
        
        :type router: Microsoft.AspNet.Routing.IRouter
        
        
        :param virtualPath: The generated URL.
        
        :type virtualPath: System.String
        
        
        :param dataTokens: The collection of custom values.
        
        :type dataTokens: System.Collections.Generic.IDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public VirtualPathData(IRouter router, string virtualPath, IDictionary<string, object> dataTokens)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Routing.VirtualPathData
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Routing.VirtualPathData.DataTokens
    
        
    
        Gets the collection of custom values for the :dn:prop:`Microsoft.AspNet.Routing.VirtualPathData.Router`\.
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, object> DataTokens { get; }
    
    .. dn:property:: Microsoft.AspNet.Routing.VirtualPathData.Router
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Routing.IRouter` that was used to generate the URL.
    
        
        :rtype: Microsoft.AspNet.Routing.IRouter
    
        
        .. code-block:: csharp
    
           public IRouter Router { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Routing.VirtualPathData.VirtualPath
    
        
    
        Gets or sets the URL that was generated from the :dn:prop:`Microsoft.AspNet.Routing.VirtualPathData.Router`\.
    
        
        :rtype: Microsoft.AspNet.Http.PathString
    
        
        .. code-block:: csharp
    
           public PathString VirtualPath { get; set; }
    

