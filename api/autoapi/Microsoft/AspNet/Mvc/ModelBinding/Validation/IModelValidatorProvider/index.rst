

IModelValidatorProvider Interface
=================================



.. contents:: 
   :local:



Summary
-------

Provides validators for a model value.











Syntax
------

.. code-block:: csharp

   public interface IModelValidatorProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/Validation/IModelValidatorProvider.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidatorProvider

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidatorProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidatorProvider.GetValidators(Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelValidatorProviderContext)
    
        
    
        Gets the validators for :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelValidatorProviderContext.ModelMetadata`\.
    
        
        
        
        :param context: The .
        
        :type context: Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelValidatorProviderContext
    
        
        .. code-block:: csharp
    
           void GetValidators(ModelValidatorProviderContext context)
    

