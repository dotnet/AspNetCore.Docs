

ClaimsTransformationHandler Class
=================================



.. contents:: 
   :local:



Summary
-------

Handler that applies ClaimsTransformation to authentication





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.ClaimsTransformationHandler`








Syntax
------

.. code-block:: csharp

   public class ClaimsTransformationHandler : IAuthenticationHandler





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication/ClaimsTransformationHandler.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.ClaimsTransformationHandler

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.ClaimsTransformationHandler
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.ClaimsTransformationHandler.ClaimsTransformationHandler(Microsoft.AspNet.Authentication.IClaimsTransformer)
    
        
        
        
        :type transform: Microsoft.AspNet.Authentication.IClaimsTransformer
    
        
        .. code-block:: csharp
    
           public ClaimsTransformationHandler(IClaimsTransformer transform)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Authentication.ClaimsTransformationHandler
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.ClaimsTransformationHandler.AuthenticateAsync(Microsoft.AspNet.Http.Features.Authentication.AuthenticateContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.Features.Authentication.AuthenticateContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task AuthenticateAsync(AuthenticateContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.ClaimsTransformationHandler.ChallengeAsync(Microsoft.AspNet.Http.Features.Authentication.ChallengeContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.Features.Authentication.ChallengeContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task ChallengeAsync(ChallengeContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.ClaimsTransformationHandler.GetDescriptions(Microsoft.AspNet.Http.Features.Authentication.DescribeSchemesContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.Features.Authentication.DescribeSchemesContext
    
        
        .. code-block:: csharp
    
           public void GetDescriptions(DescribeSchemesContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.ClaimsTransformationHandler.RegisterAuthenticationHandler(Microsoft.AspNet.Http.Features.Authentication.IHttpAuthenticationFeature)
    
        
        
        
        :type auth: Microsoft.AspNet.Http.Features.Authentication.IHttpAuthenticationFeature
    
        
        .. code-block:: csharp
    
           public void RegisterAuthenticationHandler(IHttpAuthenticationFeature auth)
    
    .. dn:method:: Microsoft.AspNet.Authentication.ClaimsTransformationHandler.SignInAsync(Microsoft.AspNet.Http.Features.Authentication.SignInContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.Features.Authentication.SignInContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task SignInAsync(SignInContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.ClaimsTransformationHandler.SignOutAsync(Microsoft.AspNet.Http.Features.Authentication.SignOutContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.Features.Authentication.SignOutContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task SignOutAsync(SignOutContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.ClaimsTransformationHandler.UnregisterAuthenticationHandler(Microsoft.AspNet.Http.Features.Authentication.IHttpAuthenticationFeature)
    
        
        
        
        :type auth: Microsoft.AspNet.Http.Features.Authentication.IHttpAuthenticationFeature
    
        
        .. code-block:: csharp
    
           public void UnregisterAuthenticationHandler(IHttpAuthenticationFeature auth)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.ClaimsTransformationHandler
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.ClaimsTransformationHandler.PriorHandler
    
        
        :rtype: Microsoft.AspNet.Http.Features.Authentication.IAuthenticationHandler
    
        
        .. code-block:: csharp
    
           public IAuthenticationHandler PriorHandler { get; set; }
    

