

FormCollectionModelBinder Class
===============================



.. contents:: 
   :local:



Summary
-------

:any:`Microsoft.AspNet.Mvc.ModelBinding.IModelBinder` implementation to bind form values to :any:`Microsoft.AspNet.Http.IFormCollection`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.FormCollectionModelBinder`








Syntax
------

.. code-block:: csharp

   public class FormCollectionModelBinder : IModelBinder





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ModelBinding/FormCollectionModelBinder.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.FormCollectionModelBinder

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.FormCollectionModelBinder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.FormCollectionModelBinder.BindModelAsync(Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext)
    
        
        
        
        :type bindingContext: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult}
    
        
        .. code-block:: csharp
    
           public Task<ModelBindingResult> BindModelAsync(ModelBindingContext bindingContext)
    

