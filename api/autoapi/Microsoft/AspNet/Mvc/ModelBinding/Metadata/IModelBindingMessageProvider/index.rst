

IModelBindingMessageProvider Interface
======================================



.. contents:: 
   :local:



Summary
-------

Provider for error messages the model binding system detects.











Syntax
------

.. code-block:: csharp

   public interface IModelBindingMessageProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/Metadata/IModelBindingMessageProvider.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.IModelBindingMessageProvider

Properties
----------

.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.IModelBindingMessageProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.IModelBindingMessageProvider.MissingBindRequiredValueAccessor
    
        
    
        Error message the model binding system adds when a property with an associated
        <c>BindRequiredAttribute</c> is not bound.
    
        
        :rtype: System.Func{System.String,System.String}
    
        
        .. code-block:: csharp
    
           Func<string, string> MissingBindRequiredValueAccessor { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.IModelBindingMessageProvider.MissingKeyOrValueAccessor
    
        
    
        Error message the model binding system adds when either the key or the value of a 
        :any:`System.Collections.Generic.KeyValuePair\`2` is bound but not both.
    
        
        :rtype: System.Func{System.String}
    
        
        .. code-block:: csharp
    
           Func<string> MissingKeyOrValueAccessor { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.IModelBindingMessageProvider.ValueMustNotBeNullAccessor
    
        
    
        Error message the model binding system adds when a <c>null</c> value is bound to a
        non- :any:`System.Nullable` property.
    
        
        :rtype: System.Func{System.String,System.String}
    
        
        .. code-block:: csharp
    
           Func<string, string> ValueMustNotBeNullAccessor { get; }
    

