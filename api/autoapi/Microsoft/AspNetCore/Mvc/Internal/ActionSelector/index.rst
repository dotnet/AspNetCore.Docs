

ActionSelector Class
====================






A default :any:`Microsoft.AspNetCore.Mvc.Infrastructure.IActionSelector` implementation.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.ActionSelector`








Syntax
------

.. code-block:: csharp

    public class ActionSelector : IActionSelector








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ActionSelector
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ActionSelector

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ActionSelector
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.ActionSelector.ActionSelector(Microsoft.AspNetCore.Mvc.Internal.IActionSelectorDecisionTreeProvider, Microsoft.AspNetCore.Mvc.Internal.ActionConstraintCache, Microsoft.Extensions.Logging.ILoggerFactory)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.Internal.ActionSelector`\.
    
        
    
        
        :param decisionTreeProvider: The :any:`Microsoft.AspNetCore.Mvc.Internal.IActionSelectorDecisionTreeProvider`\.
        
        :type decisionTreeProvider: Microsoft.AspNetCore.Mvc.Internal.IActionSelectorDecisionTreeProvider
    
        
        :param actionConstraintCache: The :any:`Microsoft.AspNetCore.Mvc.Internal.ActionConstraintCache` that
            providers a set of :any:`Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint` instances.
        
        :type actionConstraintCache: Microsoft.AspNetCore.Mvc.Internal.ActionConstraintCache
    
        
        :param loggerFactory: The :any:`Microsoft.Extensions.Logging.ILoggerFactory`\.
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public ActionSelector(IActionSelectorDecisionTreeProvider decisionTreeProvider, ActionConstraintCache actionConstraintCache, ILoggerFactory loggerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ActionSelector
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ActionSelector.SelectBestActions(System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor>)
    
        
    
        
        Returns the set of best matching actions.
    
        
    
        
        :param actions: The set of actions that satisfy all constraints.
        
        :type actions: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor<Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor>}
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor<Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor>}
        :return: A list of the best matching actions.
    
        
        .. code-block:: csharp
    
            protected virtual IReadOnlyList<ActionDescriptor> SelectBestActions(IReadOnlyList<ActionDescriptor> actions)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ActionSelector.SelectBestCandidate(Microsoft.AspNetCore.Routing.RouteContext, System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor>)
    
        
    
        
        :type context: Microsoft.AspNetCore.Routing.RouteContext
    
        
        :type candidates: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor<Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor>}
        :rtype: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor
    
        
        .. code-block:: csharp
    
            public ActionDescriptor SelectBestCandidate(RouteContext context, IReadOnlyList<ActionDescriptor> candidates)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ActionSelector.SelectCandidates(Microsoft.AspNetCore.Routing.RouteContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Routing.RouteContext
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor<Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<ActionDescriptor> SelectCandidates(RouteContext context)
    

