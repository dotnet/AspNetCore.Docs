

ActionConstraintCache Class
===========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.ActionConstraintCache`








Syntax
------

.. code-block:: csharp

    public class ActionConstraintCache








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ActionConstraintCache
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ActionConstraintCache

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ActionConstraintCache
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.ActionConstraintCache.ActionConstraintCache(Microsoft.AspNetCore.Mvc.Infrastructure.IActionDescriptorCollectionProvider, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraintProvider>)
    
        
    
        
        :type collectionProvider: Microsoft.AspNetCore.Mvc.Infrastructure.IActionDescriptorCollectionProvider
    
        
        :type actionConstraintProviders: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraintProvider<Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraintProvider>}
    
        
        .. code-block:: csharp
    
            public ActionConstraintCache(IActionDescriptorCollectionProvider collectionProvider, IEnumerable<IActionConstraintProvider> actionConstraintProviders)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ActionConstraintCache
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ActionConstraintCache.GetActionConstraints(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor)
    
        
    
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type action: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint<Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<IActionConstraint> GetActionConstraints(HttpContext httpContext, ActionDescriptor action)
    

