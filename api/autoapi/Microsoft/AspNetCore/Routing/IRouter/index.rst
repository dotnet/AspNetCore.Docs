

IRouter Interface
=================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Routing`
Assemblies
    * Microsoft.AspNetCore.Routing.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IRouter








.. dn:interface:: Microsoft.AspNetCore.Routing.IRouter
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Routing.IRouter

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Routing.IRouter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.IRouter.GetVirtualPath(Microsoft.AspNetCore.Routing.VirtualPathContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Routing.VirtualPathContext
        :rtype: Microsoft.AspNetCore.Routing.VirtualPathData
    
        
        .. code-block:: csharp
    
            VirtualPathData GetVirtualPath(VirtualPathContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.IRouter.RouteAsync(Microsoft.AspNetCore.Routing.RouteContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Routing.RouteContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            Task RouteAsync(RouteContext context)
    

