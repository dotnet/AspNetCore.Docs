

RouteCollection Class
=====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Routing.RouteCollection`








Syntax
------

.. code-block:: csharp

   public class RouteCollection : IRouteCollection, IRouter





GitHub
------

`View on GitHub <https://github.com/aspnet/routing/blob/master/src/Microsoft.AspNet.Routing/RouteCollection.cs>`_





.. dn:class:: Microsoft.AspNet.Routing.RouteCollection

Methods
-------

.. dn:class:: Microsoft.AspNet.Routing.RouteCollection
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Routing.RouteCollection.Add(Microsoft.AspNet.Routing.IRouter)
    
        
        
        
        :type router: Microsoft.AspNet.Routing.IRouter
    
        
        .. code-block:: csharp
    
           public void Add(IRouter router)
    
    .. dn:method:: Microsoft.AspNet.Routing.RouteCollection.GetVirtualPath(Microsoft.AspNet.Routing.VirtualPathContext)
    
        
        
        
        :type context: Microsoft.AspNet.Routing.VirtualPathContext
        :rtype: Microsoft.AspNet.Routing.VirtualPathData
    
        
        .. code-block:: csharp
    
           public virtual VirtualPathData GetVirtualPath(VirtualPathContext context)
    
    .. dn:method:: Microsoft.AspNet.Routing.RouteCollection.RouteAsync(Microsoft.AspNet.Routing.RouteContext)
    
        
        
        
        :type context: Microsoft.AspNet.Routing.RouteContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task RouteAsync(RouteContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Routing.RouteCollection
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Routing.RouteCollection.Count
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Count { get; }
    
    .. dn:property:: Microsoft.AspNet.Routing.RouteCollection.Item[System.Int32]
    
        
        
        
        :type index: System.Int32
        :rtype: Microsoft.AspNet.Routing.IRouter
    
        
        .. code-block:: csharp
    
           public IRouter this[int index] { get; }
    

