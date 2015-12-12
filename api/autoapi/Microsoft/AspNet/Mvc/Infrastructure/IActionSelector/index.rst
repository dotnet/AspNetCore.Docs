

IActionSelector Interface
=========================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IActionSelector





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Infrastructure/IActionSelector.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Infrastructure.IActionSelector

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Infrastructure.IActionSelector
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Infrastructure.IActionSelector.HasValidAction(Microsoft.AspNet.Routing.VirtualPathContext)
    
        
        
        
        :type context: Microsoft.AspNet.Routing.VirtualPathContext
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool HasValidAction(VirtualPathContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Infrastructure.IActionSelector.SelectAsync(Microsoft.AspNet.Routing.RouteContext)
    
        
        
        
        :type context: Microsoft.AspNet.Routing.RouteContext
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor}
    
        
        .. code-block:: csharp
    
           Task<ActionDescriptor> SelectAsync(RouteContext context)
    

