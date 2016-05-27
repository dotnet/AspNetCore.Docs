

IModelBinder Interface
======================






Defines an interface for model binders.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IModelBinder








.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder.BindModelAsync(Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext)
    
        
    
        
        Attempts to bind a model.
    
        
    
        
        :param bindingContext: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext`\.
        
        :type bindingContext: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext
        :rtype: System.Threading.Tasks.Task
        :return: 
            <p>
            A :any:`System.Threading.Tasks.Task` which on completion returns a :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult` which
            represents the result of the model binding process.
            </p>
            <p>
            If model binding was successful, the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult` should be a value created
            with :dn:meth:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult.Success(System.String,System.Object)`\. If model binding failed, the
            :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult` should be a value created with :dn:meth:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult.Failed(System.String)`\.
            If there was no data, or this model binder cannot handle the operation, the
            :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.Result` should be null.
            </p>
    
        
        .. code-block:: csharp
    
            Task BindModelAsync(ModelBindingContext bindingContext)
    

