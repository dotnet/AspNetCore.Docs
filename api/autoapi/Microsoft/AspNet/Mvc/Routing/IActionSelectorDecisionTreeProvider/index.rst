

IActionSelectorDecisionTreeProvider Interface
=============================================



.. contents:: 
   :local:



Summary
-------

Stores an :any:`Microsoft.AspNet.Mvc.Routing.ActionSelectionDecisionTree` for the current value of 
:dn:prop:`Microsoft.AspNet.Mvc.Infrastructure.IActionDescriptorsCollectionProvider.ActionDescriptors`\.











Syntax
------

.. code-block:: csharp

   public interface IActionSelectorDecisionTreeProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Routing/IActionSelectorDecisionTreeProvider.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Routing.IActionSelectorDecisionTreeProvider

Properties
----------

.. dn:interface:: Microsoft.AspNet.Mvc.Routing.IActionSelectorDecisionTreeProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.IActionSelectorDecisionTreeProvider.DecisionTree
    
        
    
        Gets the :any:`Microsoft.AspNet.Mvc.Infrastructure.IActionDescriptorsCollectionProvider`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.Routing.IActionSelectionDecisionTree
    
        
        .. code-block:: csharp
    
           IActionSelectionDecisionTree DecisionTree { get; }
    

