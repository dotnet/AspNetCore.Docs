

RouteCollection Class
=====================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Routing`
Assemblies
    * Microsoft.AspNetCore.Routing

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Routing.RouteCollection`








Syntax
------

.. code-block:: csharp

    public class RouteCollection : IRouteCollection, IRouter








.. dn:class:: Microsoft.AspNetCore.Routing.RouteCollection
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.RouteCollection

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Routing.RouteCollection
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.RouteCollection.Count
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Count
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.RouteCollection.Item[System.Int32]
    
        
    
        
        :type index: System.Int32
        :rtype: Microsoft.AspNetCore.Routing.IRouter
    
        
        .. code-block:: csharp
    
            public IRouter this[int index]
            {
                get;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Routing.RouteCollection
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.RouteCollection.Add(Microsoft.AspNetCore.Routing.IRouter)
    
        
    
        
        :type router: Microsoft.AspNetCore.Routing.IRouter
    
        
        .. code-block:: csharp
    
            public void Add(IRouter router)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.RouteCollection.GetVirtualPath(Microsoft.AspNetCore.Routing.VirtualPathContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Routing.VirtualPathContext
        :rtype: Microsoft.AspNetCore.Routing.VirtualPathData
    
        
        .. code-block:: csharp
    
            public virtual VirtualPathData GetVirtualPath(VirtualPathContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.RouteCollection.RouteAsync(Microsoft.AspNetCore.Routing.RouteContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Routing.RouteContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task RouteAsync(RouteContext context)
    

