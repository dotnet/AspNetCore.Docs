

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
            A :any:`System.Threading.Tasks.Task` which will complete when the model binding process completes.
            </p>
            <p>
            If model binding was successful, the :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.Result` should have 
            :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult.IsModelSet` set to <code>true</code>.
            </p>
            <p>
            A model binder that completes successfully should set :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.Result` to
            a value returned from :dn:meth:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult.Success(System.Object)`\. 
            </p>
    
        
        .. code-block:: csharp
    
            Task BindModelAsync(ModelBindingContext bindingContext)
    

