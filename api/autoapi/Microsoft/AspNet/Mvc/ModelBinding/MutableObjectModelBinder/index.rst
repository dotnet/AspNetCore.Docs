

MutableObjectModelBinder Class
==============================



.. contents:: 
   :local:



Summary
-------

:any:`Microsoft.AspNet.Mvc.ModelBinding.IModelBinder` implementation for binding complex values.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.MutableObjectModelBinder`








Syntax
------

.. code-block:: csharp

   public class MutableObjectModelBinder : IModelBinder





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ModelBinding/MutableObjectModelBinder.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.MutableObjectModelBinder

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.MutableObjectModelBinder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.MutableObjectModelBinder.BindModelAsync(Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext)
    
        
        
        
        :type bindingContext: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult}
    
        
        .. code-block:: csharp
    
           public Task<ModelBindingResult> BindModelAsync(ModelBindingContext bindingContext)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.MutableObjectModelBinder.CanUpdateProperty(Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata)
    
        
    
        Gets an indication whether a property with the given ``propertyMetadata`` can be updated.
    
        
        
        
        :param propertyMetadata: for the property of interest.
        
        :type propertyMetadata: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
        :rtype: System.Boolean
        :return: <c>true</c> if the property can be updated; <c>false</c> otherwise.
    
        
        .. code-block:: csharp
    
           protected virtual bool CanUpdateProperty(ModelMetadata propertyMetadata)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.MutableObjectModelBinder.CreateModel(Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext)
    
        
    
        Creates suitable :any:`System.Object` for given ``bindingContext``.
    
        
        
        
        :param bindingContext: The .
        
        :type bindingContext: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext
        :rtype: System.Object
        :return: An <see cref="T:System.Object" /> compatible with <see cref="P:Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext.ModelType" />.
    
        
        .. code-block:: csharp
    
           protected virtual object CreateModel(ModelBindingContext bindingContext)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.MutableObjectModelBinder.GetMetadataForProperties(Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext)
    
        
    
        Gets the collection of :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata` for properties this binder should update.
    
        
        
        
        :param bindingContext: The .
        
        :type bindingContext: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata}
        :return: Collection of <see cref="T:Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata" /> for properties this binder should update.
    
        
        .. code-block:: csharp
    
           protected virtual IEnumerable<ModelMetadata> GetMetadataForProperties(ModelBindingContext bindingContext)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.MutableObjectModelBinder.GetModel(Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext)
    
        
    
        Get :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext.Model` if that property is not <c>null</c>. Otherwise activate a
        new instance of :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext.ModelType`\.
    
        
        
        
        :param bindingContext: The .
        
        :type bindingContext: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           protected virtual object GetModel(ModelBindingContext bindingContext)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.MutableObjectModelBinder.SetProperty(Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext, Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata, Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata, Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult)
    
        
    
        Updates a property in the current :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext.Model`\.
    
        
        
        
        :param bindingContext: The .
        
        :type bindingContext: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext
        
        
        :param metadata: The  for the model containing property to set.
        
        :type metadata: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
        
        
        :param propertyMetadata: The  for the property to set.
        
        :type propertyMetadata: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
        
        
        :param result: The  for the property's new value.
        
        :type result: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult
    
        
        .. code-block:: csharp
    
           protected virtual void SetProperty(ModelBindingContext bindingContext, ModelMetadata metadata, ModelMetadata propertyMetadata, ModelBindingResult result)
    

