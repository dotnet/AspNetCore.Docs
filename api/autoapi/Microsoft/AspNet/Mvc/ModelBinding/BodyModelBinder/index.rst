

BodyModelBinder Class
=====================



.. contents:: 
   :local:



Summary
-------

An :any:`Microsoft.AspNet.Mvc.ModelBinding.IModelBinder` which binds models from the request body using an :any:`Microsoft.AspNet.Mvc.Formatters.IInputFormatter`
when a model has the binding source :dn:field:`Microsoft.AspNet.Mvc.ModelBinding.BindingSource.Body`\/





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.BodyModelBinder`








Syntax
------

.. code-block:: csharp

   public class BodyModelBinder : IModelBinder





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ModelBinding/BodyModelBinder.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.BodyModelBinder

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.BodyModelBinder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.BodyModelBinder.BindModelAsync(Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext)
    
        
        
        
        :type bindingContext: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult}
    
        
        .. code-block:: csharp
    
           public Task<ModelBindingResult> BindModelAsync(ModelBindingContext bindingContext)
    

