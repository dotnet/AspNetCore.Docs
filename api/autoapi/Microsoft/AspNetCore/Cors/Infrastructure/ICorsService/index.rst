

ICorsService Interface
======================






A type which can evaluate a policy for a particular :any:`Microsoft.AspNetCore.Http.HttpContext`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Cors.Infrastructure`
Assemblies
    * Microsoft.AspNetCore.Cors

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface ICorsService








.. dn:interface:: Microsoft.AspNetCore.Cors.Infrastructure.ICorsService
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Cors.Infrastructure.ICorsService

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Cors.Infrastructure.ICorsService
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Cors.Infrastructure.ICorsService.ApplyResult(Microsoft.AspNetCore.Cors.Infrastructure.CorsResult, Microsoft.AspNetCore.Http.HttpResponse)
    
        
    
        
        Adds CORS-specific response headers to the given <em>response</em>.
    
        
    
        
        :param result: The :any:`Microsoft.AspNetCore.Cors.Infrastructure.CorsResult` used to read the allowed values.
        
        :type result: Microsoft.AspNetCore.Cors.Infrastructure.CorsResult
    
        
        :param response: The :any:`Microsoft.AspNetCore.Http.HttpResponse` associated with the current call.
        
        :type response: Microsoft.AspNetCore.Http.HttpResponse
    
        
        .. code-block:: csharp
    
            void ApplyResult(CorsResult result, HttpResponse response)
    
    .. dn:method:: Microsoft.AspNetCore.Cors.Infrastructure.ICorsService.EvaluatePolicy(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy)
    
        
    
        
        Evaluates the given <em>policy</em> using the passed in <em>context</em>.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Http.HttpContext` associated with the call.
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :param policy: The :any:`Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy` which needs to be evaluated.
        
        :type policy: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy
        :rtype: Microsoft.AspNetCore.Cors.Infrastructure.CorsResult
        :return: A :any:`Microsoft.AspNetCore.Cors.Infrastructure.CorsResult` which contains the result of policy evaluation and can be
            used by the caller to set appropriate response headers.
    
        
        .. code-block:: csharp
    
            CorsResult EvaluatePolicy(HttpContext context, CorsPolicy policy)
    

