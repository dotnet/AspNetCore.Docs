

ValidationAttributeAdapterProvider Class
========================================






Creates an :any:`Microsoft.AspNetCore.Mvc.DataAnnotations.IAttributeAdapter` for the given attribute.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.DataAnnotations.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.DataAnnotations

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.ValidationAttributeAdapterProvider`








Syntax
------

.. code-block:: csharp

    public class ValidationAttributeAdapterProvider : IValidationAttributeAdapterProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.ValidationAttributeAdapterProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.ValidationAttributeAdapterProvider

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.ValidationAttributeAdapterProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.ValidationAttributeAdapterProvider.GetAttributeAdapter(System.ComponentModel.DataAnnotations.ValidationAttribute, Microsoft.Extensions.Localization.IStringLocalizer)
    
        
    
        
        Creates an :any:`Microsoft.AspNetCore.Mvc.DataAnnotations.IAttributeAdapter` for the given attribute.
    
        
    
        
        :param attribute: The attribute to create an adapter for.
        
        :type attribute: System.ComponentModel.DataAnnotations.ValidationAttribute
    
        
        :param stringLocalizer: The localizer to provide to the adapter.
        
        :type stringLocalizer: Microsoft.Extensions.Localization.IStringLocalizer
        :rtype: Microsoft.AspNetCore.Mvc.DataAnnotations.IAttributeAdapter
        :return: An :any:`Microsoft.AspNetCore.Mvc.DataAnnotations.IAttributeAdapter` for the given attribute.
    
        
        .. code-block:: csharp
    
            public IAttributeAdapter GetAttributeAdapter(ValidationAttribute attribute, IStringLocalizer stringLocalizer)
    

