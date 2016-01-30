

ItemDescriptor<TItem> Class
===========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Internal.DecisionTree.ItemDescriptor\<TItem>`








Syntax
------

.. code-block:: csharp

   public class ItemDescriptor<TItem>





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/Internal/DecisionTree/ItemDescriptor.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Internal.DecisionTree.ItemDescriptor<TItem>

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Internal.DecisionTree.ItemDescriptor<TItem>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Internal.DecisionTree.ItemDescriptor<TItem>.Criteria
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionCriterionValue}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, DecisionCriterionValue> Criteria { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Internal.DecisionTree.ItemDescriptor<TItem>.Index
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Index { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Internal.DecisionTree.ItemDescriptor<TItem>.Item
    
        
        :rtype: {TItem}
    
        
        .. code-block:: csharp
    
           public TItem Item { get; set; }
    

