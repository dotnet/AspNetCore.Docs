

ExpressionMetadataProvider Class
================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewFeatures.ExpressionMetadataProvider`








Syntax
------

.. code-block:: csharp

   public class ExpressionMetadataProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewFeatures/ExpressionMetadataProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.ExpressionMetadataProvider

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.ExpressionMetadataProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.ExpressionMetadataProvider.FromLambdaExpression<TModel, TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary<TModel>, Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider)
    
        
        
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :type viewData: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary{{TModel}}
        
        
        :type metadataProvider: Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
    
        
        .. code-block:: csharp
    
           public static ModelExplorer FromLambdaExpression<TModel, TResult>(Expression<Func<TModel, TResult>> expression, ViewDataDictionary<TModel> viewData, IModelMetadataProvider metadataProvider)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.ExpressionMetadataProvider.FromStringExpression(System.String, Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary, Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider)
    
        
    
        Gets :any:`Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer` for named ``expression`` in given
        ``viewData``.
    
        
        
        
        :param expression: Expression name, relative to viewData.Model.
        
        :type expression: System.String
        
        
        :param viewData: The  that may contain the  value.
        
        :type viewData: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary
        
        
        :param metadataProvider: The .
        
        :type metadataProvider: Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        :return: <see cref="T:Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer" /> for named <paramref name="expression" /> in given <paramref name="viewData" />.
    
        
        .. code-block:: csharp
    
           public static ModelExplorer FromStringExpression(string expression, ViewDataDictionary viewData, IModelMetadataProvider metadataProvider)
    

