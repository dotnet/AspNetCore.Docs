

IActionDescriptorsCollectionProvider Interface
==============================================



.. contents:: 
   :local:



Summary
-------

Provides the currently cached collection of :any:`Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor`\.











Syntax
------

.. code-block:: csharp

   public interface IActionDescriptorsCollectionProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/Infrastructure/IActionDescriptorsCollectionProvider.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Infrastructure.IActionDescriptorsCollectionProvider

Properties
----------

.. dn:interface:: Microsoft.AspNet.Mvc.Infrastructure.IActionDescriptorsCollectionProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Infrastructure.IActionDescriptorsCollectionProvider.ActionDescriptors
    
        
    
        Returns the current cached :any:`Microsoft.AspNet.Mvc.Infrastructure.ActionDescriptorsCollection`
    
        
        :rtype: Microsoft.AspNet.Mvc.Infrastructure.ActionDescriptorsCollection
    
        
        .. code-block:: csharp
    
           ActionDescriptorsCollection ActionDescriptors { get; }
    

