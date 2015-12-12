

IApplicationModelProvider Interface
===================================



.. contents:: 
   :local:



Summary
-------

Builds or modifies an :any:`Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModel` for action discovery.











Syntax
------

.. code-block:: csharp

   public interface IApplicationModelProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ApplicationModels/IApplicationModelProvider.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ApplicationModels.IApplicationModelProvider

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.ApplicationModels.IApplicationModelProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ApplicationModels.IApplicationModelProvider.OnProvidersExecuted(Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModelProviderContext)
    
        
    
        Executed for the second pass of :any:`Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModel` building. See :dn:prop:`Microsoft.AspNet.Mvc.ApplicationModels.IApplicationModelProvider.Order`\.
    
        
        
        
        :param context: The .
        
        :type context: Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModelProviderContext
    
        
        .. code-block:: csharp
    
           void OnProvidersExecuted(ApplicationModelProviderContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ApplicationModels.IApplicationModelProvider.OnProvidersExecuting(Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModelProviderContext)
    
        
    
        Executed for the first pass of :any:`Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModel` building. See :dn:prop:`Microsoft.AspNet.Mvc.ApplicationModels.IApplicationModelProvider.Order`\.
    
        
        
        
        :param context: The .
        
        :type context: Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModelProviderContext
    
        
        .. code-block:: csharp
    
           void OnProvidersExecuting(ApplicationModelProviderContext context)
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.Mvc.ApplicationModels.IApplicationModelProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.IApplicationModelProvider.Order
    
        
    
        Gets the order value for determining the order of execution of providers. Providers execute in
        ascending numeric value of the :dn:prop:`Microsoft.AspNet.Mvc.ApplicationModels.IApplicationModelProvider.Order` property.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int Order { get; }
    

