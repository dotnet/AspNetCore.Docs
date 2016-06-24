

IApplicationModelProvider Interface
===================================






Builds or modifies an :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel` for action discovery.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ApplicationModels`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IApplicationModelProvider








.. dn:interface:: Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelProvider

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelProvider.OnProvidersExecuted(Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModelProviderContext)
    
        
    
        
        Executed for the second pass of :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel` building. See :dn:prop:`Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelProvider.Order`\.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModelProviderContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModelProviderContext
    
        
        .. code-block:: csharp
    
            void OnProvidersExecuted(ApplicationModelProviderContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelProvider.OnProvidersExecuting(Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModelProviderContext)
    
        
    
        
        Executed for the first pass of :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel` building. See :dn:prop:`Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelProvider.Order`\.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModelProviderContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModelProviderContext
    
        
        .. code-block:: csharp
    
            void OnProvidersExecuting(ApplicationModelProviderContext context)
    

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelProvider.Order
    
        
    
        
        Gets the order value for determining the order of execution of providers. Providers execute in
        ascending numeric value of the :dn:prop:`Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelProvider.Order` property.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            int Order { get; }
    

