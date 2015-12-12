

ControllerActionDescriptorProvider Class
========================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Controllers.ControllerActionDescriptorProvider`








Syntax
------

.. code-block:: csharp

   public class ControllerActionDescriptorProvider : IActionDescriptorProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Controllers/ControllerActionDescriptorProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Controllers.ControllerActionDescriptorProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Controllers.ControllerActionDescriptorProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Controllers.ControllerActionDescriptorProvider.ControllerActionDescriptorProvider(Microsoft.AspNet.Mvc.Controllers.IControllerTypeProvider, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.ApplicationModels.IApplicationModelProvider>, Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Mvc.MvcOptions>)
    
        
        
        
        :type controllerTypeProvider: Microsoft.AspNet.Mvc.Controllers.IControllerTypeProvider
        
        
        :type applicationModelProviders: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.ApplicationModels.IApplicationModelProvider}
        
        
        :type optionsAccessor: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.AspNet.Mvc.MvcOptions}
    
        
        .. code-block:: csharp
    
           public ControllerActionDescriptorProvider(IControllerTypeProvider controllerTypeProvider, IEnumerable<IApplicationModelProvider> applicationModelProviders, IOptions<MvcOptions> optionsAccessor)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Controllers.ControllerActionDescriptorProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Controllers.ControllerActionDescriptorProvider.BuildModel()
    
        
        :rtype: Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModel
    
        
        .. code-block:: csharp
    
           protected ApplicationModel BuildModel()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controllers.ControllerActionDescriptorProvider.GetDescriptors()
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Controllers.ControllerActionDescriptor}
    
        
        .. code-block:: csharp
    
           protected IEnumerable<ControllerActionDescriptor> GetDescriptors()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controllers.ControllerActionDescriptorProvider.OnProvidersExecuted(Microsoft.AspNet.Mvc.Abstractions.ActionDescriptorProviderContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptorProviderContext
    
        
        .. code-block:: csharp
    
           public void OnProvidersExecuted(ActionDescriptorProviderContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controllers.ControllerActionDescriptorProvider.OnProvidersExecuting(Microsoft.AspNet.Mvc.Abstractions.ActionDescriptorProviderContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptorProviderContext
    
        
        .. code-block:: csharp
    
           public void OnProvidersExecuting(ActionDescriptorProviderContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Controllers.ControllerActionDescriptorProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Controllers.ControllerActionDescriptorProvider.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Order { get; }
    

