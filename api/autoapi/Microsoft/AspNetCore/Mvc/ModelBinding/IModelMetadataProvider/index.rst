

IModelMetadataProvider Interface
================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IModelMetadataProvider








.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider.GetMetadataForProperties(System.Type)
    
        
    
        
        :type modelType: System.Type
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata<Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata>}
    
        
        .. code-block:: csharp
    
            IEnumerable<ModelMetadata> GetMetadataForProperties(Type modelType)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider.GetMetadataForType(System.Type)
    
        
    
        
        :type modelType: System.Type
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
            ModelMetadata GetMetadataForType(Type modelType)
    

