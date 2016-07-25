

ControllerActionInvokerState Struct
===================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvokerCache`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public struct ControllerActionInvokerState








.. dn:structure:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvokerCache.ControllerActionInvokerState
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvokerCache.ControllerActionInvokerState

Constructors
------------

.. dn:structure:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvokerCache.ControllerActionInvokerState
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvokerCache.ControllerActionInvokerState.ControllerActionInvokerState(Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata[], Microsoft.AspNetCore.Mvc.Internal.ObjectMethodExecutor)
    
        
    
        
        :type filters: Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata<Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata>[]
    
        
        :type actionMethodExecutor: Microsoft.AspNetCore.Mvc.Internal.ObjectMethodExecutor
    
        
        .. code-block:: csharp
    
            public ControllerActionInvokerState(IFilterMetadata[] filters, ObjectMethodExecutor actionMethodExecutor)
    

Properties
----------

.. dn:structure:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvokerCache.ControllerActionInvokerState
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvokerCache.ControllerActionInvokerState.ActionMethodExecutor
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Internal.ObjectMethodExecutor
    
        
        .. code-block:: csharp
    
            public ObjectMethodExecutor ActionMethodExecutor { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvokerCache.ControllerActionInvokerState.Filters
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata<Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata>[]
    
        
        .. code-block:: csharp
    
            public IFilterMetadata[] Filters { get; }
    

