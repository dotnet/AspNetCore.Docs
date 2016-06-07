

IActionSelector Interface
=========================






Defines an interface for selecting an MVC action to invoke for the current request.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Infrastructure`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IActionSelector








.. dn:interface:: Microsoft.AspNetCore.Mvc.Infrastructure.IActionSelector
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Infrastructure.IActionSelector

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Infrastructure.IActionSelector
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Infrastructure.IActionSelector.Select(Microsoft.AspNetCore.Routing.RouteContext)
    
        
    
        
        Selects an :any:`Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor` for the request associated with <em>context</em>.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Routing.RouteContext` for the current request.
        
        :type context: Microsoft.AspNetCore.Routing.RouteContext
        :rtype: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor
        :return: An :any:`Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor` or <code>null</code> if no action can be selected.
    
        
        .. code-block:: csharp
    
            ActionDescriptor Select(RouteContext context)
    

