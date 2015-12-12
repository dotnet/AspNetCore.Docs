

ModelStateDictionaryExtensions Class
====================================



.. contents:: 
   :local:



Summary
-------

Extensions methods for :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionaryExtensions`








Syntax
------

.. code-block:: csharp

   public class ModelStateDictionaryExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/ModelStateDictionaryExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionaryExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionaryExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionaryExtensions.AddModelError<TModel>(Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary, System.Linq.Expressions.Expression<System.Func<TModel, System.Object>>, System.Exception, Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata)
    
        
    
        Adds the specified ``exception`` to the :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateEntry.Errors` instance
        that is associated with the specified ``expression``.
    
        
        
        
        :param modelState: The  instance this method extends.
        
        :type modelState: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
        
        
        :param expression: An expression to be evaluated against an item in the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},System.Object}}
        
        
        :param exception: The  to add.
        
        :type exception: System.Exception
        
        
        :type metadata: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
           public static void AddModelError<TModel>(ModelStateDictionary modelState, Expression<Func<TModel, object>> expression, Exception exception, ModelMetadata metadata)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionaryExtensions.AddModelError<TModel>(Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary, System.Linq.Expressions.Expression<System.Func<TModel, System.Object>>, System.String)
    
        
    
        Adds the specified ``errorMessage`` to the :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateEntry.Errors` instance
        that is associated with the specified ``expression``.
    
        
        
        
        :param modelState: The  instance this method extends.
        
        :type modelState: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
        
        
        :param expression: An expression to be evaluated against an item in the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},System.Object}}
        
        
        :param errorMessage: The error message to add.
        
        :type errorMessage: System.String
    
        
        .. code-block:: csharp
    
           public static void AddModelError<TModel>(ModelStateDictionary modelState, Expression<Func<TModel, object>> expression, string errorMessage)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionaryExtensions.RemoveAll<TModel>(Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary, System.Linq.Expressions.Expression<System.Func<TModel, System.Object>>)
    
        
    
        Removes all the entries for the specified ``expression`` from the 
        :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary`\.
    
        
        
        
        :param modelState: The  instance this method extends.
        
        :type modelState: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
        
        
        :param expression: An expression to be evaluated against an item in the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},System.Object}}
    
        
        .. code-block:: csharp
    
           public static void RemoveAll<TModel>(ModelStateDictionary modelState, Expression<Func<TModel, object>> expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionaryExtensions.Remove<TModel>(Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary, System.Linq.Expressions.Expression<System.Func<TModel, System.Object>>)
    
        
    
        Removes the specified ``expression`` from the :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary`\.
    
        
        
        
        :param modelState: The  instance this method extends.
        
        :type modelState: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
        
        
        :param expression: An expression to be evaluated against an item in the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},System.Object}}
        :rtype: System.Boolean
        :return: true if the element is successfully removed; otherwise, false.
            This method also returns false if <paramref name="expression" /> was not found in the model-state dictionary.
    
        
        .. code-block:: csharp
    
           public static bool Remove<TModel>(ModelStateDictionary modelState, Expression<Func<TModel, object>> expression)
    

