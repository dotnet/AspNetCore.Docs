

IModelBindingMessageProvider Interface
======================================






Provider for error messages the model binding system detects.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IModelBindingMessageProvider








.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IModelBindingMessageProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IModelBindingMessageProvider

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IModelBindingMessageProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IModelBindingMessageProvider.AttemptedValueIsInvalidAccessor
    
        
    
        
        Error message the model binding system adds when :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelError.Exception` is of type
        :any:`System.FormatException` or :any:`System.OverflowException` and value is known.
    
        
        :rtype: System.Func<System.Func`3>{System.String<System.String>, System.String<System.String>, System.String<System.String>}
        :return: Default :any:`System.String` is "The value '{0}' is not valid for {1}.".
    
        
        .. code-block:: csharp
    
            Func<string, string, string> AttemptedValueIsInvalidAccessor
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IModelBindingMessageProvider.MissingBindRequiredValueAccessor
    
        
    
        
        Error message the model binding system adds when a property with an associated
        <code>BindRequiredAttribute</code> is not bound.
    
        
        :rtype: System.Func<System.Func`2>{System.String<System.String>, System.String<System.String>}
        :return: Default :any:`System.String` is "A value for the '{0}' property was not provided.".
    
        
        .. code-block:: csharp
    
            Func<string, string> MissingBindRequiredValueAccessor
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IModelBindingMessageProvider.MissingKeyOrValueAccessor
    
        
    
        
        Error message the model binding system adds when either the key or the value of a
        :any:`System.Collections.Generic.KeyValuePair\`2` is bound but not both.
    
        
        :rtype: System.Func<System.Func`1>{System.String<System.String>}
        :return: Default :any:`System.String` is "A value is required.".
    
        
        .. code-block:: csharp
    
            Func<string> MissingKeyOrValueAccessor
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IModelBindingMessageProvider.UnknownValueIsInvalidAccessor
    
        
    
        
        Error message the model binding system adds when :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelError.Exception` is of type
        :any:`System.FormatException` or :any:`System.OverflowException` and value is unknown.
    
        
        :rtype: System.Func<System.Func`2>{System.String<System.String>, System.String<System.String>}
        :return: Default :any:`System.String` is "The supplied value is invalid for {0}.".
    
        
        .. code-block:: csharp
    
            Func<string, string> UnknownValueIsInvalidAccessor
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IModelBindingMessageProvider.ValueIsInvalidAccessor
    
        
    
        
        Fallback error message HTML and tag helpers display when a property is invalid but the
        :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelError`\s have <code>null</code> :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelError.ErrorMessage`\s.
    
        
        :rtype: System.Func<System.Func`2>{System.String<System.String>, System.String<System.String>}
        :return: Default :any:`System.String` is "The value '{0}' is invalid.".
    
        
        .. code-block:: csharp
    
            Func<string, string> ValueIsInvalidAccessor
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IModelBindingMessageProvider.ValueMustBeANumberAccessor
    
        
    
        
        Error message HTML and tag helpers add for client-side validation of numeric formats. Visible in the
        browser if the field for a <code>float</code> property (for example) does not have a correctly-formatted value.
    
        
        :rtype: System.Func<System.Func`2>{System.String<System.String>, System.String<System.String>}
        :return: Default :any:`System.String` is "The field {0} must be a number.".
    
        
        .. code-block:: csharp
    
            Func<string, string> ValueMustBeANumberAccessor
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IModelBindingMessageProvider.ValueMustNotBeNullAccessor
    
        
    
        
        Error message the model binding system adds when a <code>null</code> value is bound to a
        non- :any:`System.Nullable` property.
    
        
        :rtype: System.Func<System.Func`2>{System.String<System.String>, System.String<System.String>}
        :return: Default :any:`System.String` is "The value '{0}' is invalid.".
    
        
        .. code-block:: csharp
    
            Func<string, string> ValueMustNotBeNullAccessor
            {
                get;
            }
    

