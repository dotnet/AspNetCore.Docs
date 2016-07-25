

ModelMetadataProviderExtensions Class
=====================================






Extensions methods for :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadataProviderExtensions`








Syntax
------

.. code-block:: csharp

    public class ModelMetadataProviderExtensions








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadataProviderExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadataProviderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadataProviderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadataProviderExtensions.GetMetadataForProperty(Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider, System.Type, System.String)
    
        
    
        
        Gets a :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata` for property identified by the provided
        <em>containerType</em> and <em>propertyName</em>.
    
        
    
        
        :param provider: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.
        
        :type provider: Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider
    
        
        :param containerType: The :any:`System.Type` for which the property is defined.
        
        :type containerType: System.Type
    
        
        :param propertyName: The property name.
        
        :type propertyName: System.String
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
        :return: A :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata` for the property.
    
        
        .. code-block:: csharp
    
            public static ModelMetadata GetMetadataForProperty(this IModelMetadataProvider provider, Type containerType, string propertyName)
    

