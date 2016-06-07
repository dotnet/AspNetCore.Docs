

ControllerActionInvokerCache Class
==================================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvokerCache`








Syntax
------

.. code-block:: csharp

    public class ControllerActionInvokerCache








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvokerCache
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvokerCache

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvokerCache
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvokerCache.ControllerActionInvokerCache(Microsoft.AspNetCore.Mvc.Infrastructure.IActionDescriptorCollectionProvider, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.Filters.IFilterProvider>)
    
        
    
        
        :type collectionProvider: Microsoft.AspNetCore.Mvc.Infrastructure.IActionDescriptorCollectionProvider
    
        
        :type filterProviders: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.Filters.IFilterProvider<Microsoft.AspNetCore.Mvc.Filters.IFilterProvider>}
    
        
        .. code-block:: csharp
    
            public ControllerActionInvokerCache(IActionDescriptorCollectionProvider collectionProvider, IEnumerable<IFilterProvider> filterProviders)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvokerCache
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvokerCache.GetState(Microsoft.AspNetCore.Mvc.ControllerContext)
    
        
    
        
        :type controllerContext: Microsoft.AspNetCore.Mvc.ControllerContext
        :rtype: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvokerCache.ControllerActionInvokerState
    
        
        .. code-block:: csharp
    
            public ControllerActionInvokerCache.ControllerActionInvokerState GetState(ControllerContext controllerContext)
    

