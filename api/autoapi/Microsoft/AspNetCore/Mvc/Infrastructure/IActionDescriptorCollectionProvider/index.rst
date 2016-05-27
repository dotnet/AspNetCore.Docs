

IActionDescriptorCollectionProvider Interface
=============================================






Provides the currently cached collection of :any:`Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Infrastructure`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IActionDescriptorCollectionProvider








.. dn:interface:: Microsoft.AspNetCore.Mvc.Infrastructure.IActionDescriptorCollectionProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Infrastructure.IActionDescriptorCollectionProvider

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Infrastructure.IActionDescriptorCollectionProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Infrastructure.IActionDescriptorCollectionProvider.ActionDescriptors
    
        
    
        
        Returns the current cached :any:`Microsoft.AspNetCore.Mvc.Infrastructure.ActionDescriptorCollection`
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Infrastructure.ActionDescriptorCollection
    
        
        .. code-block:: csharp
    
            ActionDescriptorCollection ActionDescriptors
            {
                get;
            }
    

