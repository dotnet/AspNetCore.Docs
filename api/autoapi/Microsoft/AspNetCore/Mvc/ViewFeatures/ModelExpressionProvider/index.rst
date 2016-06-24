

ModelExpressionProvider Class
=============================






A default implementation of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewFeatures`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpressionProvider`








Syntax
------

.. code-block:: csharp

    public class ModelExpressionProvider : IModelExpressionProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpressionProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpressionProvider

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpressionProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpressionProvider.ModelExpressionProvider(Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider, Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ExpressionTextCache)
    
        
    
        
        Creates a  new :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpressionProvider`\.
    
        
    
        
        :param modelMetadataProvider: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider`\.
        
        :type modelMetadataProvider: Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider
    
        
        :param expressionTextCache: The :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ExpressionTextCache`\.
        
        :type expressionTextCache: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ExpressionTextCache
    
        
        .. code-block:: csharp
    
            public ModelExpressionProvider(IModelMetadataProvider modelMetadataProvider, ExpressionTextCache expressionTextCache)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpressionProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpressionProvider.CreateModelExpression<TModel, TValue>(Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TValue>>)
    
        
    
        
        :type viewData: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary`1>{TModel}
    
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TValue}}
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpression
    
        
        .. code-block:: csharp
    
            public ModelExpression CreateModelExpression<TModel, TValue>(ViewDataDictionary<TModel> viewData, Expression<Func<TModel, TValue>> expression)
    

