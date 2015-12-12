

ICorsService Interface
======================



.. contents:: 
   :local:



Summary
-------

A type which can evaluate a policy for a particular :any:`Microsoft.AspNet.Http.HttpContext`\.











Syntax
------

.. code-block:: csharp

   public interface ICorsService





GitHub
------

`View on GitHub <https://github.com/aspnet/cors/blob/master/src/Microsoft.AspNet.Cors/ICorsService.cs>`_





.. dn:interface:: Microsoft.AspNet.Cors.Infrastructure.ICorsService

Methods
-------

.. dn:interface:: Microsoft.AspNet.Cors.Infrastructure.ICorsService
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Cors.Infrastructure.ICorsService.ApplyResult(Microsoft.AspNet.Cors.Infrastructure.CorsResult, Microsoft.AspNet.Http.HttpResponse)
    
        
    
        Adds CORS-specific response headers to the given ``response``.
    
        
        
        
        :param result: The  used to read the allowed values.
        
        :type result: Microsoft.AspNet.Cors.Infrastructure.CorsResult
        
        
        :param response: The  associated with the current call.
        
        :type response: Microsoft.AspNet.Http.HttpResponse
    
        
        .. code-block:: csharp
    
           void ApplyResult(CorsResult result, HttpResponse response)
    
    .. dn:method:: Microsoft.AspNet.Cors.Infrastructure.ICorsService.EvaluatePolicy(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Cors.Infrastructure.CorsPolicy)
    
        
    
        Evaluates the given ``policy`` using the passed in ``context``.
    
        
        
        
        :param context: The  associated with the call.
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :param policy: The  which needs to be evaluated.
        
        :type policy: Microsoft.AspNet.Cors.Infrastructure.CorsPolicy
        :rtype: Microsoft.AspNet.Cors.Infrastructure.CorsResult
        :return: A <see cref="T:Microsoft.AspNet.Cors.Infrastructure.CorsResult" /> which contains the result of policy evaluation and can be
            used by the caller to set appropriate response headers.
    
        
        .. code-block:: csharp
    
           CorsResult EvaluatePolicy(HttpContext context, CorsPolicy policy)
    

