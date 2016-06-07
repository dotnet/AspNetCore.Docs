

ModelMetadataProviderExtensions Class
=====================================






Extensions methods for :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewFeatures`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelMetadataProviderExtensions`








Syntax
------

.. code-block:: csharp

    public class ModelMetadataProviderExtensions








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelMetadataProviderExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelMetadataProviderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelMetadataProviderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelMetadataProviderExtensions.GetModelExplorerForType(Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider, System.Type, System.Object)
    
        
    
        
        Gets a :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer` for the provided <em>modelType</em> and
        <em>model</em>.
    
        
    
        
        :param provider: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider`\.
        
        :type provider: Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider
    
        
        :param modelType: The declared :any:`System.Type` of the model object.
        
        :type modelType: System.Type
    
        
        :param model: The model object.
        
        :type model: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
        :return: 
            A :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer` for the <em>modelType</em> and <em>model</em>.
    
        
        .. code-block:: csharp
    
            public static ModelExplorer GetModelExplorerForType(IModelMetadataProvider provider, Type modelType, object model)
    

