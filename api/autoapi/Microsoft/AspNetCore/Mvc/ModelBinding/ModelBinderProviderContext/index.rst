

ModelBinderProviderContext Class
================================






A context object for :dn:meth:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinderProvider.GetBinder(Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderProviderContext)`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderProviderContext`








Syntax
------

.. code-block:: csharp

    public abstract class ModelBinderProviderContext








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderProviderContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderProviderContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderProviderContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderProviderContext.BindingInfo
    
        
    
        
        Gets the :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderProviderContext.BindingInfo`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo
    
        
        .. code-block:: csharp
    
            public abstract BindingInfo BindingInfo { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderProviderContext.Metadata
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
            public abstract ModelMetadata Metadata { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderProviderContext.MetadataProvider
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider
    
        
        .. code-block:: csharp
    
            public abstract IModelMetadataProvider MetadataProvider { get; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderProviderContext
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderProviderContext.CreateBinder(Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata)
    
        
    
        
        Creates an :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder` for the given <em>metadata</em>.
    
        
    
        
        :param metadata: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata` for the model.
        
        :type metadata: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder
        :return: An :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder`\.
    
        
        .. code-block:: csharp
    
            public abstract IModelBinder CreateBinder(ModelMetadata metadata)
    

