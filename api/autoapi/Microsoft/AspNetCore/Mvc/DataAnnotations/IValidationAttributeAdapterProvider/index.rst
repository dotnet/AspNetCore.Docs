

IValidationAttributeAdapterProvider Interface
=============================================






Provider for supplying :any:`Microsoft.AspNetCore.Mvc.DataAnnotations.IAttributeAdapter`\'s.


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

    public interface IValidationAttributeAdapterProvider








.. dn:interface:: Microsoft.AspNetCore.Mvc.DataAnnotations.IValidationAttributeAdapterProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.DataAnnotations.IValidationAttributeAdapterProvider

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.DataAnnotations.IValidationAttributeAdapterProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.DataAnnotations.IValidationAttributeAdapterProvider.GetAttributeAdapter(System.ComponentModel.DataAnnotations.ValidationAttribute, Microsoft.Extensions.Localization.IStringLocalizer)
    
        
    
        
        Returns the :any:`Microsoft.AspNetCore.Mvc.DataAnnotations.IAttributeAdapter` for the given :any:`System.ComponentModel.DataAnnotations.ValidationAttribute`\.
    
        
    
        
        :param attribute: The :any:`System.ComponentModel.DataAnnotations.ValidationAttribute` to create an :any:`Microsoft.AspNetCore.Mvc.DataAnnotations.IAttributeAdapter`
            for.
        
        :type attribute: System.ComponentModel.DataAnnotations.ValidationAttribute
    
        
        :param stringLocalizer: The :any:`Microsoft.Extensions.Localization.IStringLocalizer` which will be used to create messages.
            
        
        :type stringLocalizer: Microsoft.Extensions.Localization.IStringLocalizer
        :rtype: Microsoft.AspNetCore.Mvc.DataAnnotations.IAttributeAdapter
        :return: An :any:`Microsoft.AspNetCore.Mvc.DataAnnotations.IAttributeAdapter` for the given <em>attribute</em>.
    
        
        .. code-block:: csharp
    
            IAttributeAdapter GetAttributeAdapter(ValidationAttribute attribute, IStringLocalizer stringLocalizer)
    

