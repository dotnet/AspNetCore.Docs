

DefaultControllerArgumentBinder Class
=====================================






Provides a default implementation of :any:`Microsoft.AspNetCore.Mvc.Internal.IControllerArgumentBinder`\.
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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.DefaultControllerArgumentBinder`








Syntax
------

.. code-block:: csharp

    public class DefaultControllerArgumentBinder : IControllerArgumentBinder








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultControllerArgumentBinder
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultControllerArgumentBinder

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultControllerArgumentBinder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.DefaultControllerArgumentBinder.DefaultControllerArgumentBinder(Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider, Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinderFactory, Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IObjectModelValidator)
    
        
    
        
        :type modelMetadataProvider: Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider
    
        
        :type modelBinderFactory: Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinderFactory
    
        
        :type validator: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IObjectModelValidator
    
        
        .. code-block:: csharp
    
            public DefaultControllerArgumentBinder(IModelMetadataProvider modelMetadataProvider, IModelBinderFactory modelBinderFactory, IObjectModelValidator validator)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultControllerArgumentBinder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.DefaultControllerArgumentBinder.BindArgumentsAsync(Microsoft.AspNetCore.Mvc.ControllerContext, System.Object, System.Collections.Generic.IDictionary<System.String, System.Object>)
    
        
    
        
        :type controllerContext: Microsoft.AspNetCore.Mvc.ControllerContext
    
        
        :type controller: System.Object
    
        
        :type arguments: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task BindArgumentsAsync(ControllerContext controllerContext, object controller, IDictionary<string, object> arguments)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.DefaultControllerArgumentBinder.BindModelAsync(Microsoft.AspNetCore.Mvc.Abstractions.ParameterDescriptor, Microsoft.AspNetCore.Mvc.ControllerContext)
    
        
    
        
        :type parameter: Microsoft.AspNetCore.Mvc.Abstractions.ParameterDescriptor
    
        
        :type controllerContext: Microsoft.AspNetCore.Mvc.ControllerContext
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult<Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult>}
    
        
        .. code-block:: csharp
    
            public Task<ModelBindingResult> BindModelAsync(ParameterDescriptor parameter, ControllerContext controllerContext)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.DefaultControllerArgumentBinder.BindModelAsync(Microsoft.AspNetCore.Mvc.Abstractions.ParameterDescriptor, Microsoft.AspNetCore.Mvc.ControllerContext, Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider)
    
        
    
        
        :type parameter: Microsoft.AspNetCore.Mvc.Abstractions.ParameterDescriptor
    
        
        :type controllerContext: Microsoft.AspNetCore.Mvc.ControllerContext
    
        
        :type valueProvider: Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult<Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult>}
    
        
        .. code-block:: csharp
    
            public Task<ModelBindingResult> BindModelAsync(ParameterDescriptor parameter, ControllerContext controllerContext, IValueProvider valueProvider)
    

