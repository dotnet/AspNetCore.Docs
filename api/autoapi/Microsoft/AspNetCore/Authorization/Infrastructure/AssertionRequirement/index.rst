

AssertionRequirement Class
==========================





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

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.AssertionRequirement
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authorization.Infrastructure.AssertionRequirement.Handler
    
        
    
        
        Function that is called to handle this requirement
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Authorization.AuthorizationContext<Microsoft.AspNetCore.Authorization.AuthorizationContext>, System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}}
    
        
        .. code-block:: csharp
    
            public Func<AuthorizationContext, Task<bool>> Handler
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.AssertionRequirement
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authorization.Infrastructure.AssertionRequirement.AssertionRequirement(System.Func<Microsoft.AspNetCore.Authorization.AuthorizationContext, System.Boolean>)
    
        
    
        
        :type assert: System.Func<System.Func`2>{Microsoft.AspNetCore.Authorization.AuthorizationContext<Microsoft.AspNetCore.Authorization.AuthorizationContext>, System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            public AssertionRequirement(Func<AuthorizationContext, bool> assert)
    
    .. dn:constructor:: Microsoft.AspNetCore.Authorization.Infrastructure.AssertionRequirement.AssertionRequirement(System.Func<Microsoft.AspNetCore.Authorization.AuthorizationContext, System.Threading.Tasks.Task<System.Boolean>>)
    
        
    
        
        :type assert: System.Func<System.Func`2>{Microsoft.AspNetCore.Authorization.AuthorizationContext<Microsoft.AspNetCore.Authorization.AuthorizationContext>, System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}}
    
        
        .. code-block:: csharp
    
            public AssertionRequirement(Func<AuthorizationContext, Task<bool>> assert)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.AssertionRequirement
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authorization.Infrastructure.AssertionRequirement.HandleAsync(Microsoft.AspNetCore.Authorization.AuthorizationContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Authorization.AuthorizationContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task HandleAsync(AuthorizationContext context)
    

