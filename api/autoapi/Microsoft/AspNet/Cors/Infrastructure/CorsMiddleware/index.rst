

CorsMiddleware Class
====================



.. contents:: 
   :local:



Summary
-------

An ASP.NET middleware for handling CORS.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Cors.Infrastructure.CorsMiddleware`








Syntax
------

.. code-block:: csharp

   public class CorsMiddleware





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/cors/src/Microsoft.AspNet.Cors/CorsMiddleware.cs>`_





.. dn:class:: Microsoft.AspNet.Cors.Infrastructure.CorsMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNet.Cors.Infrastructure.CorsMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Cors.Infrastructure.CorsMiddleware.CorsMiddleware(Microsoft.AspNet.Builder.RequestDelegate, Microsoft.AspNet.Cors.Infrastructure.ICorsService, Microsoft.AspNet.Cors.Infrastructure.CorsPolicy)
    
        
    
        Instantiates a new :any:`Microsoft.AspNet.Cors.Infrastructure.CorsMiddleware`\.
    
        
        
        
        :param next: The next middleware in the pipeline.
        
        :type next: Microsoft.AspNet.Builder.RequestDelegate
        
        
        :param corsService: An instance of .
        
        :type corsService: Microsoft.AspNet.Cors.Infrastructure.ICorsService
        
        
        :param policy: An instance of the  which can be applied.
        
        :type policy: Microsoft.AspNet.Cors.Infrastructure.CorsPolicy
    
        
        .. code-block:: csharp
    
           public CorsMiddleware(RequestDelegate next, ICorsService corsService, CorsPolicy policy)
    
    .. dn:constructor:: Microsoft.AspNet.Cors.Infrastructure.CorsMiddleware.CorsMiddleware(Microsoft.AspNet.Builder.RequestDelegate, Microsoft.AspNet.Cors.Infrastructure.ICorsService, Microsoft.AspNet.Cors.Infrastructure.ICorsPolicyProvider, System.String)
    
        
    
        Instantiates a new :any:`Microsoft.AspNet.Cors.Infrastructure.CorsMiddleware`\.
    
        
        
        
        :param next: The next middleware in the pipeline.
        
        :type next: Microsoft.AspNet.Builder.RequestDelegate
        
        
        :param corsService: An instance of .
        
        :type corsService: Microsoft.AspNet.Cors.Infrastructure.ICorsService
        
        
        :param policyProvider: A policy provider which can get an .
        
        :type policyProvider: Microsoft.AspNet.Cors.Infrastructure.ICorsPolicyProvider
        
        
        :param policyName: An optional name of the policy to be fetched.
        
        :type policyName: System.String
    
        
        .. code-block:: csharp
    
           public CorsMiddleware(RequestDelegate next, ICorsService corsService, ICorsPolicyProvider policyProvider, string policyName)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Cors.Infrastructure.CorsMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Cors.Infrastructure.CorsMiddleware.Invoke(Microsoft.AspNet.Http.HttpContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task Invoke(HttpContext context)
    

