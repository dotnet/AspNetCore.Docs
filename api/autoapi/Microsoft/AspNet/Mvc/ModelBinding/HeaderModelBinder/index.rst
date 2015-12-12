

HeaderModelBinder Class
=======================



.. contents:: 
   :local:



Summary
-------

An :any:`Microsoft.AspNet.Mvc.ModelBinding.IModelBinder` which binds models from the request headers when a model
has the binding source :dn:field:`Microsoft.AspNet.Mvc.ModelBinding.BindingSource.Header`\/





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.HeaderModelBinder`








Syntax
------

.. code-block:: csharp

   public class HeaderModelBinder : IModelBinder





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ModelBinding/HeaderModelBinder.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.HeaderModelBinder

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.HeaderModelBinder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.HeaderModelBinder.BindModelAsync(Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext)
    
        
        
        
        :type bindingContext: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult}
    
        
        .. code-block:: csharp
    
           public Task<ModelBindingResult> BindModelAsync(ModelBindingContext bindingContext)
    

