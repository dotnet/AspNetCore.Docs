

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

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Infrastructure.IActionSelector.SelectBestCandidate(Microsoft.AspNetCore.Routing.RouteContext, System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor>)
    
        
    
        
        Selects the best :any:`Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor` candidate from <em>candidates</em> for the 
        current request associated with <em>context</em>.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Routing.RouteContext` associated with the current request.
        
        :type context: Microsoft.AspNetCore.Routing.RouteContext
    
        
        :param candidates: The set of :any:`Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor` candidates.
        
        :type candidates: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor<Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor>}
        :rtype: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor
        :return: The best :any:`Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor` candidate for the current request or <code>null</code>.
    
        
        .. code-block:: csharp
    
            ActionDescriptor SelectBestCandidate(RouteContext context, IReadOnlyList<ActionDescriptor> candidates)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Infrastructure.IActionSelector.SelectCandidates(Microsoft.AspNetCore.Routing.RouteContext)
    
        
    
        
        Selects a set of :any:`Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor` candidates for the current request associated with
        <em>context</em>.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Routing.RouteContext` associated with the current request.
        
        :type context: Microsoft.AspNetCore.Routing.RouteContext
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor<Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor>}
        :return: A set of :any:`Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor` candidates or <code>null</code>.
    
        
        .. code-block:: csharp
    
            IReadOnlyList<ActionDescriptor> SelectCandidates(RouteContext context)
    

