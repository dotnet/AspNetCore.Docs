

IClassifier<TItem> Interface
============================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IClassifier<TItem>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Internal/DecisionTree/IClassifier.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Internal.DecisionTree.IClassifier<TItem>

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Internal.DecisionTree.IClassifier<TItem>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Internal.DecisionTree.IClassifier<TItem>.GetCriteria(TItem)
    
        
        
        
        :type item: {TItem}
        :rtype: System.Collections.Generic.IDictionary{System.String,Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionCriterionValue}
    
        
        .. code-block:: csharp
    
           IDictionary<string, DecisionCriterionValue> GetCriteria(TItem item)
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.Mvc.Internal.DecisionTree.IClassifier<TItem>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Internal.DecisionTree.IClassifier<TItem>.ValueComparer
    
        
        :rtype: System.Collections.Generic.IEqualityComparer{System.Object}
    
        
        .. code-block:: csharp
    
           IEqualityComparer<object> ValueComparer { get; }
    

