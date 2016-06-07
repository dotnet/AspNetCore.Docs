

AuthorizationApplicationModelProvider Class
===========================================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.AuthorizationApplicationModelProvider`








Syntax
------

.. code-block:: csharp

    public class AuthorizationApplicationModelProvider : IApplicationModelProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.AuthorizationApplicationModelProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.AuthorizationApplicationModelProvider

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.AuthorizationApplicationModelProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.AuthorizationApplicationModelProvider.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Order
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.AuthorizationApplicationModelProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.AuthorizationApplicationModelProvider.AuthorizationApplicationModelProvider(Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Authorization.AuthorizationOptions>)
    
        
    
        
        :type authorizationOptionsAccessor: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Authorization.AuthorizationOptions<Microsoft.AspNetCore.Authorization.AuthorizationOptions>}
    
        
        .. code-block:: csharp
    
            public AuthorizationApplicationModelProvider(IOptions<AuthorizationOptions> authorizationOptionsAccessor)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.AuthorizationApplicationModelProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.AuthorizationApplicationModelProvider.OnProvidersExecuted(Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModelProviderContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModelProviderContext
    
        
        .. code-block:: csharp
    
            public void OnProvidersExecuted(ApplicationModelProviderContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.AuthorizationApplicationModelProvider.OnProvidersExecuting(Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModelProviderContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModelProviderContext
    
        
        .. code-block:: csharp
    
            public void OnProvidersExecuting(ApplicationModelProviderContext context)
    

