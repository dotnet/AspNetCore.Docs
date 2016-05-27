

ControllerArgumentBinder Class
==============================






Provides a default implementation of :any:`Microsoft.AspNetCore.Mvc.Controllers.IControllerActionArgumentBinder`\.
Uses ModelBinding to populate action parameters.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.ControllerArgumentBinder`








Syntax
------

.. code-block:: csharp

    public class ControllerArgumentBinder : IControllerActionArgumentBinder








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerArgumentBinder
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerArgumentBinder

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerArgumentBinder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.ControllerArgumentBinder.ControllerArgumentBinder(Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider, Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinderFactory, Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IObjectModelValidator)
    
        
    
        
        :type modelMetadataProvider: Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider
    
        
        :type modelBinderFactory: Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinderFactory
    
        
        :type validator: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IObjectModelValidator
    
        
        .. code-block:: csharp
    
            public ControllerArgumentBinder(IModelMetadataProvider modelMetadataProvider, IModelBinderFactory modelBinderFactory, IObjectModelValidator validator)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerArgumentBinder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ControllerArgumentBinder.BindActionArgumentsAsync(Microsoft.AspNetCore.Mvc.ControllerContext, System.Object)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ControllerContext
    
        
        :type controller: System.Object
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}}
    
        
        .. code-block:: csharp
    
            public Task<IDictionary<string, object>> BindActionArgumentsAsync(ControllerContext context, object controller)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ControllerArgumentBinder.BindModelAsync(Microsoft.AspNetCore.Mvc.Abstractions.ParameterDescriptor, Microsoft.AspNetCore.Mvc.ModelBinding.OperationBindingContext)
    
        
    
        
        :type parameter: Microsoft.AspNetCore.Mvc.Abstractions.ParameterDescriptor
    
        
        :type operationContext: Microsoft.AspNetCore.Mvc.ModelBinding.OperationBindingContext
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Nullable<System.Nullable`1>{Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult<Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult>}}
    
        
        .. code-block:: csharp
    
            public Task<ModelBindingResult? > BindModelAsync(ParameterDescriptor parameter, OperationBindingContext operationContext)
    

