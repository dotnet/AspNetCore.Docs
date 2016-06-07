

ModelStateDictionaryExtensions Class
====================================






Extensions methods for :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionaryExtensions`








Syntax
------

.. code-block:: csharp

    public class ModelStateDictionaryExtensions








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionaryExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionaryExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionaryExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionaryExtensions.AddModelError<TModel>(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary, System.Linq.Expressions.Expression<System.Func<TModel, System.Object>>, System.Exception, Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata)
    
        
    
        
        Adds the specified <em>exception</em> to the :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry.Errors` instance
        that is associated with the specified <em>expression</em>.
    
        
    
        
        :param modelState: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` instance this method extends.
        
        :type modelState: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary
    
        
        :param expression: An expression to be evaluated against an item in the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, System.Object<System.Object>}}
    
        
        :param exception: The :any:`System.Exception` to add.
        
        :type exception: System.Exception
    
        
        :param metadata: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata` associated with the model.
        
        :type metadata: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
            public static void AddModelError<TModel>(ModelStateDictionary modelState, Expression<Func<TModel, object>> expression, Exception exception, ModelMetadata metadata)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionaryExtensions.AddModelError<TModel>(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary, System.Linq.Expressions.Expression<System.Func<TModel, System.Object>>, System.String)
    
        
    
        
        Adds the specified <em>errorMessage</em> to the :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry.Errors` instance
        that is associated with the specified <em>expression</em>.
    
        
    
        
        :param modelState: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` instance this method extends.
        
        :type modelState: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary
    
        
        :param expression: An expression to be evaluated against an item in the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, System.Object<System.Object>}}
    
        
        :param errorMessage: The error message to add.
        
        :type errorMessage: System.String
    
        
        .. code-block:: csharp
    
            public static void AddModelError<TModel>(ModelStateDictionary modelState, Expression<Func<TModel, object>> expression, string errorMessage)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionaryExtensions.RemoveAll<TModel>(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary, System.Linq.Expressions.Expression<System.Func<TModel, System.Object>>)
    
        
    
        
        Removes all the entries for the specified <em>expression</em> from the
        :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary`\.
    
        
    
        
        :param modelState: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` instance this method extends.
        
        :type modelState: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary
    
        
        :param expression: An expression to be evaluated against an item in the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, System.Object<System.Object>}}
    
        
        .. code-block:: csharp
    
            public static void RemoveAll<TModel>(ModelStateDictionary modelState, Expression<Func<TModel, object>> expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionaryExtensions.Remove<TModel>(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary, System.Linq.Expressions.Expression<System.Func<TModel, System.Object>>)
    
        
    
        
        Removes the specified <em>expression</em> from the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary`\.
    
        
    
        
        :param modelState: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` instance this method extends.
        
        :type modelState: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary
    
        
        :param expression: An expression to be evaluated against an item in the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, System.Object<System.Object>}}
        :rtype: System.Boolean
        :return: 
            true if the element is successfully removed; otherwise, false.
            This method also returns false if <em>expression</em> was not found in the model-state dictionary.
    
        
        .. code-block:: csharp
    
            public static bool Remove<TModel>(ModelStateDictionary modelState, Expression<Func<TModel, object>> expression)
    

