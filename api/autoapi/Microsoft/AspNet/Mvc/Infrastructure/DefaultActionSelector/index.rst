

DefaultActionSelector Class
===========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Infrastructure.DefaultActionSelector`








Syntax
------

.. code-block:: csharp

   public class DefaultActionSelector : IActionSelector





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Infrastructure/DefaultActionSelector.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Infrastructure.DefaultActionSelector

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Infrastructure.DefaultActionSelector
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Infrastructure.DefaultActionSelector.DefaultActionSelector(Microsoft.AspNet.Mvc.Infrastructure.IActionDescriptorsCollectionProvider, Microsoft.AspNet.Mvc.Routing.IActionSelectorDecisionTreeProvider, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraintProvider>, Microsoft.Extensions.Logging.ILoggerFactory)
    
        
        
        
        :type actionDescriptorsCollectionProvider: Microsoft.AspNet.Mvc.Infrastructure.IActionDescriptorsCollectionProvider
        
        
        :type decisionTreeProvider: Microsoft.AspNet.Mvc.Routing.IActionSelectorDecisionTreeProvider
        
        
        :type actionConstraintProviders: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraintProvider}
        
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
           public DefaultActionSelector(IActionDescriptorsCollectionProvider actionDescriptorsCollectionProvider, IActionSelectorDecisionTreeProvider decisionTreeProvider, IEnumerable<IActionConstraintProvider> actionConstraintProviders, ILoggerFactory loggerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Infrastructure.DefaultActionSelector
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Infrastructure.DefaultActionSelector.HasValidAction(Microsoft.AspNet.Routing.VirtualPathContext)
    
        
        
        
        :type context: Microsoft.AspNet.Routing.VirtualPathContext
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool HasValidAction(VirtualPathContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Infrastructure.DefaultActionSelector.SelectAsync(Microsoft.AspNet.Routing.RouteContext)
    
        
        
        
        :type context: Microsoft.AspNet.Routing.RouteContext
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor}
    
        
        .. code-block:: csharp
    
           public Task<ActionDescriptor> SelectAsync(RouteContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Infrastructure.DefaultActionSelector.SelectBestActions(System.Collections.Generic.IReadOnlyList<Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor>)
    
        
    
        Returns the set of best matching actions.
    
        
        
        
        :param actions: The set of actions that satisfy all constraints.
        
        :type actions: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor}
        :rtype: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor}
        :return: A list of the best matching actions.
    
        
        .. code-block:: csharp
    
           protected virtual IReadOnlyList<ActionDescriptor> SelectBestActions(IReadOnlyList<ActionDescriptor> actions)
    

