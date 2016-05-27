

ControllerActionDescriptorProvider Class
========================================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.ControllerActionDescriptorProvider`








Syntax
------

.. code-block:: csharp

    public class ControllerActionDescriptorProvider : IActionDescriptorProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionDescriptorProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionDescriptorProvider

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionDescriptorProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionDescriptorProvider.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Order
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionDescriptorProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionDescriptorProvider.ControllerActionDescriptorProvider(Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelProvider>, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Mvc.MvcOptions>)
    
        
    
        
        :type partManager: Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager
    
        
        :type applicationModelProviders: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelProvider<Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelProvider>}
    
        
        :type optionsAccessor: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Mvc.MvcOptions<Microsoft.AspNetCore.Mvc.MvcOptions>}
    
        
        .. code-block:: csharp
    
            public ControllerActionDescriptorProvider(ApplicationPartManager partManager, IEnumerable<IApplicationModelProvider> applicationModelProviders, IOptions<MvcOptions> optionsAccessor)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionDescriptorProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionDescriptorProvider.BuildModel()
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel
    
        
        .. code-block:: csharp
    
            protected ApplicationModel BuildModel()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionDescriptorProvider.GetDescriptors()
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor<Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor>}
    
        
        .. code-block:: csharp
    
            protected IEnumerable<ControllerActionDescriptor> GetDescriptors()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionDescriptorProvider.OnProvidersExecuted(Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptorProviderContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptorProviderContext
    
        
        .. code-block:: csharp
    
            public void OnProvidersExecuted(ActionDescriptorProviderContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionDescriptorProvider.OnProvidersExecuting(Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptorProviderContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptorProviderContext
    
        
        .. code-block:: csharp
    
            public void OnProvidersExecuting(ActionDescriptorProviderContext context)
    

