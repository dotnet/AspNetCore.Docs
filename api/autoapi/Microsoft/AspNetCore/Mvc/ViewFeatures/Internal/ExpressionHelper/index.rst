

ExpressionHelper Class
======================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ExpressionHelper`








Syntax
------

.. code-block:: csharp

    public class ExpressionHelper








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ExpressionHelper
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ExpressionHelper

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ExpressionHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ExpressionHelper.GetExpressionText(System.Linq.Expressions.LambdaExpression)
    
        
    
        
        :type expression: System.Linq.Expressions.LambdaExpression
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetExpressionText(LambdaExpression expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ExpressionHelper.GetExpressionText(System.Linq.Expressions.LambdaExpression, Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ExpressionTextCache)
    
        
    
        
        :type expression: System.Linq.Expressions.LambdaExpression
    
        
        :type expressionTextCache: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ExpressionTextCache
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetExpressionText(LambdaExpression expression, ExpressionTextCache expressionTextCache)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ExpressionHelper.GetExpressionText(System.String)
    
        
    
        
        :type expression: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetExpressionText(string expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ExpressionHelper.IsSingleArgumentIndexer(System.Linq.Expressions.Expression)
    
        
    
        
        :type expression: System.Linq.Expressions.Expression
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool IsSingleArgumentIndexer(Expression expression)
    

