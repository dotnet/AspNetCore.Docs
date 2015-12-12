

IRouter Interface
=================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IRouter





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/routing/src/Microsoft.AspNet.Routing/IRouter.cs>`_





.. dn:interface:: Microsoft.AspNet.Routing.IRouter

Methods
-------

.. dn:interface:: Microsoft.AspNet.Routing.IRouter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Routing.IRouter.GetVirtualPath(Microsoft.AspNet.Routing.VirtualPathContext)
    
        
        
        
        :type context: Microsoft.AspNet.Routing.VirtualPathContext
        :rtype: Microsoft.AspNet.Routing.VirtualPathData
    
        
        .. code-block:: csharp
    
           VirtualPathData GetVirtualPath(VirtualPathContext context)
    
    .. dn:method:: Microsoft.AspNet.Routing.IRouter.RouteAsync(Microsoft.AspNet.Routing.RouteContext)
    
        
        
        
        :type context: Microsoft.AspNet.Routing.RouteContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task RouteAsync(RouteContext context)
    

