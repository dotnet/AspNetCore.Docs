

DecisionCriterion<TItem> Class
==============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionCriterion\<TItem>`








Syntax
------

.. code-block:: csharp

   public class DecisionCriterion<TItem>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Internal/DecisionTree/DecisionCriterion.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionCriterion<TItem>

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionCriterion<TItem>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionCriterion<TItem>.Branches
    
        
        :rtype: System.Collections.Generic.Dictionary{System.Object,Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionTreeNode{{TItem}}}
    
        
        .. code-block:: csharp
    
           public Dictionary<object, DecisionTreeNode<TItem>> Branches { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionCriterion<TItem>.Fallback
    
        
        :rtype: Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionTreeNode{{TItem}}
    
        
        .. code-block:: csharp
    
           public DecisionTreeNode<TItem> Fallback { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionCriterion<TItem>.Key
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Key { get; set; }
    

