

AuthorizationApplicationModelProvider Class
===========================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ApplicationModels.AuthorizationApplicationModelProvider`








Syntax
------

.. code-block:: csharp

   public class AuthorizationApplicationModelProvider : IApplicationModelProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ApplicationModels/AuthorizationApplicationModelProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ApplicationModels.AuthorizationApplicationModelProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ApplicationModels.AuthorizationApplicationModelProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ApplicationModels.AuthorizationApplicationModelProvider.AuthorizationApplicationModelProvider(Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Authorization.AuthorizationOptions>)
    
        
        
        
        :type authorizationOptionsAccessor: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.AspNet.Authorization.AuthorizationOptions}
    
        
        .. code-block:: csharp
    
           public AuthorizationApplicationModelProvider(IOptions<AuthorizationOptions> authorizationOptionsAccessor)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ApplicationModels.AuthorizationApplicationModelProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ApplicationModels.AuthorizationApplicationModelProvider.OnProvidersExecuted(Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModelProviderContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModelProviderContext
    
        
        .. code-block:: csharp
    
           public void OnProvidersExecuted(ApplicationModelProviderContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ApplicationModels.AuthorizationApplicationModelProvider.OnProvidersExecuting(Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModelProviderContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModelProviderContext
    
        
        .. code-block:: csharp
    
           public void OnProvidersExecuting(ApplicationModelProviderContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ApplicationModels.AuthorizationApplicationModelProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.AuthorizationApplicationModelProvider.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Order { get; }
    

