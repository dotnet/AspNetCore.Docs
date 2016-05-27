

IAuthenticationHandler Interface
================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Features.Authentication`
Assemblies
    * Microsoft.AspNetCore.Http.Features

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IAuthenticationHandler








.. dn:interface:: Microsoft.AspNetCore.Http.Features.Authentication.IAuthenticationHandler
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Http.Features.Authentication.IAuthenticationHandler

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Http.Features.Authentication.IAuthenticationHandler
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.Features.Authentication.IAuthenticationHandler.AuthenticateAsync(Microsoft.AspNetCore.Http.Features.Authentication.AuthenticateContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.Features.Authentication.AuthenticateContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            Task AuthenticateAsync(AuthenticateContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Features.Authentication.IAuthenticationHandler.ChallengeAsync(Microsoft.AspNetCore.Http.Features.Authentication.ChallengeContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.Features.Authentication.ChallengeContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            Task ChallengeAsync(ChallengeContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Features.Authentication.IAuthenticationHandler.GetDescriptions(Microsoft.AspNetCore.Http.Features.Authentication.DescribeSchemesContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.Features.Authentication.DescribeSchemesContext
    
        
        .. code-block:: csharp
    
            void GetDescriptions(DescribeSchemesContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Features.Authentication.IAuthenticationHandler.SignInAsync(Microsoft.AspNetCore.Http.Features.Authentication.SignInContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.Features.Authentication.SignInContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            Task SignInAsync(SignInContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Features.Authentication.IAuthenticationHandler.SignOutAsync(Microsoft.AspNetCore.Http.Features.Authentication.SignOutContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.Features.Authentication.SignOutContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            Task SignOutAsync(SignOutContext context)
    

