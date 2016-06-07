

AttributeAdapterBase<TAttribute> Class
======================================






An abstract subclass of :any:`Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.ValidationAttributeAdapter\`1` which wraps up all the required
interfaces for the adapters.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.ValidationAttributeAdapter{{TAttribute}}`
* :dn:cls:`Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.AttributeAdapterBase\<TAttribute>`








Syntax
------

.. code-block:: csharp

    public abstract class AttributeAdapterBase<TAttribute> : ValidationAttributeAdapter<TAttribute>, IAttributeAdapter, IClientModelValidator where TAttribute : ValidationAttribute








.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.AttributeAdapterBase`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.AttributeAdapterBase<TAttribute>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.AttributeAdapterBase<TAttribute>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.AttributeAdapterBase<TAttribute>.AttributeAdapterBase(TAttribute, Microsoft.Extensions.Localization.IStringLocalizer)
    
        
    
        
        Instantiates a new :any:`Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.AttributeAdapterBase\`1`\.
    
        
    
        
        :param attribute: The :any:`System.ComponentModel.DataAnnotations.ValidationAttribute` being wrapped.
        
        :type attribute: TAttribute
    
        
        :param stringLocalizer: The :any:`Microsoft.Extensions.Localization.IStringLocalizer` to be used in error generation.
        
        :type stringLocalizer: Microsoft.Extensions.Localization.IStringLocalizer
    
        
        .. code-block:: csharp
    
            public AttributeAdapterBase(TAttribute attribute, IStringLocalizer stringLocalizer)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.AttributeAdapterBase<TAttribute>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.AttributeAdapterBase<TAttribute>.GetErrorMessage(Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContextBase)
    
        
    
        
        :type validationContext: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContextBase
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public abstract string GetErrorMessage(ModelValidationContextBase validationContext)
    

