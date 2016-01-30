

CancellationTokenModelBinder Class
==================================



.. contents:: 
   :local:



Summary
-------

:any:`Microsoft.AspNet.Mvc.ModelBinding.IModelBinder` implementation to bind models of type :any:`System.Threading.CancellationToken`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.CancellationTokenModelBinder`








Syntax
------

.. code-block:: csharp

   public class CancellationTokenModelBinder : IModelBinder





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ModelBinding/CancellationTokenModelBinder.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.CancellationTokenModelBinder

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.CancellationTokenModelBinder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.CancellationTokenModelBinder.BindModelAsync(Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext)
    
        
        
        
        :type bindingContext: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult}
    
        
        .. code-block:: csharp
    
           public Task<ModelBindingResult> BindModelAsync(ModelBindingContext bindingContext)
    

