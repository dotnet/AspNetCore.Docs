

BindingMetadata Class
=====================



.. contents:: 
   :local:



Summary
-------

Binding metadata details for a :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.BindingMetadata`








Syntax
------

.. code-block:: csharp

   public class BindingMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ModelBinding/Metadata/BindingMetadata.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.BindingMetadata

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.BindingMetadata
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.BindingMetadata.BinderModelName
    
        
    
        Gets or sets the binder model name. If <c>null</c> the property or parameter name will be used.
        See :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.BinderModelName`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string BinderModelName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.BindingMetadata.BinderType
    
        
    
        Gets or sets the :any:`System.Type` of the model binder used to bind the model.
        See :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.BinderType`\.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           public Type BinderType { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.BindingMetadata.BindingSource
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ModelBinding.BindingSource`\.
        See :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.BindingSource`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.BindingSource
    
        
        .. code-block:: csharp
    
           public BindingSource BindingSource { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.BindingMetadata.IsBindingAllowed
    
        
    
        Gets or sets a value indicating whether or not the property can be model bound.
        Will be ignored if the model metadata being created does not represent a property.
        See :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.IsBindingAllowed`\.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsBindingAllowed { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.BindingMetadata.IsBindingRequired
    
        
    
        Gets or sets a value indicating whether or not the request must contain a value for the model.
        Will be ignored if the model metadata being created does not represent a property.
        See :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.IsBindingRequired`\.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsBindingRequired { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.BindingMetadata.IsReadOnly
    
        
    
        Gets or sets a value indicating whether or not the model is read-only. Will be ignored
        if the model metadata being created is not a property. If <c>null</c> then 
        :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.IsReadOnly` will be  computed based on the accessibility
        of the property accessor and model :any:`System.Type`\. See :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.IsReadOnly`\.
    
        
        :rtype: System.Nullable{System.Boolean}
    
        
        .. code-block:: csharp
    
           public bool ? IsReadOnly { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.BindingMetadata.ModelBindingMessageProvider
    
        
    
        Gets the :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider` instance. See 
        :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.ModelBindingMessageProvider`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider
    
        
        .. code-block:: csharp
    
           public ModelBindingMessageProvider ModelBindingMessageProvider { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.BindingMetadata.PropertyBindingPredicateProvider
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ModelBinding.IPropertyBindingPredicateProvider`\.
        See :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.PropertyBindingPredicateProvider`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.IPropertyBindingPredicateProvider
    
        
        .. code-block:: csharp
    
           public IPropertyBindingPredicateProvider PropertyBindingPredicateProvider { get; set; }
    

