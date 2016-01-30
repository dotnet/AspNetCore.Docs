

DecisionCriterionValue Struct
=============================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public struct DecisionCriterionValue





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/Internal/DecisionTree/DecisionCriterionValue.cs>`_





.. dn:structure:: Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionCriterionValue

Constructors
------------

.. dn:structure:: Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionCriterionValue
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionCriterionValue.DecisionCriterionValue(System.Object, System.Boolean)
    
        
        
        
        :type value: System.Object
        
        
        :type isCatchAll: System.Boolean
    
        
        .. code-block:: csharp
    
           public DecisionCriterionValue(object value, bool isCatchAll)
    

Properties
----------

.. dn:structure:: Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionCriterionValue
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionCriterionValue.IsCatchAll
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsCatchAll { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Internal.DecisionTree.DecisionCriterionValue.Value
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object Value { get; }
    

