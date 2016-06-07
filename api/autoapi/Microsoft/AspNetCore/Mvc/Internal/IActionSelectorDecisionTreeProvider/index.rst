

IActionSelectorDecisionTreeProvider Interface
=============================================






Stores an :any:`Microsoft.AspNetCore.Mvc.Internal.ActionSelectionDecisionTree` for the current value of
:dn:prop:`Microsoft.AspNetCore.Mvc.Infrastructure.IActionDescriptorCollectionProvider.ActionDescriptors`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IActionSelectorDecisionTreeProvider








.. dn:interface:: Microsoft.AspNetCore.Mvc.Internal.IActionSelectorDecisionTreeProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Internal.IActionSelectorDecisionTreeProvider

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Internal.IActionSelectorDecisionTreeProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.IActionSelectorDecisionTreeProvider.DecisionTree
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.Infrastructure.IActionDescriptorCollectionProvider`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Internal.IActionSelectionDecisionTree
    
        
        .. code-block:: csharp
    
            IActionSelectionDecisionTree DecisionTree
            {
                get;
            }
    

