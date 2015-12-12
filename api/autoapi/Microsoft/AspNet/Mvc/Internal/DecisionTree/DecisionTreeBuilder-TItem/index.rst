

DecisionTreeBuilder<TItem> Class
================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionTreeBuilder\<TItem>`








Syntax
------

.. code-block:: csharp

   public class DecisionTreeBuilder<TItem>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Internal/DecisionTree/DecisionTreeBuilder.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionTreeBuilder<TItem>

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionTreeBuilder<TItem>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionTreeBuilder<TItem>.GenerateTree(System.Collections.Generic.IReadOnlyList<TItem>, Microsoft.AspNet.Mvc.Internal.DecisionTree.IClassifier<TItem>)
    
        
        
        
        :type items: System.Collections.Generic.IReadOnlyList{{TItem}}
        
        
        :type classifier: Microsoft.AspNet.Mvc.Internal.DecisionTree.IClassifier{{TItem}}
        :rtype: Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionTreeNode{{TItem}}
    
        
        .. code-block:: csharp
    
           public static DecisionTreeNode<TItem> GenerateTree(IReadOnlyList<TItem> items, IClassifier<TItem> classifier)
    

