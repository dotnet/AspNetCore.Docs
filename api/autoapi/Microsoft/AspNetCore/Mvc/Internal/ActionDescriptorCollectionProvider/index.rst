

ActionDescriptorCollectionProvider Class
========================================






Default implementation of :any:`Microsoft.AspNetCore.Mvc.Infrastructure.IActionDescriptorCollectionProvider`\.
This implementation caches the results at first call, and is not responsible for updates.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.ActionDescriptorCollectionProvider`








Syntax
------

.. code-block:: csharp

    public class ActionDescriptorCollectionProvider : IActionDescriptorCollectionProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ActionDescriptorCollectionProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ActionDescriptorCollectionProvider

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ActionDescriptorCollectionProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.ActionDescriptorCollectionProvider.ActionDescriptorCollectionProvider(System.IServiceProvider)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.Internal.ActionDescriptorCollectionProvider` class.
    
        
    
        
        :param serviceProvider: The application IServiceProvider.
        
        :type serviceProvider: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            public ActionDescriptorCollectionProvider(IServiceProvider serviceProvider)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ActionDescriptorCollectionProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.ActionDescriptorCollectionProvider.ActionDescriptors
    
        
    
        
        Returns a cached collection of :any:`Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Infrastructure.ActionDescriptorCollection
    
        
        .. code-block:: csharp
    
            public ActionDescriptorCollection ActionDescriptors { get; }
    

