

IModelBinder Interface
======================



.. contents:: 
   :local:



Summary
-------

Interface for model binding.











Syntax
------

.. code-block:: csharp

   public interface IModelBinder





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/IModelBinder.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.IModelBinder

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.IModelBinder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.IModelBinder.BindModelAsync(Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext)
    
        
    
        Async function to bind to a particular model.
    
        
        
        
        :param bindingContext: The binding context which has the object to be bound.
        
        :type bindingContext: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult}
        :return: A Task which on completion returns a <see cref="T:Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult" /> which represents the result
            of the model binding process.
    
        
        .. code-block:: csharp
    
           Task<ModelBindingResult> BindModelAsync(ModelBindingContext bindingContext)
    

