

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
* :dn:cls:`Microsoft.AspNet.Mvc.ViewFeatures.ModelMetadataProviderExtensions`








Syntax
------

.. code-block:: csharp

   public class ModelMetadataProviderExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewFeatures/ModelMetadataProviderExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.ModelMetadataProviderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.ModelMetadataProviderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.ModelMetadataProviderExtensions.GetModelExplorerForType(Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider, System.Type, System.Object)
    
        
    
        Gets a :any:`Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer` for the provided ``modelType`` and
        ``model``.
    
        
        
        
        :param provider: The .
        
        :type provider: Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider
        
        
        :param modelType: The declared  of the model object.
        
        :type modelType: System.Type
        
        
        :param model: The model object.
        
        :type model: System.Object
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        :return: A <see cref="T:Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer" /> for the <paramref name="modelType" /> and <paramref name="model" />.
    
        
        .. code-block:: csharp
    
           public static ModelExplorer GetModelExplorerForType(IModelMetadataProvider provider, Type modelType, object model)
    

