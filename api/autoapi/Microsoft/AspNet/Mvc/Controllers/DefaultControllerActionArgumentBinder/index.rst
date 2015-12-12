

DefaultControllerActionArgumentBinder Class
===========================================



.. contents:: 
   :local:



Summary
-------

Provides a default implementation of :any:`Microsoft.AspNet.Mvc.Controllers.IControllerActionArgumentBinder`\.
Uses ModelBinding to populate action parameters.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Controllers.DefaultControllerActionArgumentBinder`








Syntax
------

.. code-block:: csharp

   public class DefaultControllerActionArgumentBinder : IControllerActionArgumentBinder





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Controllers/DefaultControllerActionArgumentBinder.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Controllers.DefaultControllerActionArgumentBinder

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Controllers.DefaultControllerActionArgumentBinder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Controllers.DefaultControllerActionArgumentBinder.DefaultControllerActionArgumentBinder(Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider, Microsoft.AspNet.Mvc.ModelBinding.Validation.IObjectModelValidator)
    
        
        
        
        :type modelMetadataProvider: Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider
        
        
        :type validator: Microsoft.AspNet.Mvc.ModelBinding.Validation.IObjectModelValidator
    
        
        .. code-block:: csharp
    
           public DefaultControllerActionArgumentBinder(IModelMetadataProvider modelMetadataProvider, IObjectModelValidator validator)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Controllers.DefaultControllerActionArgumentBinder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Controllers.DefaultControllerActionArgumentBinder.BindActionArgumentsAsync(Microsoft.AspNet.Mvc.ActionContext, Microsoft.AspNet.Mvc.ActionBindingContext, System.Object)
    
        
        
        
        :type actionContext: Microsoft.AspNet.Mvc.ActionContext
        
        
        :type actionBindingContext: Microsoft.AspNet.Mvc.ActionBindingContext
        
        
        :type controller: System.Object
        :rtype: System.Threading.Tasks.Task{System.Collections.Generic.IDictionary{System.String,System.Object}}
    
        
        .. code-block:: csharp
    
           public Task<IDictionary<string, object>> BindActionArgumentsAsync(ActionContext actionContext, ActionBindingContext actionBindingContext, object controller)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controllers.DefaultControllerActionArgumentBinder.BindModelAsync(Microsoft.AspNet.Mvc.Abstractions.ParameterDescriptor, Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary, Microsoft.AspNet.Mvc.ModelBinding.OperationBindingContext)
    
        
        
        
        :type parameter: Microsoft.AspNet.Mvc.Abstractions.ParameterDescriptor
        
        
        :type modelState: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
        
        
        :type operationContext: Microsoft.AspNet.Mvc.ModelBinding.OperationBindingContext
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult}
    
        
        .. code-block:: csharp
    
           public Task<ModelBindingResult> BindModelAsync(ParameterDescriptor parameter, ModelStateDictionary modelState, OperationBindingContext operationContext)
    

