

IModelExpressionProvider Interface
==================================






Provides :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpression` for a Lambda expression.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewFeatures`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IModelExpressionProvider








.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider.CreateModelExpression<TModel, TValue>(Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TValue>>)
    
        
    
        
        Returns a :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpression` instance describing the given <em>expression</em>.
    
        
    
        
        :param viewData: The :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary\`1` containing the :dn:prop:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary\`1.Model` 
            against which <em>expression</em> is evaluated. 
        
        :type viewData: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary`1>{TModel}
    
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TValue}}
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpression
        :return: A new :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpression` instance describing the given <em>expression</em>.
    
        
        .. code-block:: csharp
    
            ModelExpression CreateModelExpression<TModel, TValue>(ViewDataDictionary<TModel> viewData, Expression<Func<TModel, TValue>> expression)
    

