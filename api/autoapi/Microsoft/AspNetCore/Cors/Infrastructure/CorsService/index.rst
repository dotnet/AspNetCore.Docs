

CorsService Class
=================






Default implementation of :any:`Microsoft.AspNetCore.Cors.Infrastructure.ICorsService`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Cors.Infrastructure`
Assemblies
    * Microsoft.AspNetCore.Cors

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Cors.Infrastructure.CorsService`








Syntax
------

.. code-block:: csharp

    public class CorsService : ICorsService








.. dn:class:: Microsoft.AspNetCore.Cors.Infrastructure.CorsService
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Cors.Infrastructure.CorsService

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Cors.Infrastructure.CorsService
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Cors.Infrastructure.CorsService.CorsService(Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Cors.Infrastructure.CorsOptions>)
    
        
    
        
        Creates a new instance of the :any:`Microsoft.AspNetCore.Cors.Infrastructure.CorsService`\.
    
        
    
        
        :param options: The option model representing :any:`Microsoft.AspNetCore.Cors.Infrastructure.CorsOptions`\.
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Cors.Infrastructure.CorsOptions<Microsoft.AspNetCore.Cors.Infrastructure.CorsOptions>}
    
        
        .. code-block:: csharp
    
            public CorsService(IOptions<CorsOptions> options)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Cors.Infrastructure.CorsService
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Cors.Infrastructure.CorsService.ApplyResult(Microsoft.AspNetCore.Cors.Infrastructure.CorsResult, Microsoft.AspNetCore.Http.HttpResponse)
    
        
    
        
        :type result: Microsoft.AspNetCore.Cors.Infrastructure.CorsResult
    
        
        :type response: Microsoft.AspNetCore.Http.HttpResponse
    
        
        .. code-block:: csharp
    
            public virtual void ApplyResult(CorsResult result, HttpResponse response)
    
    .. dn:method:: Microsoft.AspNetCore.Cors.Infrastructure.CorsService.EvaluatePolicy(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type policy: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy
        :rtype: Microsoft.AspNetCore.Cors.Infrastructure.CorsResult
    
        
        .. code-block:: csharp
    
            public CorsResult EvaluatePolicy(HttpContext context, CorsPolicy policy)
    
    .. dn:method:: Microsoft.AspNetCore.Cors.Infrastructure.CorsService.EvaluatePolicy(Microsoft.AspNetCore.Http.HttpContext, System.String)
    
        
    
        
        Looks up a policy using the <em>policyName</em> and then evaluates the policy using the passed in
        <em>context</em>.
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type policyName: System.String
        :rtype: Microsoft.AspNetCore.Cors.Infrastructure.CorsResult
        :return: A :any:`Microsoft.AspNetCore.Cors.Infrastructure.CorsResult` which contains the result of policy evaluation and can be
            used by the caller to set appropriate response headers.
    
        
        .. code-block:: csharp
    
            public CorsResult EvaluatePolicy(HttpContext context, string policyName)
    
    .. dn:method:: Microsoft.AspNetCore.Cors.Infrastructure.CorsService.EvaluatePreflightRequest(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy, Microsoft.AspNetCore.Cors.Infrastructure.CorsResult)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type policy: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy
    
        
        :type result: Microsoft.AspNetCore.Cors.Infrastructure.CorsResult
    
        
        .. code-block:: csharp
    
            public virtual void EvaluatePreflightRequest(HttpContext context, CorsPolicy policy, CorsResult result)
    
    .. dn:method:: Microsoft.AspNetCore.Cors.Infrastructure.CorsService.EvaluateRequest(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy, Microsoft.AspNetCore.Cors.Infrastructure.CorsResult)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type policy: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy
    
        
        :type result: Microsoft.AspNetCore.Cors.Infrastructure.CorsResult
    
        
        .. code-block:: csharp
    
            public virtual void EvaluateRequest(HttpContext context, CorsPolicy policy, CorsResult result)
    

