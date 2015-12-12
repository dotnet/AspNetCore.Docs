

CorsService Class
=================



.. contents:: 
   :local:



Summary
-------

Default implementation of :any:`Microsoft.AspNet.Cors.Infrastructure.ICorsService`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Cors.Infrastructure.CorsService`








Syntax
------

.. code-block:: csharp

   public class CorsService : ICorsService





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/cors/src/Microsoft.AspNet.Cors/CorsService.cs>`_





.. dn:class:: Microsoft.AspNet.Cors.Infrastructure.CorsService

Constructors
------------

.. dn:class:: Microsoft.AspNet.Cors.Infrastructure.CorsService
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Cors.Infrastructure.CorsService.CorsService(Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Cors.Infrastructure.CorsOptions>)
    
        
    
        Creates a new instance of the :any:`Microsoft.AspNet.Cors.Infrastructure.CorsService`\.
    
        
        
        
        :param options: The option model representing .
        
        :type options: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.AspNet.Cors.Infrastructure.CorsOptions}
    
        
        .. code-block:: csharp
    
           public CorsService(IOptions<CorsOptions> options)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Cors.Infrastructure.CorsService
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Cors.Infrastructure.CorsService.ApplyResult(Microsoft.AspNet.Cors.Infrastructure.CorsResult, Microsoft.AspNet.Http.HttpResponse)
    
        
        
        
        :type result: Microsoft.AspNet.Cors.Infrastructure.CorsResult
        
        
        :type response: Microsoft.AspNet.Http.HttpResponse
    
        
        .. code-block:: csharp
    
           public virtual void ApplyResult(CorsResult result, HttpResponse response)
    
    .. dn:method:: Microsoft.AspNet.Cors.Infrastructure.CorsService.EvaluatePolicy(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Cors.Infrastructure.CorsPolicy)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :type policy: Microsoft.AspNet.Cors.Infrastructure.CorsPolicy
        :rtype: Microsoft.AspNet.Cors.Infrastructure.CorsResult
    
        
        .. code-block:: csharp
    
           public CorsResult EvaluatePolicy(HttpContext context, CorsPolicy policy)
    
    .. dn:method:: Microsoft.AspNet.Cors.Infrastructure.CorsService.EvaluatePolicy(Microsoft.AspNet.Http.HttpContext, System.String)
    
        
    
        Looks up a policy using the ``policyName`` and then evaluates the policy using the passed in
        ``context``.
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :type policyName: System.String
        :rtype: Microsoft.AspNet.Cors.Infrastructure.CorsResult
        :return: A <see cref="T:Microsoft.AspNet.Cors.Infrastructure.CorsResult" /> which contains the result of policy evaluation and can be
            used by the caller to set appropriate response headers.
    
        
        .. code-block:: csharp
    
           public CorsResult EvaluatePolicy(HttpContext context, string policyName)
    
    .. dn:method:: Microsoft.AspNet.Cors.Infrastructure.CorsService.EvaluatePreflightRequest(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Cors.Infrastructure.CorsPolicy, Microsoft.AspNet.Cors.Infrastructure.CorsResult)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :type policy: Microsoft.AspNet.Cors.Infrastructure.CorsPolicy
        
        
        :type result: Microsoft.AspNet.Cors.Infrastructure.CorsResult
    
        
        .. code-block:: csharp
    
           public virtual void EvaluatePreflightRequest(HttpContext context, CorsPolicy policy, CorsResult result)
    
    .. dn:method:: Microsoft.AspNet.Cors.Infrastructure.CorsService.EvaluateRequest(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Cors.Infrastructure.CorsPolicy, Microsoft.AspNet.Cors.Infrastructure.CorsResult)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :type policy: Microsoft.AspNet.Cors.Infrastructure.CorsPolicy
        
        
        :type result: Microsoft.AspNet.Cors.Infrastructure.CorsResult
    
        
        .. code-block:: csharp
    
           public virtual void EvaluateRequest(HttpContext context, CorsPolicy policy, CorsResult result)
    

