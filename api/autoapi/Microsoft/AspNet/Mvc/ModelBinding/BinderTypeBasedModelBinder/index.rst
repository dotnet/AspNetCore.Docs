

BinderTypeBasedModelBinder Class
================================



.. contents:: 
   :local:



Summary
-------

An :any:`Microsoft.AspNet.Mvc.ModelBinding.IModelBinder` which can bind a model based on the value of 
:dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.BinderType`\. The supplied :any:`Microsoft.AspNet.Mvc.ModelBinding.IModelBinder`
type will be used to bind the model.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.BinderTypeBasedModelBinder`








Syntax
------

.. code-block:: csharp

   public class BinderTypeBasedModelBinder : IModelBinder





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ModelBinding/BinderTypeBasedModelBinder.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.BinderTypeBasedModelBinder

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.BinderTypeBasedModelBinder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.BinderTypeBasedModelBinder.BindModelAsync(Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext)
    
        
        
        
        :type bindingContext: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult}
    
        
        .. code-block:: csharp
    
           public Task<ModelBindingResult> BindModelAsync(ModelBindingContext bindingContext)
    

