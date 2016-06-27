

AssertionRequirement Class
==========================






Implements an :any:`Microsoft.AspNetCore.Authorization.IAuthorizationHandler` and :any:`Microsoft.AspNetCore.Authorization.IAuthorizationRequirement`
that takes a user specified assertion.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authorization.Infrastructure`
Assemblies
    * Microsoft.AspNetCore.Authorization

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authorization.Infrastructure.AssertionRequirement`








Syntax
------

.. code-block:: csharp

    public class AssertionRequirement : IAuthorizationHandler, IAuthorizationRequirement








.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.AssertionRequirement
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.AssertionRequirement

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.AssertionRequirement
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authorization.Infrastructure.AssertionRequirement.AssertionRequirement(System.Func<Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext, System.Boolean>)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Authorization.Infrastructure.AssertionRequirement`\.
    
        
    
        
        :param handler: Function that is called to handle this requirement.
        
        :type handler: System.Func<System.Func`2>{Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext<Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext>, System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            public AssertionRequirement(Func<AuthorizationHandlerContext, bool> handler)
    
    .. dn:constructor:: Microsoft.AspNetCore.Authorization.Infrastructure.AssertionRequirement.AssertionRequirement(System.Func<Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext, System.Threading.Tasks.Task<System.Boolean>>)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Authorization.Infrastructure.AssertionRequirement`\.
    
        
    
        
        :param handler: Function that is called to handle this requirement.
        
        :type handler: System.Func<System.Func`2>{Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext<Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext>, System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}}
    
        
        .. code-block:: csharp
    
            public AssertionRequirement(Func<AuthorizationHandlerContext, Task<bool>> handler)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.AssertionRequirement
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authorization.Infrastructure.AssertionRequirement.HandleAsync(Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext)
    
        
    
        
        Calls :dn:prop:`Microsoft.AspNetCore.Authorization.Infrastructure.AssertionRequirement.Handler` to see if authorization is allowed.
    
        
    
        
        :param context: The authorization information.
        
        :type context: Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task HandleAsync(AuthorizationHandlerContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.AssertionRequirement
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authorization.Infrastructure.AssertionRequirement.Handler
    
        
    
        
        Function that is called to handle this requirement.
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext<Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext>, System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}}
    
        
        .. code-block:: csharp
    
            public Func<AuthorizationHandlerContext, Task<bool>> Handler { get; }
    

