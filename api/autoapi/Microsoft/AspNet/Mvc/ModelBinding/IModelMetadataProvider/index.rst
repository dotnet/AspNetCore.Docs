

IModelMetadataProvider Interface
================================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IModelMetadataProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/IModelMetadataProvider.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider.GetMetadataForProperties(System.Type)
    
        
        
        
        :type modelType: System.Type
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata}
    
        
        .. code-block:: csharp
    
           IEnumerable<ModelMetadata> GetMetadataForProperties(Type modelType)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider.GetMetadataForType(System.Type)
    
        
        
        
        :type modelType: System.Type
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
           ModelMetadata GetMetadataForType(Type modelType)
    

