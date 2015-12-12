

HttpRequestMessageModelBinder Class
===================================



.. contents:: 
   :local:



Summary
-------

:any:`Microsoft.AspNet.Mvc.ModelBinding.IModelBinder` implementation to bind models of type :any:`System.Net.Http.HttpRequestMessage`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.WebApiCompatShim.HttpRequestMessageModelBinder`








Syntax
------

.. code-block:: csharp

   public class HttpRequestMessageModelBinder : IModelBinder





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.WebApiCompatShim/HttpRequestMessage/HttpRequestMessageModelBinder.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.WebApiCompatShim.HttpRequestMessageModelBinder

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.WebApiCompatShim.HttpRequestMessageModelBinder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.WebApiCompatShim.HttpRequestMessageModelBinder.BindModelAsync(Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext)
    
        
        
        
        :type bindingContext: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult}
    
        
        .. code-block:: csharp
    
           public Task<ModelBindingResult> BindModelAsync(ModelBindingContext bindingContext)
    

