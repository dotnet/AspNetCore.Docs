

BindingMetadata Class
=====================






Binding metadata details for a :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadata`








Syntax
------

.. code-block:: csharp

    public class BindingMetadata








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadata
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadata

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadata
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadata.BinderModelName
    
        
    
        
        Gets or sets the binder model name. If <code>null</code> the property or parameter name will be used.
        See :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.BinderModelName`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string BinderModelName { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadata.BinderType
    
        
    
        
        Gets or sets the :any:`System.Type` of the model binder used to bind the model.
        See :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.BinderType`\.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public Type BinderType { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadata.BindingSource
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource`\.
        See :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.BindingSource`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
    
        
        .. code-block:: csharp
    
            public BindingSource BindingSource { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadata.IsBindingAllowed
    
        
    
        
        Gets or sets a value indicating whether or not the property can be model bound.
        Will be ignored if the model metadata being created does not represent a property.
        See :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.IsBindingAllowed`\.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsBindingAllowed { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadata.IsBindingRequired
    
        
    
        
        Gets or sets a value indicating whether or not the request must contain a value for the model.
        Will be ignored if the model metadata being created does not represent a property.
        See :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.IsBindingRequired`\.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsBindingRequired { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadata.IsReadOnly
    
        
    
        
        Gets or sets a value indicating whether or not the model is read-only. Will be ignored
        if the model metadata being created is not a property. If <code>null</code> then 
        :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.IsReadOnly` will be  computed based on the accessibility
        of the property accessor and model :any:`System.Type`\. See :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.IsReadOnly`\.
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            public bool ? IsReadOnly { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadata.ModelBindingMessageProvider
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider` instance. See 
        :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.ModelBindingMessageProvider`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider
    
        
        .. code-block:: csharp
    
            public ModelBindingMessageProvider ModelBindingMessageProvider { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadata.PropertyFilterProvider
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IPropertyFilterProvider`\.
        See :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.PropertyFilterProvider`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.IPropertyFilterProvider
    
        
        .. code-block:: csharp
    
            public IPropertyFilterProvider PropertyFilterProvider { get; set; }
    

