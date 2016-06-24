

ActionSelectorDecisionTreeProvider Class
========================================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.ActionSelectorDecisionTreeProvider`








Syntax
------

.. code-block:: csharp

    public class ActionSelectorDecisionTreeProvider : IActionSelectorDecisionTreeProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ActionSelectorDecisionTreeProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ActionSelectorDecisionTreeProvider

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ActionSelectorDecisionTreeProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.ActionSelectorDecisionTreeProvider.ActionSelectorDecisionTreeProvider(Microsoft.AspNetCore.Mvc.Infrastructure.IActionDescriptorCollectionProvider)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.Internal.ActionSelectorDecisionTreeProvider`\.
    
        
    
        
        :param actionDescriptorCollectionProvider: 
            The :any:`Microsoft.AspNetCore.Mvc.Infrastructure.IActionDescriptorCollectionProvider`\.
        
        :type actionDescriptorCollectionProvider: Microsoft.AspNetCore.Mvc.Infrastructure.IActionDescriptorCollectionProvider
    
        
        .. code-block:: csharp
    
            public ActionSelectorDecisionTreeProvider(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ActionSelectorDecisionTreeProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.ActionSelectorDecisionTreeProvider.DecisionTree
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Internal.IActionSelectionDecisionTree
    
        
        .. code-block:: csharp
    
            public IActionSelectionDecisionTree DecisionTree { get; }
    

