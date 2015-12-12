

DecisionCriterionValueEqualityComparer Class
============================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionCriterionValueEqualityComparer`








Syntax
------

.. code-block:: csharp

   public class DecisionCriterionValueEqualityComparer : IEqualityComparer<DecisionCriterionValue>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Internal/DecisionTree/DecisionCriterionValueEqualityComparer.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionCriterionValueEqualityComparer

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionCriterionValueEqualityComparer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionCriterionValueEqualityComparer.DecisionCriterionValueEqualityComparer(System.Collections.Generic.IEqualityComparer<System.Object>)
    
        
        
        
        :type innerComparer: System.Collections.Generic.IEqualityComparer{System.Object}
    
        
        .. code-block:: csharp
    
           public DecisionCriterionValueEqualityComparer(IEqualityComparer<object> innerComparer)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionCriterionValueEqualityComparer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionCriterionValueEqualityComparer.Equals(Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionCriterionValue, Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionCriterionValue)
    
        
        
        
        :type x: Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionCriterionValue
        
        
        :type y: Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionCriterionValue
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Equals(DecisionCriterionValue x, DecisionCriterionValue y)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionCriterionValueEqualityComparer.GetHashCode(Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionCriterionValue)
    
        
        
        
        :type obj: Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionCriterionValue
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int GetHashCode(DecisionCriterionValue obj)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionCriterionValueEqualityComparer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionCriterionValueEqualityComparer.InnerComparer
    
        
        :rtype: System.Collections.Generic.IEqualityComparer{System.Object}
    
        
        .. code-block:: csharp
    
           public IEqualityComparer<object> InnerComparer { get; }
    

