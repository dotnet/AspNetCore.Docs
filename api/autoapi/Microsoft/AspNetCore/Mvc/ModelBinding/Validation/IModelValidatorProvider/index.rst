

IModelValidatorProvider Interface
=================================






Provides validators for a model value.


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

    public interface IModelValidatorProvider








.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider.CreateValidators(Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidatorProviderContext)
    
        
    
        
        Creates the validators for :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidatorProviderContext.ModelMetadata`\.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidatorProviderContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidatorProviderContext
    
        
        .. code-block:: csharp
    
            void CreateValidators(ModelValidatorProviderContext context)
    

