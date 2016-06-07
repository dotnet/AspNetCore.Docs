

ClaimsTransformationHandler Class
=================================






Handler that applies ClaimsTransformation to authentication


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication`
Assemblies
    * Microsoft.AspNetCore.Authentication

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.ClaimsTransformationHandler`








Syntax
------

.. code-block:: csharp

    public class ClaimsTransformationHandler : IAuthenticationHandler








.. dn:class:: Microsoft.AspNetCore.Authentication.ClaimsTransformationHandler
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.ClaimsTransformationHandler

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.ClaimsTransformationHandler
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.ClaimsTransformationHandler.PriorHandler
    
        
        :rtype: Microsoft.AspNetCore.Http.Features.Authentication.IAuthenticationHandler
    
        
        .. code-block:: csharp
    
            public IAuthenticationHandler PriorHandler
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.ClaimsTransformationHandler
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.ClaimsTransformationHandler.ClaimsTransformationHandler(Microsoft.AspNetCore.Authentication.IClaimsTransformer, Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type transform: Microsoft.AspNetCore.Authentication.IClaimsTransformer
    
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            public ClaimsTransformationHandler(IClaimsTransformer transform, HttpContext httpContext)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authentication.ClaimsTransformationHandler
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.ClaimsTransformationHandler.AuthenticateAsync(Microsoft.AspNetCore.Http.Features.Authentication.AuthenticateContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.Features.Authentication.AuthenticateContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task AuthenticateAsync(AuthenticateContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.ClaimsTransformationHandler.ChallengeAsync(Microsoft.AspNetCore.Http.Features.Authentication.ChallengeContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.Features.Authentication.ChallengeContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task ChallengeAsync(ChallengeContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.ClaimsTransformationHandler.GetDescriptions(Microsoft.AspNetCore.Http.Features.Authentication.DescribeSchemesContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.Features.Authentication.DescribeSchemesContext
    
        
        .. code-block:: csharp
    
            public void GetDescriptions(DescribeSchemesContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.ClaimsTransformationHandler.RegisterAuthenticationHandler(Microsoft.AspNetCore.Http.Features.Authentication.IHttpAuthenticationFeature)
    
        
    
        
        :type auth: Microsoft.AspNetCore.Http.Features.Authentication.IHttpAuthenticationFeature
    
        
        .. code-block:: csharp
    
            public void RegisterAuthenticationHandler(IHttpAuthenticationFeature auth)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.ClaimsTransformationHandler.SignInAsync(Microsoft.AspNetCore.Http.Features.Authentication.SignInContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.Features.Authentication.SignInContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task SignInAsync(SignInContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.ClaimsTransformationHandler.SignOutAsync(Microsoft.AspNetCore.Http.Features.Authentication.SignOutContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.Features.Authentication.SignOutContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task SignOutAsync(SignOutContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.ClaimsTransformationHandler.UnregisterAuthenticationHandler(Microsoft.AspNetCore.Http.Features.Authentication.IHttpAuthenticationFeature)
    
        
    
        
        :type auth: Microsoft.AspNetCore.Http.Features.Authentication.IHttpAuthenticationFeature
    
        
        .. code-block:: csharp
    
            public void UnregisterAuthenticationHandler(IHttpAuthenticationFeature auth)
    

