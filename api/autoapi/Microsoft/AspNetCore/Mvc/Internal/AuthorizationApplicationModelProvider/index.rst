

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

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.AuthorizationApplicationModelProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.AuthorizationApplicationModelProvider.AuthorizationApplicationModelProvider(Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider)
    
        
    
        
        :type policyProvider: Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider
    
        
        .. code-block:: csharp
    
            public AuthorizationApplicationModelProvider(IAuthorizationPolicyProvider policyProvider)
    

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
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.AuthorizationApplicationModelProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.AuthorizationApplicationModelProvider.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Order { get; }
    

