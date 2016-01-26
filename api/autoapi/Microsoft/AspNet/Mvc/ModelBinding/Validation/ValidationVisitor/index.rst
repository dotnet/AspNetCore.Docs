

ValidationVisitor Class
=======================



.. contents:: 
   :local:



Summary
-------

A visitor implementation that interprets :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateDictionary` to traverse
a model object graph and perform validation.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationVisitor`








Syntax
------

.. code-block:: csharp

   public class ValidationVisitor





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ModelBinding/Validation/ValidationVisitor.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationVisitor

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationVisitor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationVisitor.ValidationVisitor(Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidatorProvider, System.Collections.Generic.IList<Microsoft.AspNet.Mvc.ModelBinding.Validation.IExcludeTypeValidationFilter>, Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary, Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateDictionary)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationVisitor`\.
    
        
        
        
        :param validatorProvider: The .
        
        :type validatorProvider: Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidatorProvider
        
        
        :param excludeFilters: The list of .
        
        :type excludeFilters: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.ModelBinding.Validation.IExcludeTypeValidationFilter}
        
        
        :param modelState: The .
        
        :type modelState: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
        
        
        :param validationState: The .
        
        :type validationState: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateDictionary
    
        
        .. code-block:: csharp
    
           public ValidationVisitor(IModelValidatorProvider validatorProvider, IList<IExcludeTypeValidationFilter> excludeFilters, ModelStateDictionary modelState, ValidationStateDictionary validationState)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationVisitor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationVisitor.Validate(Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata, System.String, System.Object)
    
        
    
        Validates a object.
    
        
        
        
        :param metadata: The  associated with the model.
        
        :type metadata: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
        
        
        :param key: The model prefix key.
        
        :type key: System.String
        
        
        :param model: The model object.
        
        :type model: System.Object
        :rtype: System.Boolean
        :return: <c>true</c> if the object is valid, otherwise <c>false</c>.
    
        
        .. code-block:: csharp
    
           public bool Validate(ModelMetadata metadata, string key, object model)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationVisitor.ValidateNode()
    
        
    
        Validates a single node in a model object graph.
    
        
        :rtype: System.Boolean
        :return: <c>true</c> if the node is valid, otherwise <c>false</c>.
    
        
        .. code-block:: csharp
    
           protected virtual bool ValidateNode()
    

