

DefaultActionDescriptorsCollectionProvider Class
================================================



.. contents:: 
   :local:



Summary
-------

Default implementation for ActionDescriptors.
This implementation caches the results at first call, and is not responsible for updates.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Infrastructure.DefaultActionDescriptorsCollectionProvider`








Syntax
------

.. code-block:: csharp

   public class DefaultActionDescriptorsCollectionProvider : IActionDescriptorsCollectionProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/Infrastructure/DefaultActionDescriptorsCollectionProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Infrastructure.DefaultActionDescriptorsCollectionProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Infrastructure.DefaultActionDescriptorsCollectionProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Infrastructure.DefaultActionDescriptorsCollectionProvider.DefaultActionDescriptorsCollectionProvider(System.IServiceProvider)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.Infrastructure.DefaultActionDescriptorsCollectionProvider` class.
    
        
        
        
        :param serviceProvider: The application IServiceProvider.
        
        :type serviceProvider: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public DefaultActionDescriptorsCollectionProvider(IServiceProvider serviceProvider)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Infrastructure.DefaultActionDescriptorsCollectionProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Infrastructure.DefaultActionDescriptorsCollectionProvider.ActionDescriptors
    
        
    
        Returns a cached collection of :any:`Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.Infrastructure.ActionDescriptorsCollection
    
        
        .. code-block:: csharp
    
           public ActionDescriptorsCollection ActionDescriptors { get; }
    

