

IAttributeAdapter Interface
===========================






Interface so that adapters provide their relevent values to error messages.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.DataAnnotations`
Assemblies
    * Microsoft.AspNetCore.Mvc.DataAnnotations

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IAttributeAdapter : IClientModelValidator








.. dn:interface:: Microsoft.AspNetCore.Mvc.DataAnnotations.IAttributeAdapter
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.DataAnnotations.IAttributeAdapter

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.DataAnnotations.IAttributeAdapter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.DataAnnotations.IAttributeAdapter.GetErrorMessage(Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContextBase)
    
        
    
        
        Gets the error message.
    
        
    
        
        :param validationContext: The context to use in message creation.
        
        :type validationContext: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContextBase
        :rtype: System.String
        :return: The localized error message.
    
        
        .. code-block:: csharp
    
            string GetErrorMessage(ModelValidationContextBase validationContext)
    

