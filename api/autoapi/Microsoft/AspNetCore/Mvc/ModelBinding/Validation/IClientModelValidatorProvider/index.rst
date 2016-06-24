

IClientModelValidatorProvider Interface
=======================================






Provides a collection of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidator`\s.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IClientModelValidatorProvider








.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidatorProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidatorProvider

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidatorProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidatorProvider.CreateValidators(Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorProviderContext)
    
        
    
        
        Creates set of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidator`\s by updating 
        :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorItem.Validator` in :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorProviderContext.Results`\.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientModelValidationContext` associated with this call.
        
        :type context: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorProviderContext
    
        
        .. code-block:: csharp
    
            void CreateValidators(ClientValidatorProviderContext context)
    

