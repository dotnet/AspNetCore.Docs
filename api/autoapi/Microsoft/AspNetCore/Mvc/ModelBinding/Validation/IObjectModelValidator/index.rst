

IObjectModelValidator Interface
===============================






Provides methods to validate an object graph.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IObjectModelValidator








.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IObjectModelValidator
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IObjectModelValidator

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IObjectModelValidator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IObjectModelValidator.Validate(Microsoft.AspNetCore.Mvc.ActionContext, Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationStateDictionary, System.String, System.Object)
    
        
    
        
        Validates the provided object.
    
        
    
        
        :param actionContext: The :any:`Microsoft.AspNetCore.Mvc.ActionContext` associated with the current request.
        
        :type actionContext: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :param validationState: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationStateDictionary`\. May be null.
        
        :type validationState: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationStateDictionary
    
        
        :param prefix: 
            The model prefix. Used to map the model object to entries in <em>validationState</em>.
        
        :type prefix: System.String
    
        
        :param model: The model object.
        
        :type model: System.Object
    
        
        .. code-block:: csharp
    
            void Validate(ActionContext actionContext, ValidationStateDictionary validationState, string prefix, object model)
    

