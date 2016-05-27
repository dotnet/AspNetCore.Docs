

ExpressionMetadataProvider Class
================================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ExpressionMetadataProvider`








Syntax
------

.. code-block:: csharp

    public class ExpressionMetadataProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ExpressionMetadataProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ExpressionMetadataProvider

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ExpressionMetadataProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ExpressionMetadataProvider.FromLambdaExpression<TModel, TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TModel>, Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider)
    
        
    
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
    
        
        :type viewData: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary`1>{TModel}
    
        
        :type metadataProvider: Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
    
        
        .. code-block:: csharp
    
            public static ModelExplorer FromLambdaExpression<TModel, TResult>(Expression<Func<TModel, TResult>> expression, ViewDataDictionary<TModel> viewData, IModelMetadataProvider metadataProvider)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ExpressionMetadataProvider.FromStringExpression(System.String, Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary, Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider)
    
        
    
        
        Gets :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer` for named <em>expression</em> in given
        <em>viewData</em>.
    
        
    
        
        :param expression: Expression name, relative to <code>viewData.Model</code>.
        
        :type expression: System.String
    
        
        :param viewData: 
            The :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary` that may contain the <em>expression</em> value.
        
        :type viewData: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary
    
        
        :param metadataProvider: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider`\.
        
        :type metadataProvider: Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
        :return: 
            :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer` for named <em>expression</em> in given <em>viewData</em>.
    
        
        .. code-block:: csharp
    
            public static ModelExplorer FromStringExpression(string expression, ViewDataDictionary viewData, IModelMetadataProvider metadataProvider)
    

