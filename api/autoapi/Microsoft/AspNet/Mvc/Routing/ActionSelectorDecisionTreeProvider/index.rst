

ActionSelectorDecisionTreeProvider Class
========================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Routing.ActionSelectorDecisionTreeProvider`








Syntax
------

.. code-block:: csharp

   public class ActionSelectorDecisionTreeProvider : IActionSelectorDecisionTreeProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Routing/ActionSelectorDecisionTreeProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Routing.ActionSelectorDecisionTreeProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Routing.ActionSelectorDecisionTreeProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Routing.ActionSelectorDecisionTreeProvider.ActionSelectorDecisionTreeProvider(Microsoft.AspNet.Mvc.Infrastructure.IActionDescriptorsCollectionProvider)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.Routing.ActionSelectorDecisionTreeProvider`\.
    
        
        
        
        :param actionDescriptorsCollectionProvider: The .
        
        :type actionDescriptorsCollectionProvider: Microsoft.AspNet.Mvc.Infrastructure.IActionDescriptorsCollectionProvider
    
        
        .. code-block:: csharp
    
           public ActionSelectorDecisionTreeProvider(IActionDescriptorsCollectionProvider actionDescriptorsCollectionProvider)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Routing.ActionSelectorDecisionTreeProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.ActionSelectorDecisionTreeProvider.DecisionTree
    
        
        :rtype: Microsoft.AspNet.Mvc.Routing.IActionSelectionDecisionTree
    
        
        .. code-block:: csharp
    
           public IActionSelectionDecisionTree DecisionTree { get; }
    

