

IAuthenticationHandler Interface
================================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IAuthenticationHandler





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http.Features/Authentication/IAuthenticationHandler.cs>`_





.. dn:interface:: Microsoft.AspNet.Http.Features.Authentication.IAuthenticationHandler

Methods
-------

.. dn:interface:: Microsoft.AspNet.Http.Features.Authentication.IAuthenticationHandler
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.Features.Authentication.IAuthenticationHandler.AuthenticateAsync(Microsoft.AspNet.Http.Features.Authentication.AuthenticateContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.Features.Authentication.AuthenticateContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task AuthenticateAsync(AuthenticateContext context)
    
    .. dn:method:: Microsoft.AspNet.Http.Features.Authentication.IAuthenticationHandler.ChallengeAsync(Microsoft.AspNet.Http.Features.Authentication.ChallengeContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.Features.Authentication.ChallengeContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task ChallengeAsync(ChallengeContext context)
    
    .. dn:method:: Microsoft.AspNet.Http.Features.Authentication.IAuthenticationHandler.GetDescriptions(Microsoft.AspNet.Http.Features.Authentication.DescribeSchemesContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.Features.Authentication.DescribeSchemesContext
    
        
        .. code-block:: csharp
    
           void GetDescriptions(DescribeSchemesContext context)
    
    .. dn:method:: Microsoft.AspNet.Http.Features.Authentication.IAuthenticationHandler.SignInAsync(Microsoft.AspNet.Http.Features.Authentication.SignInContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.Features.Authentication.SignInContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task SignInAsync(SignInContext context)
    
    .. dn:method:: Microsoft.AspNet.Http.Features.Authentication.IAuthenticationHandler.SignOutAsync(Microsoft.AspNet.Http.Features.Authentication.SignOutContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.Features.Authentication.SignOutContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task SignOutAsync(SignOutContext context)
    

