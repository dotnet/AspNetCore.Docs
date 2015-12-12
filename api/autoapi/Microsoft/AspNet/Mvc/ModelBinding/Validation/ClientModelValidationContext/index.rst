

ClientModelValidationContext Class
==================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientModelValidationContext`








Syntax
------

.. code-block:: csharp

   public class ClientModelValidationContext





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/Validation/ClientModelValidationContext.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientModelValidationContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientModelValidationContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientModelValidationContext.ClientModelValidationContext(Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata, Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider, System.IServiceProvider)
    
        
        
        
        :type metadata: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
        
        
        :type metadataProvider: Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider
        
        
        :type requestServices: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public ClientModelValidationContext(ModelMetadata metadata, IModelMetadataProvider metadataProvider, IServiceProvider requestServices)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientModelValidationContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientModelValidationContext.MetadataProvider
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider
    
        
        .. code-block:: csharp
    
           public IModelMetadataProvider MetadataProvider { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientModelValidationContext.ModelMetadata
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
           public ModelMetadata ModelMetadata { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientModelValidationContext.RequestServices
    
        
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public IServiceProvider RequestServices { get; }
    

