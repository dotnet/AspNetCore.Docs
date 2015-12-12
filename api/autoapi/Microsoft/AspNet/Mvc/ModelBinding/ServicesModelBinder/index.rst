

ServicesModelBinder Class
=========================



.. contents:: 
   :local:



Summary
-------

An :any:`Microsoft.AspNet.Mvc.ModelBinding.IModelBinder` which binds models from the request services when a model
has the binding source :dn:field:`Microsoft.AspNet.Mvc.ModelBinding.BindingSource.Services`\/





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.ServicesModelBinder`








Syntax
------

.. code-block:: csharp

   public class ServicesModelBinder : IModelBinder





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ModelBinding/ServicesModelBinder.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ServicesModelBinder

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ServicesModelBinder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ServicesModelBinder.BindModelAsync(Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext)
    
        
        
        
        :type bindingContext: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult}
    
        
        .. code-block:: csharp
    
           public Task<ModelBindingResult> BindModelAsync(ModelBindingContext bindingContext)
    

