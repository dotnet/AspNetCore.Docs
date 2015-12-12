

ModelMetadataProviderExtensions Class
=====================================



.. contents:: 
   :local:



Summary
-------

Extensions methods for :any:`Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadataProviderExtensions`








Syntax
------

.. code-block:: csharp

   public class ModelMetadataProviderExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ModelBinding/ModelMetadataProviderExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadataProviderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadataProviderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadataProviderExtensions.GetMetadataForProperty(Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider, System.Type, System.String)
    
        
    
        Gets a :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata` for property identified by the provided
        ``containerType`` and ``propertyName``.
    
        
        
        
        :param provider: The .
        
        :type provider: Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider
        
        
        :param containerType: The  for which the property is defined.
        
        :type containerType: System.Type
        
        
        :param propertyName: The property name.
        
        :type propertyName: System.String
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
        :return: A <see cref="T:Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata" /> for the property.
    
        
        .. code-block:: csharp
    
           public static ModelMetadata GetMetadataForProperty(IModelMetadataProvider provider, Type containerType, string propertyName)
    

