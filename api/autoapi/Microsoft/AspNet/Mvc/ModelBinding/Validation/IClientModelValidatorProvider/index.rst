

IClientModelValidatorProvider Interface
=======================================



.. contents:: 
   :local:



Summary
-------

Provides a collection of :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.IClientModelValidator`\s.











Syntax
------

.. code-block:: csharp

   public interface IClientModelValidatorProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/Validation/IClientModelValidatorProvider.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.Validation.IClientModelValidatorProvider

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.Validation.IClientModelValidatorProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.IClientModelValidatorProvider.GetValidators(Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientValidatorProviderContext)
    
        
    
        Gets set of :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.IClientModelValidator`\s
        by updating :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientValidatorProviderContext.Validators`\.
    
        
        
        
        :param context: The  associated with this call.
        
        :type context: Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientValidatorProviderContext
    
        
        .. code-block:: csharp
    
           void GetValidators(ClientValidatorProviderContext context)
    

