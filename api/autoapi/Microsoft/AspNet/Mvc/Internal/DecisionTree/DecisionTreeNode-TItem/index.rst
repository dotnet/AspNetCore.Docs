

DecisionTreeNode<TItem> Class
=============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionTreeNode\<TItem>`








Syntax
------

.. code-block:: csharp

   public class DecisionTreeNode<TItem>





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/Internal/DecisionTree/DecisionTreeNode.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionTreeNode<TItem>

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionTreeNode<TItem>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionTreeNode<TItem>.Criteria
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionCriterion{{TItem}}}
    
        
        .. code-block:: csharp
    
           public IList<DecisionCriterion<TItem>> Criteria { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionTreeNode<TItem>.Matches
    
        
        :rtype: System.Collections.Generic.IList{{TItem}}
    
        
        .. code-block:: csharp
    
           public IList<TItem> Matches { get; set; }
    

