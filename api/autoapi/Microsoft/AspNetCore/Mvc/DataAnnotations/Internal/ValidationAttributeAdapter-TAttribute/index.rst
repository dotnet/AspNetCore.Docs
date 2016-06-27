

ValidationAttributeAdapter<TAttribute> Class
============================================






An implementation of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidator` which understands data annotation attributes.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.ValidationAttributeAdapter\<TAttribute>`








Syntax
------

.. code-block:: csharp

    public abstract class ValidationAttributeAdapter<TAttribute> : IClientModelValidator where TAttribute : ValidationAttribute








.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.ValidationAttributeAdapter`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.ValidationAttributeAdapter<TAttribute>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.ValidationAttributeAdapter<TAttribute>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.ValidationAttributeAdapter<TAttribute>.ValidationAttributeAdapter(TAttribute, Microsoft.Extensions.Localization.IStringLocalizer)
    
        
    
        
        Create a new instance of :any:`Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.ValidationAttributeAdapter\`1`\.
    
        
    
        
        :param attribute: The <em>TAttribute</em> instance to validate.
        
        :type attribute: TAttribute
    
        
        :param stringLocalizer: The :any:`Microsoft.Extensions.Localization.IStringLocalizer`\.
        
        :type stringLocalizer: Microsoft.Extensions.Localization.IStringLocalizer
    
        
        .. code-block:: csharp
    
            public ValidationAttributeAdapter(TAttribute attribute, IStringLocalizer stringLocalizer)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.ValidationAttributeAdapter<TAttribute>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.ValidationAttributeAdapter<TAttribute>.AddValidation(Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientModelValidationContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientModelValidationContext
    
        
        .. code-block:: csharp
    
            public abstract void AddValidation(ClientModelValidationContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.ValidationAttributeAdapter<TAttribute>.GetErrorMessage(Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata, System.Object[])
    
        
    
        
        Gets the error message formatted using the :dn:prop:`Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.ValidationAttributeAdapter\`1.Attribute`\.
    
        
    
        
        :param modelMetadata: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata` associated with the model annotated with 
            :dn:prop:`Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.ValidationAttributeAdapter\`1.Attribute`\.
        
        :type modelMetadata: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        :param arguments: The value arguments which will be used in constructing the error message.
        
        :type arguments: System.Object<System.Object>[]
        :rtype: System.String
        :return: Formatted error string.
    
        
        .. code-block:: csharp
    
            protected virtual string GetErrorMessage(ModelMetadata modelMetadata, params object[] arguments)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.ValidationAttributeAdapter<TAttribute>.MergeAttribute(System.Collections.Generic.IDictionary<System.String, System.String>, System.String, System.String)
    
        
    
        
        Adds the given <em>key</em> and <em>value</em> into
        <em>attributes</em> if <em>attributes</em> does not contain a value for
        <em>key</em>.
    
        
    
        
        :param attributes: The HTML attributes dictionary.
        
        :type attributes: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.String<System.String>}
    
        
        :param key: The attribute key.
        
        :type key: System.String
    
        
        :param value: The attribute value.
        
        :type value: System.String
        :rtype: System.Boolean
        :return: <code>true</code> if an attribute was added, otherwise <code>false</code>.
    
        
        .. code-block:: csharp
    
            protected static bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.ValidationAttributeAdapter<TAttribute>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.ValidationAttributeAdapter<TAttribute>.Attribute
    
        
    
        
        Gets the <em>TAttribute</em> instance.
    
        
        :rtype: TAttribute
    
        
        .. code-block:: csharp
    
            public TAttribute Attribute { get; }
    

